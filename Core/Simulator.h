#include "Interfaces.h"
#include "State.h"
#include "Parameter.h"
#include "Component.h"
#include <list>

struct Date
{
    long year, month, day;
};

bool operator == (const Date& A, const Date& B);
Date& operator ++ (Date& A);

struct Information
{
    std::string library;
    Date begin, end;
    Parameter * parameter;
};

class Module
{
private:
    std::list<Information> libraries;
    std::list<Information>::iterator current;
    Component * library;

public:
    bool Initialize(State * states);
    bool Update(State * states);
    bool Finalize(State * states);

    Module();
    ~Module();
};

class Simulator
{
private:
    Date begin, end, now;
    State * states;
    std::list<Module> modules;

public:
    Simulator(const char* configuration);
    ~Simulator();

    void Simulate(const long& till);
    bool Change(const char* component, const long& index, const char* name, float* value, const long& size);
    bool Inquire(const char* name, const long& index, float ** value, long* size); 
};