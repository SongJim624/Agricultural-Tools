#include "Basic Structure.h"

void Leaf::Grow(const float& mass, const float& dt)
{
    float TEMP = 0.5 * (climate.Tmax + climate.Tmin);

    float FYSDEL = fmaxf(0., (TEMP - TBASE) / (35. - TBASE));

    for(auto& iter : time)
    {
        iter += TEMP * dt;
    }

    leaf.push_back(mass);
    time.push_back(dt);

    while(*time.begin() > SPAN)
    {
        time.pop_front();
        leaf.pop_front();
    }
}

float Leaf::LAI()
{
    float res = 0;
    
    for(auto iter : leaf)
    {
       res += iter * ; 
    }

    return res;
}

float Leaf::Rate(float LAI, float AMAX, float EFF, 
      float PARDIF, float PARDIR, float SINB, float KDIF)
{    
    //scattering coefficient
    float SCV = 0.2f;

    // extinction coefficients KDIF,KDIRBL,KDIRT
    float REFH   = (1. - sqrt(1.-SCV))/(1. + sqrt(1.-SCV));
    float REFS   = REFH * 2./(1. + 1.6*SINB);
    float KDIRBL = (0.5 / SINB) * KDIF / (0.8 * sqrt(1. - SCV));
    float KDIRT  = KDIRBL * sqrt(1. - SCV);

// three-point Gaussian integration over LAI
    float FGROS  = 0.;

    for(size_t i = 0; i < XGAUSS.size();  ++i)
    {
        float LAIC = this->LAI() * XGAUSS[i];
// absorbed diffuse radiation (VISDF),light from direct origine (VIST) and direct light(VISD)
        float VISDF = (1. - REFS) * PARDIF * KDIF * exp(-KDIF * LAIC);
        float VIST = (1. - REFS) * PARDIR * KDIRT * exp(-KDIRT * LAIC);
        float VISD   = (1.-SCV) *PARDIR*KDIRBL* exp(-KDIRBL*LAIC);

// absorbed flux in W/m2 for shaded leaves and assimilation
        float VISSHD = VISDF + VIST - VISD;
        float FGRSH  = AMAX * (1.- exp(-VISSHD * EFF / fmaxf(2.0,AMAX)));

// direct light absorbed by leaves perpendicular on direct beam and assimilation of sunlit leaf area
        float VISPP  = (1. - SCV) * PARDIR / SINB;

        float FGRSUN = VISPP < 0 ? FGRSH : AMAX * (1. - (AMAX - FGRSH) *
            (1.- exp(-VISPP * EFF / fmaxf(2.0, AMAX)))/ (EFF * VISPP));

// fraction of sunlit leaf area (FSLLA) and local assimilation rate (FGL)
        float FSLLA  = exp(-KDIRBL * LAIC);
        float FGL    = FSLLA * FGRSUN + (1. - FSLLA) * FGRSH;

        FGROS += FGL * WGAUSS[i];
    }

    return FGROS * this->LAI();
}

float Leaf::Assimilate(Climate& climate, const float& DVS, const float& TMINRA)
{
    float TEMP  = 0.5 * (climate.Tmax + climate.Tmin);
    float DTEMP = 0.5 * (climate.Tmax + TEMP);
    float AMAX = AMAXTB.Interpolate(DVS) * TMPFTB.Interpolate(DTEMP);

    if(AMAX * LAI() == 0)
    {
        return 0;
    }

    float DTGA  = 0;

    for(size_t i = 0; i < XGAUSS.size(); ++i)
    {
        float HOUR   = 12.0 + 0.5 * DAYL * XGAUSS[i];
        float SINB   = fmaxf(0, SINLD + COSLD * cosf(2 * PI * (HOUR + 12.) / 24.));
        float PAR    = 0.5 * AVRAD * SINB * (1. + 0.4 * SINB) / DSINBE;
        float PARDIF = fminf(PAR, SINB * DIFPP);
        float PARDIR = PAR - PARDIF;
        
        DTGA += Rate(AMAX, EFFTB.Interpolate(DTEMP), 
            LAI(), KDIFTB.Interpolate(DVS), SINB, PARDIR, PARDIF) * WGAUSS[i];
    }

    return DTGA * DAYL * TMNFTB.Interpolate(TMINRA);
}