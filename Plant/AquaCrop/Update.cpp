#include "Plant.h"

bool AquaCrop_Plant::Update(IState * istates)
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