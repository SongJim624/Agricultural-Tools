#include "Stress.h"

#ifndef _CANOPY_
#define _CANOPY_
template<typename T>
class Canopy
{
private:
	const T TS2E, TS2S, CGC, CDC, CCo, CCx, fdecline, kcbtrx, fage, alpha, beta;
	
	bool CCx_reached;
	T CCmax, TS2CCx, CCs, belight_time;

private:
    T Early_Growth(const T& t, const T& CGC)
	{
		return CGC * CCo * exp(t * CGC);
	}

    T Later_Growth(const T& t, const T& CGC)
	{
		return 0.25 * CCx * CCx * CGC * exp(-t * CGC) / CCo;
	}

    T Middle_Season_Decline(const T& time)
	{
		return -0.02 * fdecline * (time - TS2CCx) / (TS2S - TS2CCx);
	}

    T Late_Season_Decline(const T& t, const T& CCx, const T& ksw_sen)
	{
		T s = -0.05 * 3.33 * CDC * CCx * exp(3.33 * CDC * t / (CCx + 2.29)) / (CCx + 2.29);
		return (1.0 - pow(ksw_sen, 8)) * s;
	}

private:
	T KC(const T& time, const T& CC, const bool& belighting)
	{
		T kc = kcbtrx;

		if (belighting)
		{
			kc *= pow(CC / CCs, alpha);
		}

		if (TS2CCx != 0 && time > TS2CCx)
		{
			kc -= fage * (time - TS2CCx) * CCmax;
		}

		return kc;
	}

public:
    Canopy(State<T>& states, Parameter<T>& parameters)
		: TS2E(parameters["TS2E"]), TS2S(parameters["TS2S"]), kcbtrx(parameters["kcbtrx"]),
		CGC(parameters["CGC"]), CDC(parameters["CDC"]), CCo(parameters["CCo"]), fdecline(parameters["fdecline"]),
		fage(parameters["fage"]), CCx(parameters["CCx"]), beta(parameters["beta"]),
		TS2CCx(0.0), alpha(parameters["alpha"]), 
		belight_time(0.0), CCmax(0.0), CCs(0.0), CCx_reached(false)
	{
		if (states["canopy cover"] == 0.0) { states["canopy cover"] = CCo; }
	}

    void Update(State<T>& states, Dependency<T>& depend, Stress<T>& stress)
    {
		bool status = states["crop growth time"] > TS2S || (1.0 - stress.ksw_sen() > epslon &&
			states["canopy cover"] > 1.25 * CCo);

		if(status)
		{
//Senescence triggered
			if(!states.belighting)
			{
				states.belighting = true;
				CCs = states["canopy cover"];
				belight_time = 0.5 * depend.GDD;
			}
//Senescence continue
			else
			{
				belight_time += 0.5 * depend.GDD;
			}

//Calculation of senescence
		    T speed = 	Late_Season_Decline(belight_time, CCs,
				states["crop growth time"] > TS2S ? 0.0 : stress.ksw_sen(beta));
			
			states["canopy cover"] = max(states["canopy cover"] + speed * depend.GDD, 0.0);
    		belight_time += 0.5 * depend.GDD;
	    	return;
		}
		else
		{
//Senescence stops
			if (states.belighting) { states.belighting = false; }

//decline because of ageing and lack of nutrient in the middle season
	    	if (CCx_reached)
	    	{
				states["canopy cover"] = Middle_Season_Decline(states["crop growth time"]);
		    	return;
    		}
//Normal Development
			T speed = states["canopy cover"] < 0.5 * CCx ?
		    Early_Growth(states["crop growth time"] - TS2E, CGC * stress.ksw_exp()):
		    Later_Growth(states["crop growth time"] - TS2E, CGC * stress.ksw_exp());

			states["canopy cover"] += (states["canopy cover"] > CCx ? 0.0 : speed) * depend.GDD;

			if (!CCx_reached && abs(states["canopy cover"] - CCx) < epslon)
	    	{
		    	CCx_reached = true;
				CCmax = states["canopy cover"];
		    	TS2CCx = states["crop growth time"] + 0.5 * depend.GDD;
	    	}

			return;			
		}       
    }

	T Transpiration_Ability(State<T>& states, Dependency<T>& depend, Stress<T>& stress)
	{
		return KC(states["crop growth time"], states["canopy cover"], states.belighting) * states["canopy cover"] *
			stress.ksw_sto() * stress.ksw_aer() * 
			stress.ksc_sto() * depend.ETo;
	}
};
#endif //!_CANOPY_