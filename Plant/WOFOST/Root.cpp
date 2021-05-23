#include "Basic Structure.h"

void Root::Grow(const float& rate, const float& DVS, const float& dt)
{
    weight += (rate - weight * RDRRTB.Interpolate(DVS)) * dt;
    weight = fmaxf(0, weight);
}