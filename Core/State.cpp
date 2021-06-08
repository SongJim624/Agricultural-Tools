#include "State.h"

State::State(TiXmlElement * element)
{
    TiXmlElement * item = element->FirstChildElement();

    while(item)
    {
        states[item->Attribute("name")] = {};
        item = item->NextSiblingElement();
    }
}

void State::Align()
{
    long days = 0;

    for(auto& iter : states)
    {
        days = fmax(days, iter.second.size());
    }

    for(auto& iter : states)
    {
        while(iter.second.size() < days)
        {
            iter.second.push_back({});
        }
    }
}

std::vector<float> State::Inquire(const std::string& name, const long& index)
{
    return * std::next(states[name].begin(), index - 1);
}

void State::Switch(const Type& type, const std::list<std::string>& supports, IComponent * pointer)
{
    dictionary[type].clear();

    for(auto iter : supports)
    {
        dictionary[type][iter] = pointer;
    }

    Align();
}

std::vector<float> State::Inquire(const std::string& name)
{
    if(name == "year")
        return std::vector<float>{float(now->year)};
    
    if(name == "month")
        return std::vector<float>{float(now->month)};

    if(name == "day")
        return std::vector<float>{float(now->day)};

    if(states.find(name) != states.end())
        return states[name].size() == 0 ? std::vector<float>(0) : * states[name].rbegin();

    for(auto& iter : dictionary)
    {
        if(iter.second.find(name) != iter.second.end())
        {
            return iter.second[name]->Inquire(name);
        }
    }

    return std::vector<float>(0);
//        throw std::range_error e;       
}
void State::Write(const std::string& name, const std::vector<float>& value)
{
    states[name].push_back(value);
}
