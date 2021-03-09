#include "Basic Structure.h"

void Organ::Grow(const float& mass, const float& DVS)
{
    weight += mass * conversion;
}

float Organ::Respirate(Climate& climate, const float& DVS)
{
    return weight * powf(Q10, 0.05 * ( climate.Tmax + climate.Tmin - 50)) *
        respiration * reduction.Interpolate(DVS);
}