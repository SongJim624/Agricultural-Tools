#include "Parameter.h"

Parameter::Parameter(const char * file)
{
    TiXmlDocument parameter(file);
    parameter.LoadFile();

}

Parameter::~Parameter(){}

std::vector<float> Parameter::Inquire(const std::string& name)
{
    return parameters[name];
}

bool Parameter::Change(const std::string& name, const std::vector<float>& value)
{
    if(parameters.find(name) == parameters.end())
    {
        return false;
    }
    else
    {
        parameters[name] = value;
        return true;
    }
}