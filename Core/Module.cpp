#include "Simulator.h"

Module::Module(std::map<std::string, Count>& counts, TiXmlElement * configurations)
    : counts(counts), library(nullptr)
{
    type = Convert(configurations->Attribute("type"));
    TiXmlElement * information = configurations->FirstChildElement();

    while(information)
    {
        libraries.push_back(Information(information));
        information = information->NextSiblingElement();
    }

    current = libraries.begin();
}

Module::~Module()
{
/*
* This function is to cope with the situation that the program stops 
* even though the simulation has not run to the end, namely, the library is not normaly released.
* If the library is released normaly, the library should be nullptr. 
* Otherwise, call the Release function to release the library before destroy the instance of Module.
*/  
    if(library)
    {
        Release(current->library);
    }
}

Type Module::Convert(const std::string& type)
{
    if(type == "climate")
    {
        return Type(1);
    }
    else if(type == "plant")
    {
        return Type(2);
    }
    else if(type == "environment")
    {
        return Type(3);
    }
    else
    {
        return Type(4);
    }
}

void Module::Factory(const std::string&name, const std::string& location)
{
    if(counts.find(name) == counts.end())
    {        
#if defined(_Win32)
        HINSTANCE handle = LoadLibrary(location.c_str());
        if(!handle){ exit(-1); }
        counts[name].handle = reinterpret_cast<void *>(handle);
        counts[name].creator = (Creator) GetProcAddress(handle, "Create");

#elif defined(__APPLE__)
        void * handle = dlopen(location.c_str(), 0);
        if(!handle){ exit(-1); }
        counts[name].handle = handle;
        counts[name].creator = reinterpret_cast<Creator>(dlsym(handle, "Create"));

#elif define(linux)

#endif
    }

    if(!counts[name].creator)
    { 
        exit(-1); 
    }

    library = reinterpret_cast<IComponent *>( counts[name].creator());
    counts[name].count++;
}

void Module::Release(const std::string& name)
{
    counts[name].count--;
    delete library;
    library = nullptr;
}

bool Module::Initialize(State * states)
{
    Factory(current->library, current->library);
    return library->Initialize(states, current->parameter);
}

bool Module::Update(State * states, Date * now)
{
    if(!library->Update(states))
    {
        return false;
    }
    
    if(Equal(now, current->end))
    {
        Release(current->library);
        current++;
        Factory(current->library, current->location);
        library->Initialize(states, current->parameter);
        states->Switch(type, current->supports, library);
    }

    return true;
}

bool Module::Finalize() 
{
    Release(current->library);
    current = libraries.begin();
    return true;
}

bool Module::Change(const std::string& library, const long& index, const std::string& name, const std::vector<float>& value)
{
    long count = 0;
    
    for(auto& iter : libraries)
    {
        if(iter.library == library)
        {
            count++;
        }
        
        if(count == index)
        {
            return iter.parameter->Change(name, value);
        }
    }
    
    return false;
}
