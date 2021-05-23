#include "Interfaces.h"

class State : public IState
{
private:
    std::map<std::string, std::vector<std::vector<float>>> states;

public:
    State(TiXmlElement * element);
    virtual ~State();

    void Clean();

    virtual bool Inquire(const std::string& name, std::vector<float>& value);
    virtual bool Write(const std::string& name, const std::vector<float>& value);
};