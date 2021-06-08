#include "Interfaces.h"
#include "Infrastrutures.h"
#include <map>
#include <list>
#include <math.h>
#include "XML/tinyxml.h"

class State : public IState
{
private:
    std::map<std::string, std::list<std::vector<float> > > states;
    std::map<Type, std::map<std::string, IComponent *> > dictionary;

private:
    void Align();
    
public:
    Date * now;

    State(TiXmlElement * element);
    virtual ~State();

    void Switch(const Type& type,  const std::list<std::string>& supports, IComponent * pointer);
    std::vector<float> Inquire(const std::string& name, const long& value);
    void Clean();

    virtual std::vector<float> Inquire(const std::string& name);
    virtual void Write(const std::string& name, const std::vector<float>& value);
};
