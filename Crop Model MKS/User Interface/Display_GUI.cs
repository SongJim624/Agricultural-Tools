using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using CropModelMKS;

namespace CropModelMKS_GUI
{
    public partial class Display_GUI : Form
    {
        private Simulator simulator;

        public Display_GUI(Simulator simulator, XmlDocument states)
        {
            InitializeComponent();

            this.simulator = simulator;

            foreach (XmlElement module in states.GetElementsByTagName("Module"))
            {
                TreeNode node = new TreeNode
                {
                    Name = module.GetAttribute("type")
                };
                treeView1.Nodes.Add(node);

                foreach (XmlElement state in module.GetElementsByTagName("item"))
                {
                    if (state.GetAttribute("size") == "array") { continue; }

                    TreeNode n = new TreeNode
                    {
                        Text = state.GetAttribute("name")
                    };

                    node.Nodes.Add(n);
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
