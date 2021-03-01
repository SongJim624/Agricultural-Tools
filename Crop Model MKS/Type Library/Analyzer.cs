using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CropModelMKS
{
    public class Analyzer
    {
        private ISimulator simulator;
        private IAlgorithm algorithm;

        public Analyzer()
        {
            simulator = new Simulator();
        }

        private IAlgorithm Factory(string configuration)
        {

            algorithm.Configurate(configuration);
            return null;
        }

        public void Configurate(string project, string configuration)
        {
            simulator.Configurate(project);
            algorithm = Factory(configuration);
        }

        public void Analyze()
        {
            algorithm.Analyze(simulator);
        }

        public object Inquire(string name)
        {
            return algorithm.Inquire(name);
        }
    }
}
