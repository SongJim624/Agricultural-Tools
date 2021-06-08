#include "Climate.h"

bool AquaCrop_Climate::Update(IState * istates)
{
    istates->Write("daily maximum temperature", std::vector<float>(Tmaxs[today]));
    istates->Write("daily minimum temperature", std::vector<float>(Tmins[today]));    
    istates->Write("daily reference evapotranspiration", std::vector<float>(ETos[today]));    
    istates->Write("daily precipitation", std::vector<float>(Pres[today]));

    today++;
}