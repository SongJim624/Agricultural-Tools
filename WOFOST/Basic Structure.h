#include <list>
#include <array>

class Table
{
    long length;
    float * data;

public:
    Table(std::list<float>& X, std::list<float>& Y);
    ~Table();

    float Interpolate(const float& x);
};

struct Timer
{
    long year, month, day, hour, minute, second;
    float ms;
};

struct Location
{
    float latitude, longtitude, altitude;
};

float Day_Length(const Timer& time, const Location& location);

struct Climate
{
    float Tmax, Tmin, ETo, Rad, Par;
};

class Organ
{
protected:
    float Q10, respiration, conversion;
    Table reduction;

protected:
    float weight;

public:
    virtual void Grow(const float& rate, const float& DVS, const float& dt);
    virtual float Respirate(Climate& climate, const float& DVS);
};

class Leaf : public Organ
{
// assimilation
    Table KDIFTB, EFFTB, AMAXTB, TMPFTB, TMNFTBZ;

// green area
    Table SLATB, SSATB;
    float SPA, SPAN, TBASE;
// death rate of leaves due to water stress    
    float PERDL;

// maximum relative increase in LAI [ha ha-1 d-1]
    float RGRLAI; 

private:
    std::list<float> leaf;
    std::list<float> time;

    const std::array<float, 3> XGAUSS{0.1127017, 0.5000000, 0.8872983};
    const std::array<float, 3> WGAUSS{0.2777778, 0.4444444, 0.2777778};
    const float PI = 3.1415926;

private:
    float Rate(float LAI, float AMAX, float EFF, 
        float PARDIF, float PARDIR, float SINB, float KDIF);

public:
    float Assimilate(Climate& climate, const float& DVS, const float& TMINRA);
    virtual void Grow(const float& mass);
    float LAI();
};

class Stem
{
private:
//rel. death rate of stems
    Table RDRSTB;
//rel. maint. resp. rate stems [kg CH2O kg-1 d-1]
    float RMS;

    void Grow(const float& mass);


};

class Root : public Organ
{
private:
//rel. death rate of roots 
    Table RDRRTB;

    virtual void Grow(const float& rate, const float& DVS, const float& dt);

    std::list<float> sink(std::list<float>& position, std::list<float>& theta);
};

class Plant
{
private: 
    Leaf * leaf;
    Stem * stem;
    Organ* organ;
    Root * root;

private:
// emergence
    float TBASEM, TEFFMX, TSUMEM;
// phenology
int IDSL;

/*
TSUM1 : Total Time to Anthesiss
TSUM2 : Total Time to Maturity
*/
    float DLO, DLC, TSUM1, TSUM2, DVSI, DVSEND;
    Table DTSMTB;
// partitioning
    Table FRTB, FLTB, FSTB, FOTB;

private:
    float DVS, TSUM;

private:

    float trx;
private:
    std::list<Organ*> organs;

private:
    float Assimilate(Climate& climate);
    float Respirate(Climate& climate);
    void Partition(const float& assimilation);

    void Emergence();

public:
//    Plant();
//    Plant(State& states);
//    ~Plant();

    void Simulate(Climate& climate, const float& Tr);
};

/*
** initial
TDWI     =  20.00    ! initial total crop dry weight [kg ha-1]
** ! Not used as imput by WOF6_0 model
LAIEM    =   0.02604 ! leaf area index at emergence [ha ha-1]

** water use
CFET     =   1.00   ! correction factor transpiration rate [-]
DEPNR    =   4.5    ! crop group number for soil water depletion [-]
IAIRDU   =   0      ! air ducts in roots present (=1) or not (=0)
*/