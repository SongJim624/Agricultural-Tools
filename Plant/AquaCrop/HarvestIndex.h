#include "Stress.h"

#ifndef _HARVESTINDEX_
#define _HARVESTINDEX_
constexpr double HIini = 0.02;

template<typename T>
class HarvestIndex
{
//Parameters
    const T HIo, dHIante, dHIx, a, b, fexcess, CCr;
    const T TS2F, TS2S, FL, build;

    T HIini, HIx, HIGC, HI_speed, HIo_adj, HIo_reachable;
    bool linear;
private:
    T HIGC_Cal(const T& HIo)
    {
        return log((0.98 * HIo - HIini) / (HIini / 0.98 - HIini)) / build;
    }

    T HI_Speed(const T& time)
    {
    	T HI = HIini * HIo / (HIini + (HIo - HIini) * exp(-HIGC * time));
	    return HIGC * HI * (1 - HI / HIo);
    }

    T Pre_Anthesis(const T& Brel)
    {
    	T low = min(1.0 - log(dHIante) / 5.62, 1.0);
    	T axis = 0.666667 - 0.333333 * low;

	    if (Brel > axis)
	    {
		    T r = (Brel - axis) / (1.0 - axis);
		    return 1.0 + 0.5 * (1.0 + sin((0.5 + r) * 3.1415926)) * 0.01 * dHIante;
	    }

    	if (Brel > low)
	    {
		    T r = (Brel - low) / (axis - low);
		    return 1.0 + 0.5 * (1.0 + sin((1.5 - r) * 3.1415926)) * 0.01 * dHIante;
	    }

    	return 1.0;
    }

    T During_Anthesis(const T& l, const T& r)
    {
        //The adjustment for the pollination is only valid for the gain/fruit crop
    	T f_l = 0.00558 * pow(l, 1.63) / 1.63  - 0.000969 * 0.5 * l * l - 0.00383 * l;
    	T f_r = 0.00558 * pow(r, 1.63) / 1.63  - 0.000969 * 0.5 * r * r - 0.00383 * r;

    	return  (f_r - f_l) * (1.0 + 0.01 * fexcess);
    }

    T Upward(const T& exp)
    {
    	return (1 + (1 - exp) / a);
    }

    T Downward(const T& sto)
    {
    	return pow(sto, 0.1) * (1.0 - (1.0 - sto) / b);
    }

public:
    HarvestIndex(Parameter<T> parameters, const T& Brel)
        : TS2F(parameters["TS2F"]), TS2S(parameters["TS2S"]), FL(parameters["FL"]), build(parameters["build"]), linear(false),
        HIo(parameters["HIo"]), HIx(parameters["HIx"]), dHIante(parameters["dHIante"]), HIini(0.02 * HIo), 
        dHIx(parameters["dHIx"]), a(parameters["a"]), b(parameters["b"]), 
        fexcess(parameters["fexcess"]), CCr(parameters["CC_remain"])
    {
        HIx = HIo * (1 + 0.01 * dHIx);
        HIo_adj = min(HIo * Pre_Anthesis(Brel), HIx);
        HIGC = HIGC_Cal(HIo_adj);
    }

    void Update(State<T>& states, Dependency<T>& depend, Stress<T>& stress)
    {
    	if (abs(states["harvest index"] - HIx) < epslon || states["canopy cover"] <= CCr) { return; }

    	if(states["crop growth time"] - TS2F < FL)
    	{
		    HIo_reachable += During_Anthesis(100.0 * (states["crop growth time"] - TS2F - 0.5 * depend.GDD) / FL,
                100.0 * (states["crop growth time"] - TS2F + 0.5 * depend.GDD) / FL) * HIo_adj;

    		if (!linear)
	    	{
		    	HI_speed = HI_Speed(states["crop growth time"] - TS2F);
		    }
		
    		states["harvest index"] += HI_speed * depend.GDD;
    	}

    	if (states["crop growth time"] - TS2F > FL)
    	{
	    	if (!linear)
		    {
			    HI_speed = HI_Speed(states["crop growth time"] - TS2F);
		    }

            states["harvest index"] += HI_speed * (states.belighting ? 1.0 :
                Upward(stress.ksw_exp())) * Downward(stress.ksw_sto()) * depend.GDD;
	    }

    	if (states["harvest index"] + HI_speed * (build - states["crop growth time"] - 0.5 * depend.GDD + TS2F) > HIo_adj)
    	{
	    	linear = true;
	    }

    	return;
    }
};
#endif //!_HARVESTINDEX_