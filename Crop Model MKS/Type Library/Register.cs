using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CropModelMKS
{
    public class Register
    {
        private readonly string table_path;

        public Register()
        {
            System.Reflection.Assembly curPath = System.Reflection.Assembly.GetExecutingAssembly();
            table_path = Path.GetDirectoryName(curPath.Location) + "\\Registrations\\";
        }

        public void Add(string type, string language, string location, string ProgID)
        {
            XmlDocument doc = new XmlDocument();
            string path = table_path + type + ".XML";
            doc.Load(path);

            foreach (XmlElement item in doc.GetElementsByTagName("ProgID"))
            {
                if (item.InnerText == ProgID) { return; }
            }

            XmlElement component = doc.CreateElement("Component");
            doc.DocumentElement.AppendChild(component);

            XmlElement pro = doc.CreateElement("ProgID");
            pro.InnerText = ProgID;
            component.AppendChild(pro);

            XmlElement lan = doc.CreateElement("language");
            lan.InnerText = language;
            component.AppendChild(lan);

            XmlElement loc = doc.CreateElement("location");
            loc.InnerText = location;
            component.AppendChild(loc);

            doc.Save(path);
        }

        public void Check()
        {
            string[] type_list = {"Climate", "Plant", "Environment", "Management", "Analysis"};

            XmlDocument doc = new XmlDocument();
            foreach (string type in type_list)
            {
                string path = table_path + type + ".XML";
                doc.Load(path);

                //file the libraries not exists!
                foreach (XmlElement location in doc.GetElementsByTagName("location"))
                {
                    if (!File.Exists(location.InnerText))
                    {
                        doc.DocumentElement.RemoveChild(location.ParentNode);
                    }
                }

                //find the libraries duplicates
                List<string> name_list = new List<string> { };
                foreach (XmlElement ProgID in doc.GetElementsByTagName("ProgID"))
                {
                    if (name_list.Exists(name => name == ProgID.InnerText))
                    {
                        doc.DocumentElement.RemoveChild(ProgID.ParentNode);
                    }
                    else 
                    {
                        name_list.Add(ProgID.InnerText);
                    }
                }

                doc.Save(path);
            }
        }
    }
}
