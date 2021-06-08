#include "State.h"
#include "Parameter.h"
#include "XML/tinystr.h"

#if defined (_Win32)
#include <windows.h>

#elif defined(__APPLE__)
#include <dlfcn.h>

#elif defined(linux)

#endif

#include <list>
#include <array>
#include <iostream>
#include <algorithm>

#ifndef _SIMULATOR_
#define _SIMULATOR_
typedef  void * (* Creator)();

struct Count
{
    long count;
    void * handle;
    Creator creator;
};

struct Information
{
public:    
    Date * begin, * end;
    std::string library, location;
    std::list<std::string> supports;
    Parameter * parameter;

public:
    Information(TiXmlElement * configuration);
    ~Information();
};

class Module
{
private:
    std::map<std::string, Count>& counts;
    Type type;

private:
    std::list<Information> libraries;
    std::list<Information>::iterator current;
    IComponent * library;

private:
    Type Convert(const std::string& type);

    void Factory(const std::string& name, const std::string& location);
    void Release(const std::string& name);

public:
    bool Initialize(State * states);
    bool Update(State * states, Date * now);
    bool Finalize();

    bool Change(const std::string& library, const long& index, const std::string& name, const std::vector<float>& value);
    
    Module(std::map<std::string, Count>& counts, TiXmlElement * );
    ~Module();
};

class Simulator
{
private:
    static std::map<std::string, Count> counts;

private:
    Date * begin, * end;
    State * states;
    std::list<Module> modules;

private:
    bool Initialize(State * states);
    bool Finalize(State * states);

public:
    Simulator(const char* configuration);
    ~Simulator();

    void Simulate(const long& till);
    bool Change(const char* component, const long& index, const char* name, float* value, const long& size);
    bool Inquire(const char* name, const long& index, float ** value, long* size); 
};
#endif //!_SIMULATOR_
