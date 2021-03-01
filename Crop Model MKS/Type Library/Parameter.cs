using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using System.CodeDom;
using System.Runtime.InteropServices;

namespace CropModelMKS
{
    public class Parameter : IParameter
    {
        private Dictionary<string, object> parameters;

        private object Convert(string value, string type, string length)
        {
            if (length == "single")
            {
                if (type == "double")
                {
                    return System.Convert.ToDouble(value);
                }
                else if (type == "float")
                {
                    return System.Convert.ToSingle(value);
                }
                else if (type == "integer")
                {
                    return System.Convert.ToInt64(value);
                }
                else if (type == "string")
                {
                    return value;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                string[] stringlist = value.Split(' ');
                
                if (type == "double")
                {
                    List<double> array = new List<double>{ };
                    foreach (string item in stringlist)
                    {
                        array.Add(System.Convert.ToDouble(item));
                    }

                    return array.ToArray();
                }
                else if (type == "float")
                {
                    List<float> array = new List<float> { };
                    foreach (string item in stringlist)
                    {
                        if (item == "") { continue; }

                        array.Add(System.Convert.ToSingle(item));
                    }

                    return array.ToArray();
                }
                else if (type == "integer")
                {
                    List<long> array = new List<long> { };
                    foreach (string item in stringlist)
                    {
                        array.Add(System.Convert.ToInt64(item));
                    }

                    return array.ToArray();
                }
                else if (type == "string")
                {
                    List<string> array = new List<string> { };
                    foreach (string item in stringlist)
                    {
                        array.Add(item);
                    }

                    return array.ToArray();
                }
                else
                {
                    return null;
                }
            }
        }

        public Parameter(string path)
        {
            parameters = new Dictionary<string, object> { };

            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            foreach (XmlNode sections in doc.ChildNodes)
            {
                foreach (XmlNode parameter in sections.ChildNodes)
                {
                    XmlNodeList contents = parameter.ChildNodes;

                    foreach (XmlNode content in contents)
                    {
                        parameters.Add(content.FirstChild.InnerText, 
                            Convert(content.FirstChild.NextSibling.InnerText,
                            ((XmlElement)content).GetAttribute("type").ToString(),
                            ((XmlElement)content).GetAttribute("size").ToString()));
                    }
                }                
            }
        }

        public object Inquire(string name)
        {
            return parameters[name];
        }

        public void Change(string name, object value)
        {
            parameters[name] = value;
        }
    }
}
