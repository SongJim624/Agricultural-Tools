using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CropModelMKS
{
    class Library_MATLAB : ILibrary
    {
        private Information information;

        private Object library_object;
        private Type library_type;

        public Library_MATLAB(Information information) { this.information = information; }

        public void Unload()
        {
            library_type.InvokeMember("Clear", BindingFlags.InvokeMethod, null, library_object, new object[] { });
            
            library_object = null;
            library_type = null;
            GC.Collect();
        }

        public void Initialize(IState states)
        {
            library_object = Assembly.LoadFrom(information.location).CreateInstance(information.name + ".Component");
            library_type = library_object.GetType();
            library_type.InvokeMember("Create", BindingFlags.InvokeMethod, null, library_object, new object[] { });

            library_type.InvokeMember("Initialize", BindingFlags.InvokeMethod, null,
                library_object, new object[] { states, information.parameters });
        }

        public bool Change(string lib_name, int index, string name, object value)
        {
            return information.Change(name, index, name, value);
        }

        void ILibrary.Inquire(string name, IState states)
        {
            library_type.InvokeMember("Inquire", BindingFlags.InvokeMethod, null,
                library_object, new object[] { name, states });
        }

        public bool Update(IState states, DateTime now)
        {
            library_type.InvokeMember("Update", BindingFlags.InvokeMethod, null,
                library_object, new object[] { states });

            return now != information.end;
        }

        public string Name() => information.name;
    }
}
