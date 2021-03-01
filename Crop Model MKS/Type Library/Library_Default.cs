using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CropModelMKS
{
    //This library is the wrapper for the COM components
    class Library_Default : ILibrary
    {
        Information information;

        private Object library_object;
        private Type library_type;

        public Library_Default(Information information) { this.information = information; }
        

        bool ILibrary.Change(string lib_name, int index, string name, object value)
        {
            return information.Change(lib_name, index, name, value);
        }

        public void Unload()
        {
            //IIt should be more cautious about the garbage collection in the future.
            //As a former C++ programmer, it is the habit to delete the object manually
            //I do not know whether call the collection frequently would slow down the codes.
            library_object = null;
            library_type = null;
            GC.Collect();
        }

        public void Initialize(IState states)
        {
            library_type = Type.GetTypeFromProgID(information.name);
            library_object = Activator.CreateInstance(library_type);
            library_type.InvokeMember("Initialize", BindingFlags.InvokeMethod, null, 
                library_object, new object[] { states, information.parameters });
        }

        bool ILibrary.Update(IState states, DateTime now)
        {
            library_type.InvokeMember("Update", BindingFlags.InvokeMethod, null,
                library_object, new object[] { states });

            return now != information.end; 
        }

        void ILibrary.Inquire(string name, IState states)
        {
            library_type.InvokeMember("Inquire", BindingFlags.InvokeMethod, null,
                library_object, new object[] { name, states });
        }

        public string Name() => information.name;
    }
}
