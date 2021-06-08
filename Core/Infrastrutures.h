#include <string>

#ifndef _INFRASTRUCTURES_
#define _INFRASTRUCTURES_
struct Date
{
private:
    void Next_Year();
    void Next_Month();

public:    
    long year, month, day;

public:
    Date(const std::string& date);
    Date* Next();
};

bool Equal(Date * A, Date * B);

enum class Type
{
    climate = 1,
    plant = 2,
    environment = 3,
    management = 4
};
#endif