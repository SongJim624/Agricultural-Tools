#include "Simulator.h"

bool operator == (const Date& A, const Date& B)
{
    return A.day == B.day && A.month == B.month && A.year == B.year;
}

Date& operator ++(Date& A)
{
    A.day++;

    if(A.day < 28)
    {
        return A;
    }

    if(A.day == 32)
    {
        if(A.month ==  12)
        {
            A.year++;
            A.month = 1;
            A.day = 1;
            return A;
        }
        else
        {
            A.month++;
            return A;
        }
    }

    if(A.month == 2)
    {
        if(A.year % 4)
        {
            if(A.day == 30)
            {
                A.month++;
                A.day = 1;
                return A;
            }
        }
        else
        {
            if(A.day == 29)
            {
                A.month++;
                A.day = 1;
                return A;
            }
        }
    }

    if(A.day == 31)
    {
        if(A.month == 4 || A.month == 6 ||A.month == 9 || A.month == 11)
        {
            A.month++;
            A.day= 1;
            return A;
        }
    }
}