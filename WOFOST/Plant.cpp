#include "Basic Structure.h"

void Plant::Simulate(Climate& climate, const float& Tr)
{
    float assimilation = Assimilate(climate) * Tr / Trx;
    float GASS = assimilation - Respirate(climate);

    Partition(GASS);
}