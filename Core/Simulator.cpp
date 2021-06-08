#include "Simulator.h"

Simulator::Simulator(const char * configuration)
{
    TiXmlDocument configurations(configuration);
    configurations.LoadFile();

    TiXmlElement * root = configurations.RootElement();

    TiXmlElement * time = root->FirstChildElement();
    begin = new Date(time->Attribute("begin"));
    end = new Date(time->Attribute("end"));

    TiXmlElement * module_information = time->NextSiblingElement()->FirstChildElement();    
    while(module_information)
    {
        modules.push_back(Module(counts, module_information));
        module_information = module_information->NextSiblingElement();
    }

    states = new State(time->NextSiblingElement()->NextSiblingElement());
}

Simulator::~Simulator()
{
    std::map<std::string, Count>::iterator  iter = counts.begin();

    while(true)
    {
        if(iter->second.count == 0)
        {
            iter->second.creator = nullptr;

#if defined(_Win32)
#include <windows.h>
            FreeLibrary(reinterpret_cast<HINSTANCE>(iter->second.handle));

#elif defined(__APPLE__)
#include <dlfcn.h>
            dlclose(iter->second.handle);

#elif defined (linux)

#endif
            iter = counts.erase(iter);
        }
        else
        {
            iter++;
        }

        if(iter == counts.end())
            return;
    }
}

bool Simulator::Initialize(State * states)
{
    states->now = begin;

    for(auto& iter : modules)
    {
        iter.Initialize(states);
    }
    
    return true;
}

bool Simulator::Finalize(State * states)
{
    for(auto&  iter : modules)
    {
        iter.Finalize();
    }

    states->Clean();
    
    return true;
}

void Simulator::Simulate(const long& till)
{
    if(Equal(states->now, begin))
    {
        Initialize(states);
    }

    for(long i = 0; i < till; ++i)
    {
        for(auto& module : modules)
        {
            module.Update(states, states->now);
        }

        if(Equal(states->now->Next(), end))
        {
            Finalize(states);
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
    try
    {
        std::vector<float> results = states->Inquire(std::string(name), index);
        *size = results.size();
        memcpy(*value, &results[0], *size * sizeof(float));
        return true;
    }
    catch(std::exception& e)
    {
        return false;
    }
}
