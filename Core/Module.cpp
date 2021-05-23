#include "Simulator.h"

Module::Module()
{

}

Module::~Module()
{
    if(library)
    {
        delete library;
        library = nullptr;
    }
}

bool Module::Initialize(State * states)
{
    if(library)
    {
        delete library;
        library = nullptr;
    }

    current = libraries.begin();
    library = Factory(current);

    return true;
}

bool Module::Update(State * states)
{
    return library->Update(states);
}

bool Module::Finalize(State * states) 
{

}