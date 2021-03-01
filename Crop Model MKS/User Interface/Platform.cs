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
    public partial class Platform : Form
    {
        private readonly Dictionary<string, Dictionary<string, List<string>>> informations;
        private Dictionary<string, List<string>> states_informations;
        private readonly Dictionary<string, ListView> list_dict;
        private readonly Dictionary<string, ComboBox> cbx_dict;
        private readonly Dictionary<string, TabControl> inputs_dict;
        private readonly Simulator simulator;
        private string current_project;
        public Platform()
        {
            InitializeComponent();

            simulator = new Simulator();

            list_dict = new Dictionary<string, ListView> 
            {
                { "climate", climate_ListView},
                { "plant", plant_ListView},
                { "environment", environment_ListView},
                { "management", management_ListView}
            };

            cbx_dict = new Dictionary<string, ComboBox>
            {
                { "climate", cli_cbx},
                { "plant",plt_cbx},
                { "environment", env_cbx},
                { "management", mgt_cbx},
                { "analysis", analysis_cbx}
            };

            informations = new Dictionary<string, Dictionary<string, List<string>>>
            {
                { "climate", new Dictionary<string, List<string>>{ } },
                { "plant", new Dictionary<string, List<string>>{ } },
                { "environment", new Dictionary<string, List<string>>{ } },
                { "management", new Dictionary<string, List<string>>{ } },
                { "analysis", new Dictionary<string, List<string>>{ } }
            };

            inputs_dict = new Dictionary<string, TabControl>
            {
                { "climate", climate_inputs},
                { "plant", plant_inputs},
                { "environment", environment_inputs},
                { "management", management_inputs}
            };

            XmlDocument doc = new XmlDocument();

            foreach (string type in cbx_dict.Keys)
            {
                doc.Load("System/Registrations/" + type + ".XML");

                foreach (XmlElement component in doc.GetElementsByTagName("Component"))
                {
                    string ProgID = component.ChildNodes[0].InnerText;   
                    string language = component.ChildNodes[1].InnerText;
                    string location = component.ChildNodes[2].InnerText;
                    
                    informations[type][ProgID] = new List<string>{ language, location};

                    cbx_dict[type].Items.Add(ProgID);
                }

                cbx_dict[type].SelectedIndex = 0;
            }
        }

        private void btn_select_simulator_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                InitialDirectory = "./Progjects/",
                Filter = "Simulation Project|*.XML",
                RestoreDirectory = true,
                FilterIndex = 1
            };

            if (dialog.ShowDialog() == DialogResult.Cancel)
            {
                simulator_project.Text = "";
                return;
            }

            simulator_project.Text = dialog.FileName;

            XmlDocument doc = new XmlDocument();

            doc.Load(dialog.FileName);

            begin_simulator.Text = doc.GetElementsByTagName("Begin")[0].InnerText;
            end_simulator.Text = doc.GetElementsByTagName("End")[0].InnerText;

            foreach(XmlElement module in doc.GetElementsByTagName("Module"))
            {
                string type = module.GetAttribute("type");
                list_dict[type].Items.Clear();

                foreach (XmlElement library in module.GetElementsByTagName("Library"))
                {
                    string begin = library.ChildNodes[3].InnerText;
                    string end = library.ChildNodes[4].InnerText;
                    string ProgID = library.ChildNodes[1].InnerText;
                    string parameter = library.ChildNodes[5].InnerText;

                    Add_To_List(begin, end, ProgID, parameter, list_dict[type]);
                }
            }
        }

        private void btn_mgt_add_Click(object sender, EventArgs e)
        {
            Add_To_List(mgt_begin.Text, mgt_end.Text, mgt_cbx.Text,
                mgt_parameters.Text, management_ListView);
        }

        private void Add_To_List(string begin, string end, string 
            ProgID, string parameter, ListView list)
        {
            list.BeginUpdate();

            ListViewItem item = new ListViewItem
            {
                Text = begin
            };

            item.SubItems.Add(end);
            item.SubItems.Add(ProgID);
            item.SubItems.Add(parameter);

            list.Items.Add(item);
            list.EndUpdate();
        }

        private void btn_cli_add_Click(object sender, EventArgs e)
        {
            Add_To_List(cli_begin.Text, cli_end.Text, cli_cbx.Text,
                cli_parameters.Text, climate_ListView);
        }

        private void btn_plt_add_Click(object sender, EventArgs e)
        {
            Add_To_List(plt_begin.Text, plt_end.Text, plt_cbx.Text,
                plt_parameters.Text, plant_ListView);
        }

        private void btn_env_add_Click(object sender, EventArgs e)
        {
            Add_To_List(env_begin.Text, env_end.Text, env_cbx.Text,
                env_parameters.Text, environment_ListView);
        }

        private void btn_simulate_Click(object sender, EventArgs e)
        {
            if (simulator_project.Text == "")
            {
                MessageBox.Show("Please Select A Project File", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                Simulator simulators = new Simulator();

                simulators.Configurate(simulator_project.Text);
                simulators.Simulate();
                current_project = simulator_project.Text;

                MessageBox.Show("Simulation Finished!", "NOTICE",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Simulation Failed!\n Internal Error In Simulator", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return;
        }

        private void btn_cli_remove_Click(object sender, EventArgs e)
        {
            Remove_From_List(climate_ListView);
        }

        private void btn_plt_remove_Click(object sender, EventArgs e)
        {
            Remove_From_List(plant_ListView);
        }

        private void btn_env_remove_Click(object sender, EventArgs e)
        {
            Remove_From_List(environment_ListView);
        }

        private void btn_mgt_remove_Click(object sender, EventArgs e)
        {
            Remove_From_List(management_ListView);
        }

        private void Remove_From_List(ListView list)
        {
            list.BeginUpdate();

            foreach (ListViewItem item in list.SelectedItems)
            {
                list.Items.Remove(item);   //按项移除
            }

            list.EndUpdate();
        }

        private void btn_save_simulation_project_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                InitialDirectory = "./Progjects/",
                Filter = "Simulation Project|*.XML",
                RestoreDirectory = true,
                FilterIndex = 1
            };

            if (dialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            string path = dialog.FileName;
            simulator_project.Text = path;

            Dictionary<string, ListView> list_dict= new Dictionary<string, ListView> { };
            list_dict["climate"] = climate_ListView;
            list_dict["plant"] = plant_ListView;
            list_dict["environment"] = environment_ListView;
            list_dict["management"] = management_ListView;

            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("Configuration");
            doc.AppendChild(root);

            XmlElement clock = doc.CreateElement("Clock");
            root.AppendChild(clock);

            XmlElement begin_s = doc.CreateElement("Begin");
            begin_s.InnerText = begin_simulator.Text;
            clock.AppendChild(begin_s);

            XmlElement end_s = doc.CreateElement("End");
            end_s.InnerText = end_simulator.Text;
            clock.AppendChild(end_s);

            foreach (var list in list_dict)
            {
                XmlElement module = doc.CreateElement("Module");
                module.SetAttribute("type", list.Key);

                foreach(ListViewItem item in list.Value.Items)
                {
                    XmlElement library = doc.CreateElement("Library");

                    string progid = item.SubItems[2].Text;

                    XmlElement language = doc.CreateElement("language");
                    language.InnerText = informations[list.Key][progid][0];
                    library.AppendChild(language);

                    XmlElement ProgID = doc.CreateElement("ProgID");
                    ProgID.InnerText = progid;
                    library.AppendChild(ProgID);

                    XmlElement location = doc.CreateElement("location");
                    location.InnerText = informations[list.Key][progid][1];
                    library.AppendChild(location);

                    XmlElement begin = doc.CreateElement("begin");
                    begin.InnerText = item.SubItems[0].Text;
                    library.AppendChild(begin);

                    XmlElement end = doc.CreateElement("end");
                    end.InnerText = item.SubItems[1].Text;
                    library.AppendChild(end);

                    XmlElement parameter = doc.CreateElement("parameters");
                    parameter.InnerText = item.SubItems[3].Text;
                    library.AppendChild(parameter);

                    //Convert


                    module.AppendChild(library);
                }

                root.AppendChild(module);
            }

            doc.Save(path);
        }

        private void btn_cli_select_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                InitialDirectory = "./Progjects/",
                Filter = "Any File|*.*",
                RestoreDirectory = true,
                FilterIndex = 1
            };

            if (dialog.ShowDialog() == DialogResult.Cancel)
            {
                cli_parameters.Text = "";
                return;
            }

            cli_parameters.Text = dialog.FileName;
        }

        private void btn_plt_select_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                InitialDirectory = "./Progjects/",
                Filter = "Any File|*.*",
                RestoreDirectory = true,
                FilterIndex = 1
            };

            if (dialog.ShowDialog() == DialogResult.Cancel)
            {
                plt_parameters.Text = "";
                return;
            }

            plt_parameters.Text = dialog.FileName;
        }

        private void btn_env_select_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                InitialDirectory = "./Progjects/",
                Filter = "Any File|*.*",
                RestoreDirectory = true,
                FilterIndex = 1
            };

            if (dialog.ShowDialog() == DialogResult.Cancel)
            {
                env_parameters.Text = "";
                return;
            }

            env_parameters.Text = dialog.FileName;
        }

        private void btn_mgt_select_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                InitialDirectory = "./Progjects/",
                Filter = "Any File|*.*",
                RestoreDirectory = true,
                FilterIndex = 1
            };

            if (dialog.ShowDialog() == DialogResult.Cancel)
            {
                mgt_parameters.Text = "";
                return;
            }

            mgt_parameters.Text = dialog.FileName;
        }

        private void btn_select_algorithm_Click(object sender, EventArgs e)
        {
            Set_Alogrithm(analysis_cbx.Text);
        }

        private void Set_Alogrithm(string ProgID)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("System/Descriptions/" + ProgID + ".XML");
            
            while (algorithm_datagrid.Rows.Count != 0)
            {
                algorithm_datagrid.Rows.RemoveAt(0);
            }

            foreach (XmlElement parameter in doc.GetElementsByTagName("item"))
            {
                int index = algorithm_datagrid.Rows.Add();

                algorithm_datagrid.Rows[index].Cells[0].Value = parameter.GetAttribute("name");
                algorithm_datagrid.Rows[index].Cells[1].Value = "";
                algorithm_datagrid.Rows[index].Cells[2].Value = parameter.GetAttribute("size");
                algorithm_datagrid.Rows[index].Cells[3].Value = parameter.GetAttribute("type");
            }
        }

        private void addOneComponentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new Register_GUI
            {
                Text = "Registration"
            };
            form.ShowDialog();
        }

        private void checkTheRegistrationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Check();
        }

        private void btn_select_simulation_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                InitialDirectory = "./Progjects/",
                Filter = "Analysis Project|*.XML",
                RestoreDirectory = true,
                FilterIndex = 1
            };

            if (dialog.ShowDialog() == DialogResult.Cancel)
            {
                txt_simulation.Text = "";
                return;
            }

            txt_simulation.Text = dialog.FileName;
            Set_Simulation(txt_simulation.Text);
        }
        private void Set_Simulation(string path)
        {  
            Check check = new Check(path);

            foreach (XmlElement module in check.Parameters().GetElementsByTagName("Module"))
            {
                string type = module.GetAttribute("type");
                inputs_dict[type].Controls.Clear();

                foreach (XmlElement library in module.GetElementsByTagName("Parameters"))
                {
                    TabPage page = new TabPage
                    {
                        Text = library.GetAttribute("ProgID")
                    };
                    inputs_dict[type].Controls.Add(page);

                    TabControl control = new TabControl()
                    {
                        Width = 506,
                        Height = 207,
                        Anchor = (AnchorStyles)(Top | Bottom | Left | Right)
                    };

                    page.Controls.Add(control);

                    foreach (XmlElement section in library.GetElementsByTagName("section"))
                    {
                        TabPage section_page = new TabPage
                        {
                            Text = section.GetAttribute("name")
                        };
                        control.Controls.Add(section_page);

                        DataGridView data = new DataGridView()
                        {
                            ColumnCount = 6,
                            Left = 0,
                            Top = 0,
                            Width = 496,
                            Height = 181,
                            ColumnHeadersVisible = true,
                            AllowUserToAddRows = false
                        };
                        section_page.Controls.Add(data);

                        data.Columns[0].Name = "name";
                        data.Columns[1].Name = "intial value";
                        data.Columns[2].Name = "max value";
                        data.Columns[3].Name = "min value";
                        data.Columns[4].Name = "size";
                        data.Columns[5].Name = "type";

                        data.Columns[0].ReadOnly = true;
                        data.Columns[4].ReadOnly = true;
                        data.Columns[5].ReadOnly = true;

                        foreach (XmlElement parameter in section.GetElementsByTagName("item"))
                        {
                            int index = data.Rows.Add();

                            data.Rows[index].Cells[0].Value = parameter.GetAttribute("name");
                            data.Rows[index].Cells[1].Value = "";
                            data.Rows[index].Cells[2].Value = "";
                            data.Rows[index].Cells[3].Value = "";
                            data.Rows[index].Cells[4].Value = parameter.GetAttribute("size");
                            data.Rows[index].Cells[5].Value = parameter.GetAttribute("type");
                        }
                    }
                }
            }

            out_tree.Nodes.Clear();
            states_informations = new Dictionary<string, List<string>> { };
            foreach (XmlElement module in check.States().GetElementsByTagName("Module"))
            {
                TreeNode current = new TreeNode
                {
                    Text = module.GetAttribute("type")
                };
                out_tree.Nodes.Add(current);

                foreach(XmlElement state in module.GetElementsByTagName("item"))
                {
                    string name = state.GetAttribute("name");

                    states_informations[name] = new List<string>
                    {
                        state.GetAttribute("size"), 
                        state.GetAttribute("type") 
                    };

                    TreeNode item = new TreeNode
                    {
                        Checked = false,
                        Text = name
                    };

                    current.Nodes.Add(item);
                }
            }
        }

        private void btn_save_analysis_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                InitialDirectory = "./Progjects/",
                Filter = "Analysis Project|*.XML",
                RestoreDirectory = true,
                FilterIndex = 1
            };

            if (dialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            txt_analysis.Text = dialog.FileName;

            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("Configuration");
            doc.AppendChild(root);

            //Analyzer Configuration
            XmlElement analyzer_configuration = doc.CreateElement("AnalyzerConfiguration");
            root.AppendChild(analyzer_configuration);

            XmlElement ProgID = doc.CreateElement("ProgID");
            ProgID.InnerText = analysis_cbx.Text;
            analyzer_configuration.AppendChild(ProgID);

            XmlElement language = doc.CreateElement("language");
            language.InnerText = informations["analysis"][analysis_cbx.Text][0];
            analyzer_configuration.AppendChild(language);

            XmlElement location = doc.CreateElement("ProgID");
            location.InnerText = informations["analysis"][analysis_cbx.Text][1];
            analyzer_configuration.AppendChild(location);

            //Algorithm Parameters
            XmlElement parameters = doc.CreateElement("Parameters");
            analyzer_configuration.AppendChild(parameters);

            foreach (DataGridViewRow row in  algorithm_datagrid.Rows)
            {
                XmlElement parameter = doc.CreateElement("Parameter");
                parameter.SetAttribute("size", row.Cells[2].Value.ToString());
                parameter.SetAttribute("type", row.Cells[3].Value.ToString());

                XmlElement name = doc.CreateElement("name");
                parameter.AppendChild(name);
                name.InnerText = row.Cells[0].Value.ToString();

                XmlElement value = doc.CreateElement("value");
                parameter.AppendChild(value);
                value.InnerText = row.Cells[1].Value.ToString();

                parameters.AppendChild(parameter);
            }

            //Simulator configurations
            XmlElement simulator_configurations = doc.CreateElement("SimulationConfiguration");
            root.AppendChild(simulator_configurations);

            //Project
            XmlElement project = doc.CreateElement("Project");
            project.InnerText = txt_simulation.Text;
            simulator_configurations.AppendChild(project);

            //Inputs
            XmlElement inputs = doc.CreateElement("Inputs");
            simulator_configurations.AppendChild(inputs);

            Dictionary<string, int> ProgID_count = new Dictionary<string, int> { };

            foreach (TabControl module in inputs_dict.Values)
            {
                foreach(TabPage page in module.Controls)
                {
                    string ID = page.Text;

                    try
                    {
                        ProgID_count[ID] += 1;
                    }
                    catch (KeyNotFoundException)
                    {
                        ProgID_count[ID] = 1;
                    }

                    foreach(TabPage section in page.Controls[0].Controls)
                    {
                        foreach (DataGridView data in section.Controls)
                        {
                            foreach (DataGridViewRow row in data.Rows)
                            {
                                if (row.Cells[1].Value.ToString() == "") { continue; }

                                XmlElement paramter = doc.CreateElement("Parameter");
                                inputs.AppendChild(paramter);

                                paramter.SetAttribute("ProgID", ID);
                                paramter.SetAttribute("index", ProgID_count[ID].ToString());

                                XmlElement name = doc.CreateElement("name");
                                name.InnerText = row.Cells[0].Value.ToString();
                                paramter.AppendChild(name);

                                XmlElement initial = doc.CreateElement("initial");
                                initial.InnerText = row.Cells[1].Value.ToString();
                                paramter.AppendChild(initial);

                                XmlElement upper = doc.CreateElement("upper");
                                upper.InnerText = row.Cells[2].Value.ToString();
                                paramter.AppendChild(upper);

                                XmlElement lower = doc.CreateElement("lower");
                                lower.InnerText = row.Cells[3].Value.ToString();
                                paramter.AppendChild(lower);
                            }
                        }
                    }
                }
            }

            //Outputs
            XmlElement outputs = doc.CreateElement("Outputs");
            simulator_configurations.AppendChild(outputs);

            foreach (TreeNode module in out_tree.Nodes)
            {
                foreach (TreeNode state in module.Nodes)
                {
                    if (!state.Checked) { continue; }

                    string name = state.Text;

                    XmlElement item = doc.CreateElement("item");

                    item.SetAttribute("name", name);
                    item.SetAttribute("size", states_informations[name][0]);
                    item.SetAttribute("type", states_informations[name][1]);
                    outputs.AppendChild(item);
                }
            }

            doc.Save(txt_analysis.Text);
            MessageBox.Show("Analysis Project Saved Successfully!", "Inforamtion",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_select_analysis_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                InitialDirectory = "./Progjects/",
                Filter = "Analysis Project|*.XML",
                RestoreDirectory = true,
                FilterIndex = 1
            };

            if (dialog.ShowDialog() == DialogResult.Cancel)
            {
                txt_analysis.Text = "";
                return;
            }

            txt_analysis.Text = dialog.FileName;

            XmlDocument doc = new XmlDocument();
            doc.Load(txt_analysis.Text);

            txt_simulation.Text = doc.GetElementsByTagName("Project")[0].InnerText;
            Set_Simulation(txt_simulation.Text);

            analysis_cbx.Text = doc.GetElementsByTagName("ProgID")[0].InnerText;
            Set_Alogrithm(analysis_cbx.Text);

            //Set Analysis Parameters
            XmlElement parameters = (XmlElement)doc.GetElementsByTagName("Parameters")[0];
            foreach (XmlElement parameter in parameters.GetElementsByTagName("Parameter"))
            {
                string name = parameter.ChildNodes[0].InnerText;
                string value = parameter.ChildNodes[1].InnerText;

                foreach (DataGridViewRow row in algorithm_datagrid.Rows)
                {
                    if (row.Cells[0].Value.ToString() == name)
                    {
                        row.Cells[1].Value = value;
                    }    
                }
            };

            //Set Simulation Parameters
            XmlElement inputs = (XmlElement)doc.GetElementsByTagName("Inputs")[0];
            Dictionary<string, int> ProgID_count = new Dictionary<string, int> { };

            foreach (TabControl module in inputs_dict.Values)
            {
                foreach (TabPage page in module.Controls)
                {
                    string ID = page.Text;

                    try
                    {
                        ProgID_count[ID] += 1;
                    }
                    catch (KeyNotFoundException)
                    {
                        ProgID_count[ID] = 1;
                    }

                    foreach (TabPage section in page.Controls[0].Controls)
                    {
                        foreach (DataGridView data in section.Controls)
                        {
                            foreach (DataGridViewRow row in data.Rows)
                            {
                                foreach (XmlElement parameter in inputs.GetElementsByTagName("Parameter"))
                                {
                                    if (ID != parameter.GetAttribute("ProgID")) { continue; }
                                    if (int.Parse(parameter.GetAttribute("index")) != ProgID_count[ID])
                                    {
                                        continue;
                                    }

                                    if (parameter.ChildNodes[0].InnerText == row.Cells[0].Value.ToString())
                                    {
                                        row.Cells[1].Value = parameter.ChildNodes[1].InnerText;
                                        row.Cells[2].Value = parameter.ChildNodes[2].InnerText;
                                        row.Cells[3].Value = parameter.ChildNodes[3].InnerText;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            //Set Outputs

            foreach (XmlElement state in doc.GetElementsByTagName("item"))
            {
                string name = state.GetAttribute("name");

                foreach (TreeNode module in out_tree.Nodes)
                {
                    foreach (TreeNode node in module.Nodes)
                    {
                        if (node.Text == name) { node.Checked = true; }
                    }
                }
            }
        }

        private void btn_cli_create_Click(object sender, EventArgs e)
        {
            Parameter_GUI dialog = new Parameter_GUI(cli_cbx.Text)
            {
                Text = "Parameters"
            };

            dialog.ShowDialog();
        }

        private void btn_analyze_Click(object sender, EventArgs e)
        {
            if (txt_analysis.Text == "")
            {
                MessageBox.Show("Please Select A Project File", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Analyzer analyzer = new Analyzer();
            analyzer.Configurate(txt_analysis.Text);
            analyzer.Analyze();

            MessageBox.Show("Analysis Completed!", "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_display_Click(object sender, EventArgs e)
        {
            if (current_project == null) 
            {
                MessageBox.Show("No Simulation Carried Out Yet!", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Check check = new Check(current_project);
            Display_GUI dialog = new Display_GUI(simulator, check.States())
            {
                Text = "Display"
            };

            dialog.ShowDialog();
        }
    }
}
