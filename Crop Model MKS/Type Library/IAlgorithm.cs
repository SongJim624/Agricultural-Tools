using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CropModelMKS
{
    interface IAlgorithm
    {
        void Analyze(ISimulator simulator);
        void Configurate(string configuration);
        object Inquire(string name);
    }
}
