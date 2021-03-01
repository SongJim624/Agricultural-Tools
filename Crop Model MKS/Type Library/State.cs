using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace CropModelMKS
{
    public class State : IState
    {
        private DateTime current;
        private Dictionary<string, List<object>> states;
        private Dictionary<string, string> supports;
        private Dictionary<string, ILibrary> libraries;
        int size;
        private object receiver;

        public State(XmlDocument doc, DateTime begin)
        {
            current = begin;

            states = new Dictionary<string, List<object>> { };                        
            supports = new Dictionary<string, string> { };
            libraries = new Dictionary<string, ILibrary> { };
            size = 0;
            receiver = null;

            foreach (XmlElement module in doc.GetElementsByTagName("Module"))
            {
                foreach (XmlElement item in module.GetElementsByTagName("item"))
                {
                    states.Add(item.GetAttribute("name"), new List<object> { });
                }
            }

            foreach (XmlElement sup in doc.GetElementsByTagName("Supports"))
            {
                foreach (XmlElement item in sup.GetElementsByTagName("item"))
                {
                    supports.Add(item.GetAttribute("key"), item.GetAttribute("value"));
                }
            }
        }

        public void Write(string name, object value)
        {
            if (states[name].Count == 0 || states[name].Last() != null)
            {
                states[name].Add(Convert(value));
            }
            else
            {
                states[name][states[name].Count - 1] = Convert(value);
            }
        }

        private void Align()
        {
            foreach (List<object> list in states.Values)
            {
                size = Math.Max(size, list.Count);
            }

            foreach (List<object> list in states.Values)
            {
                int count = list.Count;

                if (count < size)
                {
                    for (int i = count; i < size; ++i)
                    {
                        list.Add(null);
                    }
                }
            }
        }

        //This inquiry is for the simulator
        public object Inquire(string name, int index)
        {
            return states[name][index - 1];
        }

        public void Clean()
        {
            foreach (List<object> list in states.Values)
            {
                list.Clear();
            }
        }

        public void Replace(ILibrary library)
        {
            Align();
            libraries.Add(library.Name(), library);
        }

        private object Convert(object value)
        {
            if (value.GetType() == typeof(Object[]))
            {
                object[] objects = (object[])value;

                if (objects[0].GetType() == typeof(double))
                {
                    List<double> array = new List<double> { };

                    for (int i = 0; i < objects.Length; ++i)
                    {
                        array.Add((double)objects[i]);
                    }

                    return array.ToArray();
                }
                else if (objects[0].GetType() == typeof(float))
                {
                    List<float> array = new List<float> { };

                    for (int i = 0; i < objects.Length; ++i)
                    {
                        array.Add((float)objects[i]);
                    }

                    return array.ToArray();
                }
                else if (objects[0].GetType() == typeof(int))
                {
                    List<int> array = new List<int> { };

                    for (int i = 0; i < objects.Length; ++i)
                    {
                        array.Add((int)objects[i]);
                    }

                    return array.ToArray();
                }
            }

            return value;
        }

        public object Inquire(string name)
        {
            if (name == "year")
            {
                return current.Year;
            }
            else if (name == "month")
            {
                return current.Month;
            }
            else if (name == "day")
            {
                return current.Day;
            }

            try
            {
                return states[name].Last();
            }
            catch
            {
                try
                {
                    receiver = null;
                    libraries[supports[name]].Inquire(name, this);
                    return receiver;
                }
                catch
                {
                    return null;
                }
            }
        }

        public void Next()
        {
            current.AddDays(1);
        }

        public void Receive(object value)
        {
            receiver = Convert(value);
        }

    }
}
