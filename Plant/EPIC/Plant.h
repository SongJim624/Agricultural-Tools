#include <math.h>
#include "../../Core/Component.h"

#ifndef _EPIC_PLANT_
#define _EPIC_PLANT_
struct Dependency
{
    float Tmax, Tmin, Rad, Pre, Win;
};

class EPIC_Plant : public Component
{
private:
//Climate

//VPD is the vapor pressure deficit in KPa
    float Tmax, Tmin, Rad, CO2, VPD;

//Parameters
    float Tbase, WVAP, bc1, bc2, ah, ad, HMX;

    float HU, dDM, LAI;

    float LAI, root_depth, height, soil_depth, biomass;

private:
    float Water_Stress();
    float Nitrogen_Stress();
    float Phosphorus_Stress();

    float Harvest_Index();
    float Biomass();
    
public:
    virtual bool Update(IState * istates);
    virtual std::vector<float> Inquire(const std::string& name);

};
#endif //!_EPIC_PLANT_