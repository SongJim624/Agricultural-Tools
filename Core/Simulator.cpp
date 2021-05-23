#include "Simulator.h"

Simulator::Simulator(const char * configuration)
{
    TiXmlDocument configurations(configuration);
    configurations.LoadFile();




}

Simulator::~Simulator(){}

void Simulator::Simulate(const long& till)
{
    if(now == end)
    {
        for(auto& iter : modules)
        {
            iter.Finalize();
        }
    }

    if(now == begin)
    {
        for(auto& iter : modules)
        {
            iter.Initialize(states);
        }
    }

    while(true)
    {
        for(auto& module : modules)
        {
            module.Update(states);
        }

        if(now == )
        {
            return;
        }
    }
}

bool Simulator::Change(const char * component, const long& index, const char * name,  float * value,const long& size)
{
    std::vector<float> valuev(value, value + size);
    bool status = false;

    for(auto & iter : modules)
    {
        status = iter.Change(component, index, name, valuev);
        if(status)
        {
            return status;
        }
    }

    return status;
}

bool Simulator::Inquire(const char * name, const long& index, float ** value, long * size)
{
    std::vector<float> results;
    bool status = states->Inquire(std::string(name), results);

    if(status)
    {
        *size = results.size();
        *value = new float[*size];

        for(long i = 0; i < results.size(); ++i)
        {
            *value[i] = results[i];
        } 
    }

    return status;
}