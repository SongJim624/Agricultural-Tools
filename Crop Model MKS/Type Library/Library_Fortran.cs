using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Xml;

namespace CropModelMKS
{
    class Library_Fortran : ILibrary
    {
        private Information information;

        private Type type_states;
        private Object object_states;

        private Type type_parameters;
        private Object object_parameters;

        private Type type_component;
        private Object object_component;

        public void Unload()
        {
            type_states.InvokeMember("Detach", BindingFlags.InvokeMethod, null, object_states, new object[] { });
            type_parameters.InvokeMember("Detach", BindingFlags.InvokeMethod, null, object_parameters, new object[] { });

            type_states = null;
            type_parameters = null;
            type_component = null;

            object_states = null;
            object_parameters = null;
            object_component = null;
            GC.Collect();
        }

        public void Initialize(IState states)
        {
            type_states = Type.GetTypeFromProgID("CropModelMKS.DataWrapper.ForFortran");
            object_states = Activator.CreateInstance(type_states);
            type_states.InvokeMember("Attach", BindingFlags.InvokeMethod, null,
                object_states, new object[] { states });

            type_parameters = Type.GetTypeFromProgID("CropModelMKS.DataWrapper.ForFortran");
            object_parameters = Activator.CreateInstance(type_parameters);
            type_parameters.InvokeMember("Attach", BindingFlags.InvokeMethod, null,
                object_parameters, new object[] { information.parameters });

            type_component = Type.GetTypeFromProgID(information.name);
            object_component = Activator.CreateInstance(type_component);
            object status = type_component.InvokeMember("Initialize", BindingFlags.InvokeMethod, null,
                object_component, new object[] { object_states, object_parameters });
        }

        public Library_Fortran(Information information) { this.information = information; }

        public bool Change(string lib_name, int index, string name, object value)
        {
            return information.Change(lib_name, index, name, value);
        }

        void ILibrary.Inquire(string name, IState states)
        {
            type_component.InvokeMember("Inquire", BindingFlags.InvokeMethod, null,
                object_component, new object[] { name, states });
        }

        public bool Update(IState states, DateTime now)
        {
            type_component.InvokeMember("Update", BindingFlags.InvokeMethod, null,
                object_component, new object[] { object_states });

            return now != information.end;
        }

        public string Name() => information.name;
    }
}
