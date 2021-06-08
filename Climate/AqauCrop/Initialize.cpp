#include "Climate.h"

bool AquaCrop_Climate::Initialize(IState * istates, IParameter * iparameters)
{
    std::vector<float> value;
    istates->Inquire("year", value);
    istates->Inquire("month", value);
    istates->Inquire("day", value);

}