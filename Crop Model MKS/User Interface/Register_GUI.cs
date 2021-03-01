using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CropModelMKS;

namespace CropModelMKS_GUI
{
    public partial class Register_GUI : Form
    {
        public Register_GUI()
        {
            InitializeComponent();

            cbx_language.Items.AddRange(new string[] { "C++", "Fortran", 
                "Python", "MATLAB"});
            cbx_language.SelectedIndex = 0;

            cbx_type.Items.AddRange(new string[] { "climate", "plant",
                "environment", "management", "analysis"});
            cbx_type.SelectedIndex = 0;
        }

        private void btn_browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                InitialDirectory = "Components/" + cbx_type.Text,
                Filter = "Library | *.dll",
                RestoreDirectory = true,
                FilterIndex = 1
            };

            if (dialog.ShowDialog() == DialogResult.Cancel)
            {
                txt_location.Text = "";
                return;
            }

            txt_location.Text = dialog.FileName;
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            if (txt_location.Text == "")
            {
                MessageBox.Show("Please Select the Location of the Library", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txt_ProgID.Text == "")
            {
                MessageBox.Show("Please Enter the ProgID of the Library", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Register register = new Register();
            register.Add(cbx_type.Text, cbx_language.Text,
                txt_location.Text, txt_ProgID.Text);
        }
    }
}
