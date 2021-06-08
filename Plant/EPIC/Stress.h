#include "Plant.h"

float EPIC_Plant::Water_Stress(const float& AEP, const float& EP)
{
    return AEP / EP;
}

float EPIC_Plant::Nutrient_Stress(const float& U1, const float& )
{
    float SNS = 200* UN1 / UNO;
    return SNS / (SNS+exp(4.065-0.0535 * SNS));

    return ;
}

float EPIC_Plant::Temperature_Stress()
{
    TS(i) = sin(1.5707 * RTO); 0.0<RTO<2.0
    TS(i) = 0.0; RTO<0.0 or RTO>2.0 
    RTO = (TX-TBSC(i)) / (TOPC(i) - TBSC(i));

    return ;
}

float Aeration_Stress()
{
    AS(i)=1.0-SAT / (SAT + exp(2.901-0.0387*SAT)); SAT>0.0 
    AS(i)=1.0; 
    SAT<0.0 SAT=100.*(ST1/PO1-CAF(i))/(1.0-CAF(i));
}