#include "Basic Structure.h"

float Plant::Assimilate(Climate& climate)
{
    return leaf->Assimilate(climate, DVS);


}

float Plant::Respirate(Climate& climate)
{
    float res = 0 ;

    for(auto organ : organs)
    {
        res += organ->Respirate(climate, DVS);
    }

    return res;
}

void Plant::Simulate(Climate& climate, const float& Tr)
{
    DVS += DVR * dt;

    float assimilation = Assimilate(climate) * Tr / trx;
    float GASS = assimilation - Respirate(climate);

    Partition(GASS);
}

void Plant::Partition(const float& assimilation)
{
// average temperature and average daytemperature
    float TEMP  = 0.5 * (climate.Tmax + climate.Tmin);
    float DTEMP = 0.5 * (climate.Tmax + TEMP);

// seven day running average of minimum temperature
/*
    IF (ISTATE.GE.3) THEN
//           shift minimum temperatures to the left

            DO 20 I1=1,6
               TMNSAV(I1) = TMNSAV(I1+1)
20          CONTINUE
            TMNSAV(7) = TMIN

*           calculate new average minimum temperature
            TMINRA = 0.
            I2 = 0
            DO 30 I1=1,7
               IF (TMNSAV(I1).NE.-99.) THEN
                  TMINRA = TMINRA+TMNSAV(I1)
                  I2 = I2+1
               END IF
30          CONTINUE
            TMINRA = TMINRA/REAL(I2)
         END IF
*/
/*
// model was started at sowing
    float DTSUME = LIMIT (0., TEFFMX-TBASEM, TEMP-TBASEM);

            DTSUM = 0.
            DVR = 0.
         ELSE
*/
//           emergence has taken place
// 2.19      phenological development rate photoperiodic daylength
//            CALL ASTRO (IDAY,LAT,AVRAD,
//     &                  DAYL,DAYLP,SINLD,COSLD,DIFPP,ATMTR,DSINBE)

// increase in temperature sum
    float DTSUM = DTSMTB.Interpolate(TEMP);

    if(DVS < 1)
    {
// effects of daylength and temperature on development during vegetative phase
        int DVRED = 1.
        if(IDSL.GE.1)
        {
            DVRED = LIMIT(0.,1.,(DAYLP-DLC)/(DLO-DLC))
            DVR = DVRED * DTSUM/TSUM1
        }
        else
        {
//  development during generative phase
            DVR = DTSUM/TSUM2
        }
    }

// 2.20   daily dry matter production



// correction for low minimum temperature potential assimilation in kg CH2O per ha

        float DTGA  = Assimilate(climate, DVS, TMINRA);
        float PGASS = DTGA * 30./44.; 
//        water stress reduction
        float GASS = PGASS * Tr / trx;

// respiration and partitioning of carbohydrates between growth and maintenance respiration
        float RMRES = Respirate(climate, DVS);
         MRES  = MIN (GASS, RMRES*TEFF)
         ASRC  = GASS-MRES

//        DM partitioning factors, and dry matter increase
    float FR  = FRTB.Interpolate(DVS);
    float FL  = FLTB.Interpolate(DVS);
    float FS  = FSTB.Interpolate(DVS);
    float FO  = FOTB.Interpolate(DVS);

    float CVF = 1./((FL/CVL+FS/CVS+FO/CVO)*(1.-FR)+FR/CVR)
    float DMI = CVF*ASRC

// check on partitioning
    if(absf(FR+(FL+FS+FO)*(1.-FR) - 1.).GT.0.0001)
    {
        exit(-1);
    }

// check on carbon balance
         
    if(absf((GASS-MRES-(FR+(FL+FS+FO)*(1.-FR))*DMI/CVF)/MAX (0.0001,GASS)) > 0.0001)
    {
        exit(-1);
    }

    for(auto iter : organs)
    {
        iter->Grow(ASRC * FR);
    }

// 2.21   growth rate by plant organ
// 2.21.1 growth rate roots and aerial parts

    float ADMI = (1- FRTB.Interpolate(DVS)) * DMI;
    root->Grow(FRTB.Interpolate(DVS) * DMI, DVS, dt);

// 2.21.2 growth rate leaves
//*        weight of new leaves
    GRLV = FL*ADMI

//        death of leaves due to water stress or high LAI
    DSLV1 = WLV*(1.-TRA/TRAMX)*PERDL
    LAICR = 3.2/KDIF
    DSLV2 = WLV*LIMIT (0., 0.03, 0.03*(LAI-LAICR)/LAICR)
    DSLV  = MAX (DSLV1, DSLV2)

// determine extra death due to exceeding of life span of leaves
// leaf death is imposed on array until no more leaves have to 
// die or all leaves are gone

         REST = DSLV*DELT
         I1   = ILVOLD

100      IF (REST.GT.LV(I1).AND.I1.GE.1) THEN
            REST = REST-LV(I1)
            I1   = I1-1
            GOTO 100
         END IF

*        check if some of the remaining leaves are older than SPAN,
*        sum their weights

         DALV = 0.
         IF (LVAGE(I1).GT.SPAN.AND.REST.GT.0.AND.I1.GE.1) THEN
            DALV = LV(I1)-REST
            REST = 0.
            I1   = I1-1
         END IF

110      IF (I1.GE.1.AND.LVAGE(I1).GT.SPAN) THEN
            DALV = DALV+LV(I1)
            I1   = I1-1
         GOTO 110
         END IF

         DALV = DALV/DELT

*        death rate leaves and growth rate living leaves
         DRLV = DSLV+DALV

*        physiologic ageing of leaves per time step
         FYSDEL = MAX (0., (TEMP-TBASE)/(35.-TBASE))
         SLAT   = AFGEN (SLATB, ILSLA, DVS)

*        leaf area not to exceed exponential growth curve
         IF (LAIEXP.LT.6.) THEN
            DTEFF  = MAX (0.,TEMP-TBASE)
*            GLAIEX = LAIEXP*EXP(RGRLAI*DTEFF)
            GLAIEX=LAIEXP*RGRLAI*DTEFF
*           source-limited increase in leaf area
            GLASOL = GRLV*SLAT
*           sink-limited increase in leaf area
            GLA    = MIN (GLAIEX, GLASOL)
*           adjustment of specific leaf area of youngest leaf class
            IF (GRLV.GT.0.) SLAT = GLA/GRLV
         END IF

// 2.21.3 growth rate stems
    stem->Grow(FS * ADMI, DVS, dt);

// 2.21.4 growth rate storage organs
    organ->Grow(FO * ADMI, DVS, dt);


}

void Plant::Emergence()
{

}