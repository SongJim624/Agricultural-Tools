#include <string>
#include <vector>
#include <map>
#include "XML/tinyxml.h"

#ifndef _INTERFACES_
#define _INTERFACES_
class IState
{
public:
    virtual ~IState();

    virtual bool Inquire(const std::string& name, std::vector<float>& value) = 0;
    virtual bool Write(const std::string& name, const std::vector<float>& value) = 0;
};

class IParameter
{
public:
    virtual ~IParameter();

    virtual std::vector<float> Inquire(const std::string& name) = 0;
};

class IComponent
{
public:
    virtual ~IComponent();

    virtual bool Initialize(IState* istates, IParameter* iparameters) = 0;
    virtual bool Update(IState* istates) = 0;
    virtual bool Inquire(const std::string& name, std::vector<float>& value) = 0;
};
#endif //!_INTERFACES_



