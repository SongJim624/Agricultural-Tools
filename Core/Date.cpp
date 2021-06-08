#include "Simulator.h"
#include <regex>

Date::Date(const std::string& date)
{
    std::regex pattern();
    const std::sregex_token_iterator end;
    std::vector<std::string> data;

　for (std::sregex_token_iterator i( date.begin(), date.end(), pattern); i != end ; ++i) 
    {
　　data.push_back( *i );
　}

    year = std::stol(data[0].c_str());
    month = std::stol(data[1].c_str());
    day = std::stol(data[2].c_str());
}

bool Equal(Date * A, Date * B)
{
    return 
        A->day == B->day &&
        A->month == B->month &&
        A->year == B->year;
}

void Date::Next_Year()
{
    year++;
    month = day = 1;
}

void Date::Next_Month()
{
    day = 1;
    month++;
}

Date* Date::Next()
{
    if(day ++ == 32)
    {
        month == 12 ? Next_Year() : Next_Month();
        return this;
    }

    if(day == 31 && (month == 4 || month == 6 || month == 9 || month == 11))
    {
        Next_Month();
        return this;
    }

    if(month == 2)
    {
        if(day + year % 4 == 0 ? year % 400 == 0 ? 0 : 1 : 1 == 30)
        {
            Next_Month();
            return this;
        }
    }

    return this;
}