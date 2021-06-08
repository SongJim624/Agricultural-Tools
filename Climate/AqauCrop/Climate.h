#include "../../Core/Component.h"

#ifndef _AQUACROP_CLIMATE_
#define _AQUACROP_CLIMATE_
class AquaCrop_Climate : public Component
{
private:
    float * Tmaxs, * Tmins, * Pres, * ETos;
    long length, today;

private:
    AquaCrop_Climate();

public:
    static Component * Create();
    ~AquaCrop_Climate();

   virtual bool Initialize(IState * states, IParameter * iparameters);
    virtual bool Update(IState * istates);
    virtual std::vector<float> Inquire(const std::string& name);

    virtual void Discribe(const char * file);
    virtual void Convert(const char* parameters, const char* xml);
};
#endif //!_AQUACROP_CLIMATE_