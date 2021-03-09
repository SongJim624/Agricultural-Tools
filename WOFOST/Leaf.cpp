#include "Basic Structure.h"

void Leaf::Grow(const float& mass)
{
    float dt;

    for(auto& iter : time)
    {
        iter += dt;
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
//     absorbed diffuse radiation (VISDF),light from direct
//     origine (VIST) and direct light(VISD)
          float VISDF = (1. - REFS) * PARDIF * KDIF * exp(-KDIF * LAIC);
          float VIST = (1. - REFS) * PARDIR * KDIRT * exp(-KDIRT * LAIC);
          float VISD   = (1.-SCV) *PARDIR*KDIRBL* exp(-KDIRBL*LAIC);
//     absorbed flux in W/m2 for shaded leaves and assimilation
          float VISSHD = VISDF + VIST - VISD;
          float FGRSH  = AMAX * (1.- exp(-VISSHD * EFF / fmaxf(2.0,AMAX)));
//     direct light absorbed by leaves perpendicular on direct
//     beam and assimilation of sunlit leaf area
          float VISPP  = (1. - SCV) * PARDIR / SINB;
      
          float FGRSUN = VISPP < 0 ? FGRSH : AMAX * (1. - (AMAX - FGRSH) *
            (1.- exp(-VISPP * EFF / fmaxf(2.0, AMAX)))/ (EFF * VISPP));

//     fraction of sunlit leaf area (FSLLA) and local
//     assimilation rate (FGL)
          float FSLLA  = exp(-KDIRBL * LAIC);
          float FGL    = FSLLA * FGRSUN + (1. - FSLLA) * FGRSH;
//     integration
          FGROS += FGL * WGAUSS[i];
      }
      return FGROS * this->LAI();
}

float Leaf::Assimilate(Climate& climate)
{
//      SUBROUTINE TOTASS (DAYL  , AMAX , EFF  , LAI , KDIF, AVRAD, DIFPP,
//     &                   DSINBE, SINLD, COSLD, DTGA)

//     calculation of assimilation is done only when it will not be zero
//     (AMAX >0, LAI >0)
    float DTGA  = 0;
    float LAI = this->LAI();
//float AVRAD, float DIFPP, float AMAX, float EFF, float KDIF, float DSINBE, float LAI, float DAYL, float COSLD, float SINLD

    float AMAX = AMAXTB.Interpolate(DVS);

    if(AMAX > 0 && LAI > 0)
    {
        for(size_t i = 0; i < XGAUSS.size(); ++i)
        {
            float HOUR   = 12.0 + 0.5 * DAYL * XGAUSS[i];
            float SINB   = fmaxf(0, SINLD + COSLD * cosf(2 * PI * (HOUR + 12.) / 24.));
            float PAR    = 0.5 * AVRAD * SINB * (1. + 0.4 * SINB) / DSINBE;
            float PARDIF = fminf(PAR, SINB * DIFPP);
            float PARDIR = PAR - PARDIF;
            
            DTGA += Rate(AMAXTB.Interpolate(DVS), EFF,LAI, KDIF, SINB, PARDIR, PARDIF) * WGAUSS[i];
        }
    }

    return DTGA * DAYL;
}