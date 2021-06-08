#include "Simulator.h"

Information::Information(TiXmlElement * configuration) :
    begin(nullptr), end(nullptr), parameter(nullptr)
{
    library = configuration->Attribute("name");
    location = configuration->Attribute("location");

    TiXmlElement * time = configuration->FirstChildElement();

    begin = new Date(time->Attribute("begin"));
    end = new Date(time->Attribute("end"));

    parameter = new Parameter(time->NextSiblingElement()->Attribute("final location"));

    TiXmlElement * item = time->NextSiblingElement()->NextSiblingElement()->FirstChildElement();
    while(item)
    {
        supports.push_back(item->Attribute("name"));
        item = item->NextSiblingElement();
    }
}

Information::~Information()
{
    delete begin;
    delete end;
    delete parameter;
}