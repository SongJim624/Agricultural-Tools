
class Biomass
{
private:
    const float WP, sink, fyield, TS2F;

    const float bsted = 0.000138;
    const float bface = 0.001165;
    const float Coi = 369.410;

    float bp;
private:
    float WP_Adjust(const T& Cai)
    {
    	float w = min(1.0, max(1.0 - (550.0 - Cai) / (550.0 - Coi), 0.0));
    	float ftype = min(1.0, max(2.0 - 0.05 * WP, 0));

    	float fCO2 = (Cai / Coi) /
    		(1.0 + (Cai - Coi) * ((1.0f - w) * bsted +
	    		w * (0.01 * sink * bsted + (1.0 - 0.01 * sink) * bface)));

    	return (1.0 + ftype * (fCO2 - 1.0)) * WP;
    }

public:
    Biomass(State<T>& states, Parameter<T>& parameters)
        : WP(parameters["WP"]), fyield(parameters["fyield"]), sink(parameters["sink"]), TS2F(parameters["TS2F"])
    {
        bp = states["biomass"];
    }

    void Update(State<T>& states, Dependency<T>& depend, Stress<T>& stress, const T& trx)
    {
        float dB = WP_Adjust(depend.CO2) * (depend.trp / depend.ETo);
        float dBp = WP_Adjust(depend.CO2) * (trx / depend.ETo);

    	//Because the WP is also a percentage,
	    //so the dB need to be multipled by 0.01
	    dB  *=  0.01 * (states["crop growth time"] >= TS2F ? 0.01 * fyield : 1.0);
	    dBp  *=  0.01 * (states["crop growth time"] >= TS2F ? 0.01 * fyield : 1.0);
	    
        states["biomass"] += dB;
        bp += dBp;
        return;
    }

    float Brel(State<T>& states) { return states["biomass"] / bp; }
};
#endif //!_BIOMASS_