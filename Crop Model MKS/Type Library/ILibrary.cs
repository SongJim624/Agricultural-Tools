using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CropModelMKS
{
    public interface ILibrary
    {
        bool Update(IState states, DateTime now);
        bool Change(string lib_name, int index, string name, object value);
        void Inquire(string name, IState states);
        void Initialize(IState states);
        void Unload();
        string Name();
    }

    public class Information
    {
        public readonly string name;
        public readonly string location;
        public readonly DateTime end;
        public readonly string language;

        public int index;
        public Parameter parameters;

        public Information(XmlNode information)
        {
            XmlNodeList list = information.ChildNodes;

            language = list[0].InnerText;
            name = list[1].InnerText;
            location = list[2].InnerText;
            //string begin = information_list[3].InnerText;
            DateTime.TryParse(list[4].InnerText, out end);

            XmlElement parameter_location = (XmlElement)list[5];
            if (parameter_location.GetAttribute("type") == "Custom")
            {
                parameters = new Parameter(list[6].InnerText);
            }
            else 
            {
                parameters = new Parameter(list[5].InnerText);
            }
        }

        public bool Change(string lib_name, int index, string name, object value)
        {
            if (lib_name == this.name && index == this.index)
            {
                parameters.Change(name, value);
                return true;
            }

            return false;
        }
    }
}
