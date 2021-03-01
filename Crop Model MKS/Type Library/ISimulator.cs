using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Runtime.InteropServices;

namespace CropModelMKS
{
    [ComVisible(true)]
    public interface ISimulator
    {
        object Inquire(string name, int index = 0);
        void Simulate(int till = 0);
        void Configurate(string project);
        void Change(string lib_name, int index, string name, object value);
    }
}
