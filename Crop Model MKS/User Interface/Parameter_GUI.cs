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

namespace CropModelMKS_GUI
{
    public partial class Parameter_GUI : Form
    {
        public Parameter_GUI(string ProgID)
        {
            InitializeComponent();

            XmlDocument doc = new XmlDocument();
            doc.Load("./System/Descriptions/" + ProgID + ".XML");

            foreach (XmlElement section in doc.GetElementsByTagName("section"))
            {
                TabPage page = new TabPage
                {
                    Width = 467,
                    Height = 397,
                    Text = section.GetAttribute("name")
                };
                tabControl1.Controls.Add(page);

                DataGridView data = new DataGridView
                {
                    ColumnCount = 4,
                    Width = 467,
                    Height = 397,
                    Top = 0,
                    Left = 0,
                    AllowUserToAddRows = false
                };
                page.Controls.Add(data);

                data.Columns[0].Name = "name";
                data.Columns[1].Name = "value";
                data.Columns[2].Name = "size";
                data.Columns[3].Name = "type";

                data.Columns[0].ReadOnly = true;
                data.Columns[2].ReadOnly = true;
                data.Columns[3].ReadOnly = true;

                foreach (XmlElement parameter in section.GetElementsByTagName("item"))
                {
                    int index = data.Rows.Add();

                    data.Rows[index].Cells[0].Value = parameter.GetAttribute("name");
                    data.Rows[index].Cells[1].Value = "";
                    data.Rows[index].Cells[2].Value = parameter.GetAttribute("size");
                    data.Rows[index].Cells[3].Value = parameter.GetAttribute("type");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                InitialDirectory = "./Progjects/",
                Filter = "Parameters|*.XML",
                RestoreDirectory = true,
                FilterIndex = 1
            };

            if (dialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("Parameters");
            doc.AppendChild(root);

            foreach (TabPage page in tabControl1.Controls)
            {
                XmlElement section = doc.CreateElement("section");
                section.SetAttribute("name", page.Text);
                root.AppendChild(section);

                foreach (DataGridView data in page.Controls)
                {
                    foreach (DataGridViewRow row in data.Rows)
                    {
                        XmlElement parameter = doc.CreateElement("Parameter");
                        section.AppendChild(parameter);

                        parameter.SetAttribute("size", row.Cells[2].Value.ToString());
                        parameter.SetAttribute("type", row.Cells[3].Value.ToString());

                        XmlElement name = doc.CreateElement("name");
                        name.InnerText = row.Cells[0].Value.ToString();
                        parameter.AppendChild(name);

                        XmlElement value = doc.CreateElement("value");
                        value.InnerText = row.Cells[1].Value.ToString();
                        parameter.AppendChild(value);
                    }
                }
            }

            doc.Save(dialog.FileName);
            MessageBox.Show("Parameter File Saved Successfully!", "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
