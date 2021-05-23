#include "Stress.h"

#ifndef _ROOT_
#define _ROOT_
template<typename T>
class Root
{
private:
    const T TS2E, TS2R, Zo, Zx, SF_root, SxTop, SxBot, SF_proot;

private:
    T Speed(const T& time)
    {
        T Inter = (time - 0.5 * TS2E) / (TS2R - 0.5 * TS2E);
	    return (Zx - Zo) / SF_root * pow(Inter, 1.0 / SF_root - 1.0) / (TS2R - 0.5 * TS2E);
    }

    void Adjust(T& speed, const T& ks_sto)
    {
        speed *= (SF_proot == 0.0 ? ks_sto : (exp(ks_sto * SF_proot) - 1.0) / (exp(SF_proot) - 1.0));
    }

public:    
    Root(State<T>& states, Parameter<T> parameters)
        : TS2E(parameters["TS2E"]), TS2R(parameters["TS2R"]), Zo(parameters["Zo"]), 
        Zx(parameters["Zx"]), SF_root(parameters["SF_root"]), SF_proot(parameters["SF_proot"]),
        SxTop(parameters["SxTop"]), SxBot(parameters["SxBot"])
    {
        if (states["root depth"] == 0.0) { states["root depth"] = Zo; }
    }

    void Update(State<T>& states, Dependency<T>& depend, Stress<T>& stress)
    {
        //I used the mm as the unit, while the AquaCrop used the m as the unit,
        //the difference thus came out.

        T s = Speed(states["crop growth time"]);
        Adjust(s, stress.ksw_sto_root());

        states["root depth"] += min(s * depend.GDD, Zx - states["root depth"]);
    	return;
    }

    std::vector<T> Sink_Ability(State<T>& states, const Dependency<T>& depend, Stress<T>& stress)
    {
        std::vector<T> sink = std::vector<T>(depend.compart.size());
        std::vector<T> ksw_sto_array = stress.ksw_sto_array();
        std::vector<T> ksw_aer_array = stress.ksw_aer_array();

        // Water Extract
        T Z = 0;
        for (size_t i = 0; i < depend.compart.size(); ++i)
        {
            if (Z == states["root depth"]) { break; }
            T Zi = min(states["root depth"] - Z, 10.0 * depend.compart[i]);
            Z += Zi;

            sink[i] = (states["root depth"] - Z + 0.5 * Zi) / states["root depth"]
                * (SxTop - SxBot) + SxBot;

            sink[i] *= ksw_sto_array[i] * ksw_aer_array[i];
        }

        return sink;
    }

};
#endif //!_ROOT_