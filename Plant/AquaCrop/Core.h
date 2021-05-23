#include <iostream>
#include <vector>
#include <list>
#include <unordered_map>
#include <map>
#include <string>

#include "Algorithms\Canopy.h"
#include "Algorithms\Biomass.h"
#include "Algorithms\HarvestIndex.h"
#include "Algorithms\Root.h"
#include "Algorithms\Stress.h"
#include "..\..\Tools\C++\Converter.h"
#include "Convert.h"

#ifndef _CORE_
#define _CORE_
template<typename T>
class Core
{
private:
	Parameter<T> parameters;
	State<T> states;
	Dependency<T> dependencies;

	Canopy<T>* canopy;
	Root<T>* root;
	Biomass<T>* biomass;
	HarvestIndex<T>* harvest;
	Stress<T>* stress;
private:
	int Day_Cal(int year, int month, int day)
	{
		std::map<int, double> table = {};
		table[1] = 0.0;
		table[2] = 31.0;
		table[3] = 59.25;
		table[4] = 90.25;
		table[5] = 120.25;
		table[6] = 151.25;
		table[7] = 181.25;
		table[8] = 212.25;
		table[9] = 243.25;
		table[10] = 273.25;
		table[11] = 304.25;
		table[12] = 334.25;

		return int(floor((year - 1901.0) * 365.25 + table[month] + day));
	}

public:
	Core(IDispatch* istates, IDispatch* iparameters)
		: parameters(Parameter<T>(iparameters)), 
		  states(State<T>(istates, parameters)), dependencies(Dependency<T>(istates, parameters)), 
		  canopy(nullptr), biomass(nullptr), harvest(nullptr), root(nullptr), stress(nullptr){}

	~Core() 
	{
		delete canopy; canopy = nullptr;
		delete root; root = nullptr;
		delete biomass; biomass = nullptr;
		delete harvest; harvest = nullptr;
		delete stress; stress = nullptr;
	}

	HRESULT Update(IDispatch* istates)
	{
		states.current++;
		if (states.current < parameters["sowingdate"]) { return S_OK;}
		states.DAP++;

		if (states["crop growth time"] > parameters["TS2M"] || states.death) { return S_OK; }
		
		WState wstates = WState(istates);
		dependencies.Update(wstates);

		states["crop growth time"] += 0.5 * dependencies.GDD;

		if (stress == nullptr) { stress = new Stress<T>(parameters); }
		stress->Update(states, dependencies);

		//Root begins to develop
		if (states["crop growth time"] > 0.5 * parameters["TS2E"] &&
			states["crop growth time"] < parameters["TS2E"])
		{
			if (root == nullptr) { root = new Root<T>(states, parameters); }
			root->Update(states, dependencies, *stress);
		}

		if (states["crop growth time"] > parameters["TS2E"])
		{
			//Emerge
			if (biomass == nullptr) { biomass = new Biomass<T>(states, parameters); }
			if (canopy == nullptr) { canopy = new Canopy<T>(states, parameters); }

			biomass->Update(states, dependencies, *stress, 
				canopy->Transpiration_Ability(states, dependencies, *stress));
			canopy->Update(states, dependencies, *stress);
			root->Update(states, dependencies, *stress);
		}

		if (states["crop growth time"] > parameters["TS2F"] &&
			states["crop growth time"] < parameters["TS2F"] + parameters["build"])
		{
			if (harvest == nullptr) { harvest = new HarvestIndex<T>(parameters, biomass->Brel(states)); }
			if (dependencies.trp > epslon) { harvest->Update(states, dependencies, *stress); };
		}

		if (abs(states["canopy cover"]) < epslon && canopy) { states.death = true; }

		states["crop growth time"] += 0.5 * dependencies.GDD;
	    return states.Update(wstates);
	}

	HRESULT Inquire(const std::string& name, IDispatch* istates)
	{
		WState wstates = WState(istates);

		if(name == "water sink ability")
		{
			return wstates.Receive(root == nullptr ? std::vector<T>{} :
				root->Sink_Ability(states, dependencies, *stress));
		}
		else if(name == "transpiration ability")
		{
			return wstates.Receive(canopy == nullptr ? 0.0 : 
				canopy->Transpiration_Ability(states, dependencies, *stress));
		}
		else
		{
			return S_FALSE;
		}
	}
};
#endif // !_CORE_