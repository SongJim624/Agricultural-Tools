#include "Interfaces.h"

class Component : public IComponent
{
public:
    virtual ~Component();

    virtual bool Initialize(IState* istates, IParameter* iparameters) = 0;
    virtual bool Update(IState* istates) = 0;
    virtual bool Inquire(const std::string& name, std::vector<float>& value) = 0;

    virtual void Describe(const char * file);
    virtual void Convert(const char * parameters, const char *  xml);
};