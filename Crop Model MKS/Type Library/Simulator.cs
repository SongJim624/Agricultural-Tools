using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;

namespace CropModelMKS
{
    public class Simulator : ISimulator
    {
        private State states;
        private DateTime begin, end, now;
        private List<Model_Module> modules;

        private void Initialize()
        {
            foreach (Model_Module module in modules)
            {
                module.Initialize(states);
            }
        }

        private void Finish()
        {
            foreach (Model_Module module in modules)
            {
                module.Finish();
            }
        }

        object ISimulator.Inquire(string name, int index) 
        {
            return states.Inquire(name, index);
        }

        void ISimulator.Simulate(int till)
        {
            TimeSpan interval = till == 0 ? end - begin : new TimeSpan(till, 0, 0, 0);

            //This situation presents the Rerun situation
            if (now == end)
            {
                now = begin;
                states.Clean();
            }

            if (now == begin){ Initialize(); }

            //This situation reflects the normal running or continue to run conditions
            while ((now - begin != interval) && now != end)
            {
                foreach (Model_Module module in modules)
                {
                    module.Update(states, now);
                }

                now = now.AddDays(1);
            }

            Finish();
        }

        void ISimulator.Configurate(string path)
        {
            Check_Quick check = new Check_Quick(path);
            modules.Clear();

            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            XmlNode begin_node = doc.SelectSingleNode(@"Configuration/Clock/Begin");
            DateTime.TryParse(begin_node.FirstChild.Value.ToString(), out begin);

            states = new State(check.States(), begin);

            XmlNode end_node = doc.SelectSingleNode(@"Configuration/Clock/End");
            DateTime.TryParse(end_node.FirstChild.Value.ToString(), out end);

            now = begin;

            XmlNodeList components = doc.SelectNodes(@"Configuration/Module");

            foreach (XmlNode module in components)
            {
                modules.Add(new Model_Module(module));
            }
        }

        void ISimulator.Change(string lib_name, int index, string name, object value)
        {
            foreach (Model_Module module in modules)
            {
                if (module.Change(lib_name, index, name, value)) { return; }
            }
        }

        public Simulator()
        {
            states = null;
            modules = new List<Model_Module> { };
        }
    }
}
