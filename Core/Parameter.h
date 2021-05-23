#include "Interfaces.h"

class Parameter : public IParameter
{
private:
    std::map<std::string, std::vector<float>> parameters;

public:
    Parameter(const char * parameters_file);
    virtual ~Parameter();

    virtual std::vector<float> Inquire(const std::string& name);
    bool Change(const std::string& name, const std::vector<float>& value);
};