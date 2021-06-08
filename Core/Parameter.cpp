#include "Parameter.h"

Parameter::Parameter(const char * file)
{
    TiXmlDocument parameter(file);
    
    parameter.LoadFile();
    TiXmlElement * root = parameter.RootElement();

    TiXmlElement * section = root->FirstChildElement();

    while(section)
    {
        TiXmlElement * item = section->FirstChildElement();

        while(item)
        {
            std::string name = item->Attribute("name");
            parameters[name] = std::vector<float>();

            std::stringstream ss(item->Attribute("value"));

            float value = 0;
            while(ss << value)
            {
                parameters[name].push_back(value);

            }

            item = item->NextSiblingElement();
        }

        section = section->NextSiblingElement();
    }
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