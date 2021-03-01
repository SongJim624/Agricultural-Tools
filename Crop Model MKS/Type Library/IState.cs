using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CropModelMKS
{
    [ComVisible(true)]
    public interface IState
    {
        object Inquire(string name);
        void Write(string name, object value);
        void Receive(object value);
    }
}
