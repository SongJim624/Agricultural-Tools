#include <string>
#include <vector>
#include <unordered_map>
#include <map>
#include <list>
#include "../../Tools/C++/Converter.h"

#ifndef _INFORMATION_
#define _INFORMATION_
constexpr double epslon = 1e-6;

struct Information
{
	std::string name;
    std::string size;
    std::string type;
};

template<typename T>
class Parameter
{
private:
    std::map<std::string, T> parameters;

public:
    const T& operator[](const std::string& name)
    {
        return parameters[name];
    }

    Parameter(IDispatch* iparameters)
    {
        WState wparameters = WState(iparameters);

        std::list<std::string> name_list = {};

        auto info = Information();
        for (auto it = info.begin(); it != info.end(); ++it)
        {
            for (auto iter = it->second.begin(); iter != it->second.end(); ++iter)
            {
                name_list.push_back(iter->name);
            }
        }

        for (auto it = name_list.begin(); it != name_list.end(); ++it)
        {
            T value = 0;
            HRESULT hr = wparameters.Inquire(*it, value);
            parameters[*it] = value;
        }
    }

    static auto Information()
    {
        std::unordered_map<std::string, std::list<::Information>> information;
        
        std::list<::Information> pheno = {};
        pheno.push_back(::Information{"sowingdate", "single", "integer"});
        pheno.push_back(::Information{"Tbase", "single", "float"});
        pheno.push_back(::Information{"Tupper", "single", "float"});
        pheno.push_back(::Information{"TS2E", "single", "float"});
        pheno.push_back(::Information{"TS2R", "single", "float"});
        pheno.push_back(::Information{"TS2F", "single", "float"});
        pheno.push_back(::Information{"TS2S", "single", "float"});
        pheno.push_back(::Information{"TS2M", "single", "float"});
        pheno.push_back(::Information{"FL", "single", "float"});
        pheno.push_back(::Information{"build", "single", "float"});
        information["pehnomena"] = pheno;

        //Canopy
        std::list<::Information> canopy = {};
        canopy.push_back(::Information{ "CCo", "single", "float" });
        canopy.push_back(::Information{ "CCx", "single", "float" });
        canopy.push_back(::Information{ "CGC", "single", "float" });
        canopy.push_back(::Information{ "CDC", "single", "float" });
        canopy.push_back(::Information{ "kcbtrx", "single", "float" });
        canopy.push_back(::Information{ "fage", "single", "float" });
        canopy.push_back(::Information{ "fdecline", "single", "float" });
        canopy.push_back(::Information{ "alpha", "single", "float" });
        canopy.push_back(::Information{ "beta", "single", "float" });
        information["canopy"] = canopy;

        //Biomass  
        std::list<::Information> biomass = {};  
        biomass.push_back(::Information{"WP", "single", "float"});
        biomass.push_back(::Information{"sink", "single", "float"});
        biomass.push_back(::Information{"fyield", "single", "float"});
        information["biomass"] = biomass;

        //HI   
        std::list<::Information> harvest = {};
        harvest.push_back(::Information{"HIo", "single", "float"});
        harvest.push_back(::Information{"dHImax", "single", "float"});
        harvest.push_back(::Information{"dHIante", "single", "float"});
        harvest.push_back(::Information{"fexcess", "single", "float"});
        harvest.push_back(::Information{"a", "single", "float"});
        harvest.push_back(::Information{"b", "single", "float"});
        harvest.push_back(::Information{ "CC_remain", "single", "float" });
        information["harvest index"] = harvest;

        //Root
        std::list<::Information> root = {};
        root.push_back(::Information{"Zo", "single", "float"});
        root.push_back(::Information{"Zx", "single", "float"});
        root.push_back(::Information{"SF_root", "single", "float"});
        root.push_back(::Information{"SF_proot", "single", "float"});   
        root.push_back(::Information{"SxTop", "single", "float"});
        root.push_back(::Information{"SxBot", "single", "float"});
        information["root"] = root;

        //Water Stress
        std::list<::Information> water_str = {};
        
        
        water_str.push_back(::Information{"ztop", "single", "float"});
        water_str.push_back(::Information{"fadj", "single", "float"});

        water_str.push_back(::Information{"w_exp_upper", "single", "float"});
        water_str.push_back(::Information{"w_exp_lower", "single", "float"});
        water_str.push_back(::Information{"SF_exp", "single", "float"});

        water_str.push_back(::Information{"w_sto_upper", "single", "float"});
        water_str.push_back(::Information{"SF_sto", "single", "float"});

        water_str.push_back(::Information{"w_sen_upper", "single", "float"});
        water_str.push_back(::Information{"SF_sen", "single", "float"});

        water_str.push_back(::Information{"w_pol_upper", "single", "float"});
        water_str.push_back(::Information{"w_aer_upper", "single", "float"});
        information["water stress"] = water_str;

        //temperature stress
        std::list<::Information> heat_str = {};
        heat_str.push_back(::Information{"h_pol", "single", "float"});
        heat_str.push_back(::Information{"c_pol", "single", "float"});
        heat_str.push_back(::Information{"c_sto", "single", "float"});
        information["temperature stress"] = heat_str;

        //initial condition
        std::list<::Information> initial = {};
        initial.push_back(::Information{"crop growth time", "single", "float"});
        initial.push_back(::Information{"canopy cover", "single", "float"});
        initial.push_back(::Information{"biomass", "single", "float"});
        initial.push_back(::Information{"root depth", "single", "float"});
        initial.push_back(::Information{"harvest index", "single", "float"});
        initial.push_back(::Information{ "yield", "single", "float"});
        information["initial condition"] = initial;

        return information;
    }
};

template<typename T>
class State
{
private:
    std::map<std::string, T> states;

public:
    bool belighting, death;
    int current, DAP;

public:
    State(IDispatch* istates, Parameter<T>& parameters) : death(false), belighting(false), DAP(-1)
    {
        WState wstates = WState(istates);

        int year = 0, month = 0, day = 0;
        wstates.Inquire("year", year);
        wstates.Inquire("month", month);
        wstates.Inquire("day", day);
        current = Day_Cal(year, month, day);

        std::list<std::string> name_list = {"canopy cover", "biomass", "root depth", "yield", "harvest index", "crop growth time"};

        for(auto iter = name_list.begin(); iter!= name_list.end(); ++iter)
        {
            T value = 0.0;
            HRESULT hr = wstates.Inquire(*iter, value);

            if(hr == S_FALSE)
            {
                value = max(parameters[*iter], 0.0);
                hr = wstates.Write(*iter, value);
            }

            states[*iter] = value;
        }
    }

    T& operator[](const std::string& name) { return states[name]; }

    static auto Information()
    {
        std::list<::Information> list = {};
        list.push_back(::Information{ "canopy cover", "single", "float" });
        list.push_back(::Information{ "biomass", "single", "float" });
        list.push_back(::Information{ "root depth", "single", "float" });
        list.push_back(::Information{ "yield", "single", "float" });
        list.push_back(::Information{ "crop growth time", "single", "float" });
        list.push_back(::Information{ "days after planted", "single", "integer" });
        list.push_back(::Information{ "harvest index", "single", "float" });

        return list;
    }

    HRESULT Update(WState& wstates)
    {
        states["yield"] = states["biomass"] * 0.01 * states["harvest index"];
        for (auto iter = states.begin(); iter != states.end(); ++iter)
        {
            wstates.Write(iter->first, iter->second);
        }

        return wstates.Write("days after planted", DAP);
    }
};

template<typename T>
class Dependency
{
public:
    std::vector<T> theta, compart, Sat, FC, PWP;
    T Tmax, Tmin, ETo, CO2, trp, GDD;

private:
    const T Tbase, Tupper;

private:
    void GDD_Cal()
    {
        T t_max = max(min(Tmax, Tupper), Tbase);
        T t_min = min(Tmin, Tupper);

        GDD = max(0.5 * (Tmax + Tmin), Tbase) - Tbase;
    }

public:
    Dependency(IDispatch* istates, Parameter<T>& parameters)
        : Tbase(parameters["Tbase"]), Tupper(parameters["Tupper"])
    {
        Update(WState(istates));
    }

    void Update(WState& wstates)
    {
        HRESULT hr = wstates.Inquire("soil compartments", compart);
        hr = wstates.Inquire("soil water profile", theta);
        hr = wstates.Inquire("soil water content at field capacity", FC);
        hr = wstates.Inquire("soil water content at permanent wilting point", PWP);
        hr = wstates.Inquire("soil water content at saturation", Sat);
        hr = wstates.Inquire("daily max air temperature", Tmax);
        hr = wstates.Inquire("daily min air temperature", Tmin);
        hr = wstates.Inquire("daily reference evapotranspiration", ETo);
        hr = wstates.Inquire("daily carbon dioxide concentration", CO2);
        hr = wstates.Inquire("transpiration", trp);

        GDD_Cal();
    }

    static auto Information()
    {
        std::list<::Information> dep_list(0);

        dep_list.push_back(::Information{ "soil compartments", "array", "float" });
        dep_list.push_back(::Information{ "soil water profile", "array", "float"});
        dep_list.push_back(::Information{ "soil water content at field capcaity", "array", "float" });
        dep_list.push_back(::Information{ "soil water content at pernament wilting point", "array", "float" });

        dep_list.push_back(::Information{ "daily max air temperature", "single", "float" });
        dep_list.push_back(::Information{ "daily min air temperature", "single", "float" });
        dep_list.push_back(::Information{ "daily refenence evapotranspiration", "single", "float" });
        dep_list.push_back(::Information{ "transpiration", "single", "float" });
        dep_list.push_back(::Information{ "daily carbon dioxide concentration", "single", "float" });
        
        return dep_list;
    }
};

template<typename T>
class Support
{
public:
    static auto Information()
    {
        std::list<::Information> out_list(0);

        out_list.push_back(::Information{ "water sink ability", "array", "float"});
        out_list.push_back(::Information{ "transpiration ability", "single", "float" });

        return out_list;
    }    
};

template<typename T>
void Describe(const std::string& path)
{
    TiXmlDocument doc = TiXmlDocument();

    TiXmlElement* root = new TiXmlElement("Description");
    doc.LinkEndChild(root);
    //Parameters
    TiXmlElement* parameters = new TiXmlElement("Parameters");
    auto info = Parameter<float>::Information();

    for (auto iter = info.begin(); iter != info.end(); ++iter)
    {
        TiXmlElement* section = new TiXmlElement("section");
        section->SetAttribute("name", iter->first.c_str());

        for (auto it = iter->second.begin(); it != iter->second.end(); ++it)
        {
            TiXmlElement* item = new TiXmlElement("item");
            item->SetAttribute("name", it->name.c_str());
            item->SetAttribute("size", it->size.c_str());
            item->SetAttribute("type", it->type.c_str());

            section->LinkEndChild(item);
        }
        parameters->LinkEndChild(section);
    }
    root->LinkEndChild(parameters);
    //States
    TiXmlElement* states = new TiXmlElement("States");
    auto info_states = State<float>::Information();
    for (auto iter = info_states.begin(); iter != info_states.end(); ++iter)
    {
        TiXmlElement* item = new TiXmlElement("item");

        item->SetAttribute("name", iter->name.c_str());
        item->SetAttribute("size", iter->size.c_str());
        item->SetAttribute("type", iter->type.c_str());

        states->LinkEndChild(item);
    }
    root->LinkEndChild(states);
    //Dependencies
    TiXmlElement* dependencies = new TiXmlElement("Dependencies");
    auto info_dependencies = Dependency<float>::Information();
    for (auto iter = info_dependencies.begin(); iter != info_dependencies.end(); ++iter)
    {
        TiXmlElement* item = new TiXmlElement("item");

        item->SetAttribute("name", iter->name.c_str());
        item->SetAttribute("size", iter->size.c_str());
        item->SetAttribute("type", iter->type.c_str());

        dependencies->LinkEndChild(item);
    }
    root->LinkEndChild(dependencies);

    //Supports
    TiXmlElement* supports = new TiXmlElement("Supports");
    auto info_supports = Support<float>::Information();
    for (auto iter = info_supports.begin(); iter != info_supports.end(); ++iter)
    {
        TiXmlElement* item = new TiXmlElement("item");

        item->SetAttribute("name", iter->name.c_str());
        item->SetAttribute("size", iter->size.c_str());
        item->SetAttribute("type", iter->type.c_str());

        supports->LinkEndChild(item);
    }
    root->LinkEndChild(supports);

    doc.SaveFile(path.c_str());
}
#endif //!_INFORMATION_
