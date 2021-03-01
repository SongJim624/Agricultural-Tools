using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CropModelMKS
{
    class Converter
    {
        private Object lib_obj;
        private Type lib_type;
        public Converter(string ProgID, string language, string location)
        {
            if (language == "MATLAB")
            {
                lib_obj = Assembly.LoadFrom(location).CreateInstance(ProgID + ".Component");
                lib_type = lib_obj.GetType();
            }
            else
            {
                lib_type = Type.GetTypeFromProgID(ProgID);
                lib_obj = Activator.CreateInstance(lib_type);
            }
        }

        public void Convert(string file_path, string XML_path)
        {
            lib_type.InvokeMember("Convert", BindingFlags.InvokeMethod, null,
                lib_obj, new object[] { file_path, XML_path });

            return;
        }
    }
}
