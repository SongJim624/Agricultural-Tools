#include "Climate.h"

AquaCrop_Climate::AquaCrop_Climate() :
    Tmaxs(nullptr), Tmins(nullptr), Pres(nullptr), ETos(nullptr), length(0), today(0)
{}

AquaCrop_Climate::~AquaCrop_Climate()
{}

Component * AquaCrop_Climate::Create()
{
    return reinterpret_cast<Component *>(new AquaCrop_Climate());
}

std::vector<float> AquaCrop_Climate::Inquire(const std::string& name)
{
/*
* In fact, this fucntion would never be called 
* bacause all the data have been writen to the states component
* Hence, once this function is called. The library would crash and report errors.
*/
    std::abort();
    return std::vector<float>();
}