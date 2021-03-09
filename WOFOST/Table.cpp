#include "Basic Structure.h"

Table::Table(std::list<float>& X, std::list<float>& Y)
    : length(2 * X.size()), data(new float[2 * length])
{
    long i = 0;
    for(auto iter : X)
    {
        data[i++] = iter;
    }

    for(auto iter : Y)
    {
        data[i++] = iter;
    }
}

Table::~Table()
{
    delete[] data;
}

float Table::Interpolate(const float& x)
{
    return;
}