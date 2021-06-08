#include "Plant.h"

bool EPIC_Plant::Update(IState * istates)
{
    HU = fmaxf(0.5 * (Tmax + Tmin) - Tbase, 0); 

    float PAR = 0.5 * Rad * (1 - exp(-0.65 * LAI));
    float RUE = 100 * CO2  / (CO2 + exp(bc1 - bc2 * CO2));
    float X1 = max(VPD -1 , -0.5);

    dDM = 0.001f * PAR * (RUE -WAVP * X1); 

    float HUF = HUI / (HUI + exp(ah(1,i) - ah(2,i) * HUI));
    float dLAI = LAI + dHUF * XLAI * sqrt(REG) * LAI / TLAI;

    LAI *=pow((1 - HUI) / (1 - HUID), ad);

    height = HMX * sqrt(HUF);

    root_depth = min(min(2.5 * RDmax * HUI, RDmax), soil_depth);

    RWT(l,i) += DRW * UTO;
    
    DRW = RW(i) - RW0(i);
    
    RW(i) = DM(i) * (ar1(i) * (1.-HUI(i)) + ar2(i) * HUI(i));
    
    UTO = UW(l) / AEP(i); DRW > 0.0;
    UTO = RWT(l,i)/RW0(i); DRW<0.0


    HI = F * (HIT(i)-HIMN(i))+HIMN(i);
    F=SWH(i)/(SWH(i)+exp(5.563-0.03155*SWH(i)));
    SWH(i)=sum(AEP(i)); 0.5<HUI(i)<1.0
    HIT(i) = HIP(i) * X2 / (X2 + exp(11.11- 0.1 * X2));
    X2 = 100 * HUI(i);

    Yield = HI * STL;
}