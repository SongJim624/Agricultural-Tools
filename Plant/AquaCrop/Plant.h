#include "../../Core/Component.h"
#include <math.h>

class Canopy
{
private:
    const float TS2E, TS2S, CGC, CDC, CCo, CCx, fdecline, kcbtrx, fage, alpha, beta;
		bool CCx_reached;
	float  CCmax, TS2CCx, CCs, belight_time;
public:
    void Update(float& canopy_cover);    
};

class Biomass
{
private:
//parameters
    const float WP, sink, fyield, TS2F;

    const float bsted = 0.000138;
    const float bface = 0.001165;
    const float Coi = 369.410;

public:
    Biomass();
    void Update(float& biomass,  );
};

class Root
{
private:
// parameters
    const float TS2E, TS2R, Zo, Zx, SF_root, SxTop, SxBot, SF_proot;

private:
    float Speed(const float& time, const float& ks_sto);

public:    
    Root();
    void Update(float& root_depth, const float& time, const float& ks_sto);
    std::vector<float> Sink_Ability();
};

class Harvest
{

};

class AquaCrop_Plant : public Component
{
private:
    Canopy * canopy;
    Biomass * biomass;
    Harvest * harvest;

private:
//states
    float biomass, root_depth, canopy_cover, harvest_index;
    float ksw_sto, ksw_exp;

private:
    AquaCrop_Plant();

public:
    static Component * Create();
    ~AquaCrop_Plant();

    virtual bool Intialize(IState * states, IParameter * iparameters);
    virtual bool Update(IState * istates);
    virtual bool Inquire(const std::string& name, const std::vector<float>& value);

    virtual void Discribe(const char * file);
    virtual void Convert(const char* parameters, const char* xml);
};