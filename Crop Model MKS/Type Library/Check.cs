using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CropModelMKS
{
    public class Check
    {
        private XmlDocument project;
        private string workspace;
        private string name;

        public Check(string path)
        {
            project = new XmlDocument();
            project.Load(path);

            workspace = Path.GetDirectoryName(path);
            name = Path.GetFullPath(path).Split('\\').ToArray().Last().Split('.')[0];
        }

        public void Parameters_Folder()
        {
            string para_dir = workspace + "/Parameters";
            if (!Directory.Exists(para_dir))
            {
                Directory.CreateDirectory(para_dir);
            }

            foreach (XmlElement parameter in project.GetElementsByTagName("parameters"))
            {
                string para_path = parameter.InnerText;
                string name = para_path.Split('\\').ToArray().Last();

                string type = parameter.GetAttribute("type");

                if (type == "Custom")
                {
                    XmlNode location = parameter.PreviousSibling.PreviousSibling.PreviousSibling;
                    XmlNode ProgID = location.PreviousSibling;
                    XmlNode language = ProgID.PreviousSibling;

                    string new_file = para_dir + "/" + name.Split('.')[0] + "XML";
                    Converter converter = new Converter(ProgID.InnerText, language.InnerText, location.InnerText);
                    converter.Convert(parameter.InnerText, new_file);

                    parameter.InnerText = new_file;
                }
                else
                {
                    if (File.Exists(para_dir + "/" + name)) { continue; }
                    File.Copy(para_path, para_dir + "/" + name);
                }
            }

            project.Save(workspace + "/" + name + ".XML");
        }

        public void Outputs_Folder()
        {
            string out_dir = workspace + "/Outputs";
            if (!Directory.Exists(out_dir))
            {
                Directory.CreateDirectory(out_dir);
            }
        }

        public string Parameters()
        {
            string path = workspace + "/" + name + "_Parameters.XML";
            if (File.Exists(path)) { return path; }

            XmlDocument parameters = new XmlDocument();
            XmlElement root = parameters.CreateElement("Collection");
            parameters.AppendChild(root);

            foreach (XmlElement module in project.GetElementsByTagName("Module"))
            {
                XmlElement module_item = parameters.CreateElement("Module");
                module_item.SetAttribute("type", module.GetAttribute("type"));

                foreach (XmlElement library in module.GetElementsByTagName("Library"))
                {
                    XmlDocument des = new XmlDocument();
                    string ProgID = library.GetElementsByTagName("ProgID")[0].InnerText;
                    string description = "C:\\Users\\Song Jim\\source\\repos\\QT Interface\\QT Interface\\System\\Descriptions\\"
                            + ProgID + ".XML";
                    des.Load(description);

                    XmlNode parameter = parameters.ImportNode(des.GetElementsByTagName("Parameters")[0], true);
                    ((XmlElement)parameter).SetAttribute("ProgID", ProgID);
                    module_item.AppendChild(parameter);
                }

                root.AppendChild(module_item);
            }

            parameters.Save(path);
            return path;
        }

        public string States()
        {
            string path = workspace + "/" + name + "_States.XML";
            if (File.Exists(path)) { return path; }

            Dictionary<string, string> supports = new Dictionary<string, string> { };

            XmlDocument states = new XmlDocument();
            XmlElement root = states.CreateElement("States");
            states.AppendChild(root);

            foreach (XmlElement module in project.GetElementsByTagName("Module"))
            {
                XmlElement states_mod = states.CreateElement("Module");
                states_mod.SetAttribute("type", module.GetAttribute("type"));

                List<string> item_list = new List<string> { };

                foreach (XmlElement lib in module.GetElementsByTagName("Library"))
                {
                    XmlDocument des = new XmlDocument();
                    string ProgID = lib.GetElementsByTagName("ProgID")[0].InnerText;
                    string description = "C:\\Users\\Song Jim\\source\\repos\\QT Interface\\QT Interface\\System\\Descriptions\\"
                            + ProgID + ".XML";
                    des.Load(description);

                    XmlElement state = (XmlElement)des.GetElementsByTagName("States")[0];

                    foreach (XmlElement item in state.GetElementsByTagName("item"))
                    {
                        string item_name = item.GetAttribute("name");

                        if (item_list.Contains(item_name)) { continue; }

                        item_list.Add(item_name);

                        states_mod.AppendChild(states.ImportNode(item, true));
                    }

                    XmlElement support = (XmlElement)des.GetElementsByTagName("Supports")[0];

                    foreach (XmlElement item in support.GetElementsByTagName("item"))
                    {
                        string item_name = item.GetAttribute("name");

                        supports.Add(item_name, ProgID);
                    }
                }

                root.AppendChild(states_mod);
            }

            XmlElement sup = states.CreateElement("Supports");
            root.AppendChild(sup);

            foreach (KeyValuePair<string, string> pair in supports)
            {
                XmlElement item = states.CreateElement("item");

                item.SetAttribute("key", pair.Key);
                item.SetAttribute("value", pair.Value);

                sup.AppendChild(item);
            }

            states.Save(path);
            return path;
        }

    }

    class Check_Quick
    {
        private readonly string workspace;
        private readonly string name;

        public Check_Quick(string path)
        {
            workspace = Path.GetDirectoryName(path);
            name = Path.GetFullPath(path).Split('\\').ToArray().Last().Split('.')[0];
        }
        public XmlDocument States()
        {
            string path = workspace + "/" + name + "_States.XML";

            XmlDocument states = new XmlDocument();

            if (File.Exists(path)) 
            {
                states.Load(path);
                return states; 
            }

            XmlDocument project = new XmlDocument();
            project.Load(workspace + "/" + name + ".XML");

            Dictionary<string, string> supports = new Dictionary<string, string> { };

            XmlElement root = states.CreateElement("States");
            states.AppendChild(root);

            foreach (XmlElement module in project.GetElementsByTagName("Module"))
            {
                XmlElement states_mod = states.CreateElement("Module");
                states_mod.SetAttribute("type", module.GetAttribute("type"));

                List<string> item_list = new List<string> { };

                foreach (XmlElement lib in module.GetElementsByTagName("Library"))
                {
                    XmlDocument des = new XmlDocument();
                    string ProgID = lib.GetElementsByTagName("ProgID")[0].InnerText;
                    string description = "C:\\Users\\Song Jim\\source\\repos\\QT Interface\\QT Interface\\System\\Descriptions\\"
                            + ProgID + ".XML";
                    des.Load(description);

                    XmlElement state = (XmlElement)des.GetElementsByTagName("States")[0];

                    foreach (XmlElement item in state.GetElementsByTagName("item"))
                    {
                        string item_name = item.GetAttribute("name");

                        if (item_list.Contains(item_name)) { continue; }

                        item_list.Add(item_name);

                        states_mod.AppendChild(states.ImportNode(item, true));
                    }

                    XmlElement support = (XmlElement)des.GetElementsByTagName("Supports")[0];

                    foreach (XmlElement item in support.GetElementsByTagName("item"))
                    {
                        string item_name = item.GetAttribute("name");

                        supports.Add(item_name, ProgID);
                    }
                }

                root.AppendChild(states_mod);
            }

            XmlElement sup = states.CreateElement("Supports");
            root.AppendChild(sup);

            foreach (KeyValuePair<string, string> pair in supports)
            {
                XmlElement item = states.CreateElement("item");

                item.SetAttribute("key", pair.Key);
                item.SetAttribute("value", pair.Value);

                sup.AppendChild(item);
            }

            return states;
        }
    }

}
