using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CropModelMKS
{
    class Model_Module
    {
        private List<ILibrary> libraries;
        private readonly int size;
        private int current;

        public Model_Module(XmlNode information)
        {
            libraries = new List<ILibrary> { };

            List<string> names = new List<string> { };
            List<int> indices = new List<int> { };

            foreach (XmlNode node in information.ChildNodes)
            {
                Information info = new Information(node);

                bool found = false;
                int index = 0;

                for (int j = 0; j < names.Count; ++j)
                {
                    if (names[j] == info.name)
                    {
                        index = (indices[j]++);
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    names.Add(info.name);
                    indices.Add(1);
                    index = 1;
                }

                info.index = index;

                if (info.language == "MATLAB")
                {
                    libraries.Add(new Library_MATLAB(info));
                }
                /*
                else if (info.language == "Python")
                {
                    if (manager == null) { manager = new Python_Manager(); }

                    libraries.Add(new Library_Python(manager, info));
                }
                */
                else if (info.language == "Fortran")
                {
                    libraries.Add(new Library_Fortran(info));
                }
                else 
                {
                    libraries.Add(new Library_Default(info));
                }
            }

            size = libraries.Count;
            current = 0;
        }


        public void Update(State states, DateTime now)
        {
            if (!libraries[current].Update(states, now) && current != size - 1)
            {
                libraries[current].Unload();
                current++;
                states.Replace(libraries[current]);
                libraries[current].Initialize(states);
            }
        }

        public bool Change(string lib_name, int index, string name, object value)
        {
            foreach (ILibrary library in libraries)
            {
                if (library.Change(lib_name, index, name, value)) { return true; }
            }

            return false;
        }

        public void Initialize(State states)
        {
            libraries[current].Initialize(states);
            states.Replace(libraries[current]);
        }

        public void Finish()
        {
            libraries[current].Unload();
        }
    }
}
