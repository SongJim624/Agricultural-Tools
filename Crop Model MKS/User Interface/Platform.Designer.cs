
namespace CropModelMKS_GUI
{
    partial class Platform
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("climate");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("plant");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("environment");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("management");
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.registerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addOneComponentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkTheRegistrationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CropModelMKS_Tab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Simulator_Layout = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_simulate = new System.Windows.Forms.Button();
            this.begin_simulator = new System.Windows.Forms.DateTimePicker();
            this.btn_select_simulator = new System.Windows.Forms.Button();
            this.btn_save_simulation_project = new System.Windows.Forms.Button();
            this.btn_save_result = new System.Windows.Forms.Button();
            this.simulator_project = new System.Windows.Forms.TextBox();
            this.end_simulator = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.Modules_Tab = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.Climate_Table_Layout = new System.Windows.Forms.TableLayoutPanel();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.cli_begin = new System.Windows.Forms.DateTimePicker();
            this.label22 = new System.Windows.Forms.Label();
            this.cli_end = new System.Windows.Forms.DateTimePicker();
            this.cli_cbx = new System.Windows.Forms.ComboBox();
            this.btn_cli_remove = new System.Windows.Forms.Button();
            this.cli_parameters = new System.Windows.Forms.TextBox();
            this.btn_cli_select = new System.Windows.Forms.Button();
            this.btn_cli_create = new System.Windows.Forms.Button();
            this.climate_ListView = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_cli_add = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.Plant_Table_Layout = new System.Windows.Forms.TableLayoutPanel();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.plt_begin = new System.Windows.Forms.DateTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.plt_end = new System.Windows.Forms.DateTimePicker();
            this.plt_cbx = new System.Windows.Forms.ComboBox();
            this.btn_plt_remove = new System.Windows.Forms.Button();
            this.plt_parameters = new System.Windows.Forms.TextBox();
            this.btn_plt_select = new System.Windows.Forms.Button();
            this.btn_plt_create = new System.Windows.Forms.Button();
            this.plant_ListView = new System.Windows.Forms.ListView();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_plt_add = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.Environment_Table_Layout = new System.Windows.Forms.TableLayoutPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.env_begin = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.env_end = new System.Windows.Forms.DateTimePicker();
            this.env_cbx = new System.Windows.Forms.ComboBox();
            this.btn_env_remove = new System.Windows.Forms.Button();
            this.env_parameters = new System.Windows.Forms.TextBox();
            this.btn_env_select = new System.Windows.Forms.Button();
            this.btn_env_create = new System.Windows.Forms.Button();
            this.environment_ListView = new System.Windows.Forms.ListView();
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_env_add = new System.Windows.Forms.Button();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.Management_Table_Layout = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.mgt_begin = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.mgt_end = new System.Windows.Forms.DateTimePicker();
            this.mgt_cbx = new System.Windows.Forms.ComboBox();
            this.btn_mgt_remove = new System.Windows.Forms.Button();
            this.mgt_parameters = new System.Windows.Forms.TextBox();
            this.btn_mgt_select = new System.Windows.Forms.Button();
            this.btn_mgt_create = new System.Windows.Forms.Button();
            this.management_ListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_mgt_add = new System.Windows.Forms.Button();
            this.btn_display = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Analyzer_Layout = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_analyze = new System.Windows.Forms.Button();
            this.btn_select_simulation = new System.Windows.Forms.Button();
            this.btn_select_algorithm = new System.Windows.Forms.Button();
            this.btn_save_analysis = new System.Windows.Forms.Button();
            this.txt_analysis = new System.Windows.Forms.TextBox();
            this.txt_simulation = new System.Windows.Forms.TextBox();
            this.out_tree = new System.Windows.Forms.TreeView();
            this.input_tab = new System.Windows.Forms.TabControl();
            this.climate_input_tab = new System.Windows.Forms.TabPage();
            this.climate_inputs = new System.Windows.Forms.TabControl();
            this.plant_input_tab = new System.Windows.Forms.TabPage();
            this.plant_inputs = new System.Windows.Forms.TabControl();
            this.environment_input_tab = new System.Windows.Forms.TabPage();
            this.environment_inputs = new System.Windows.Forms.TabControl();
            this.management_input_tab = new System.Windows.Forms.TabPage();
            this.management_inputs = new System.Windows.Forms.TabControl();
            this.btn_select_analysis = new System.Windows.Forms.Button();
            this.analysis_cbx = new System.Windows.Forms.ComboBox();
            this.algorithm_datagrid = new System.Windows.Forms.DataGridView();
            this.Algorithm_Name_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Algorithm_Value_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Algorithm_Size_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Algorithm_Type_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            this.CropModelMKS_Tab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.Simulator_Layout.SuspendLayout();
            this.Modules_Tab.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.Climate_Table_Layout.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.Plant_Table_Layout.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.Environment_Table_Layout.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.Management_Table_Layout.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.Analyzer_Layout.SuspendLayout();
            this.input_tab.SuspendLayout();
            this.climate_input_tab.SuspendLayout();
            this.plant_input_tab.SuspendLayout();
            this.environment_input_tab.SuspendLayout();
            this.management_input_tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.algorithm_datagrid)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // registerToolStripMenuItem
            // 
            this.registerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addOneComponentToolStripMenuItem,
            this.checkTheRegistrationsToolStripMenuItem});
            this.registerToolStripMenuItem.Name = "registerToolStripMenuItem";
            this.registerToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.registerToolStripMenuItem.Text = "Register";
            // 
            // addOneComponentToolStripMenuItem
            // 
            this.addOneComponentToolStripMenuItem.Name = "addOneComponentToolStripMenuItem";
            this.addOneComponentToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.addOneComponentToolStripMenuItem.Text = "Add One Component";
            this.addOneComponentToolStripMenuItem.Click += new System.EventHandler(this.addOneComponentToolStripMenuItem_Click);
            // 
            // checkTheRegistrationsToolStripMenuItem
            // 
            this.checkTheRegistrationsToolStripMenuItem.Name = "checkTheRegistrationsToolStripMenuItem";
            this.checkTheRegistrationsToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.checkTheRegistrationsToolStripMenuItem.Text = "Check the Registrations";
            this.checkTheRegistrationsToolStripMenuItem.Click += new System.EventHandler(this.checkTheRegistrationsToolStripMenuItem_Click);
            // 
            // CropModelMKS_Tab
            // 
            this.CropModelMKS_Tab.Controls.Add(this.tabPage1);
            this.CropModelMKS_Tab.Controls.Add(this.tabPage2);
            this.CropModelMKS_Tab.Location = new System.Drawing.Point(0, 28);
            this.CropModelMKS_Tab.Name = "CropModelMKS_Tab";
            this.CropModelMKS_Tab.SelectedIndex = 0;
            this.CropModelMKS_Tab.Size = new System.Drawing.Size(800, 397);
            this.CropModelMKS_Tab.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Simulator_Layout);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 371);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Simulator";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Simulator_Layout
            // 
            this.Simulator_Layout.ColumnCount = 6;
            this.Simulator_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.Simulator_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.Simulator_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.Simulator_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.Simulator_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.Simulator_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.Simulator_Layout.Controls.Add(this.label1, 0, 0);
            this.Simulator_Layout.Controls.Add(this.label2, 0, 1);
            this.Simulator_Layout.Controls.Add(this.btn_simulate, 0, 3);
            this.Simulator_Layout.Controls.Add(this.begin_simulator, 1, 1);
            this.Simulator_Layout.Controls.Add(this.btn_select_simulator, 5, 0);
            this.Simulator_Layout.Controls.Add(this.btn_save_simulation_project, 5, 3);
            this.Simulator_Layout.Controls.Add(this.btn_save_result, 4, 3);
            this.Simulator_Layout.Controls.Add(this.simulator_project, 1, 0);
            this.Simulator_Layout.Controls.Add(this.end_simulator, 5, 1);
            this.Simulator_Layout.Controls.Add(this.label3, 4, 1);
            this.Simulator_Layout.Controls.Add(this.Modules_Tab, 0, 2);
            this.Simulator_Layout.Controls.Add(this.btn_display, 1, 3);
            this.Simulator_Layout.Location = new System.Drawing.Point(0, 0);
            this.Simulator_Layout.Name = "Simulator_Layout";
            this.Simulator_Layout.RowCount = 4;
            this.Simulator_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.Simulator_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.Simulator_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.Simulator_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.Simulator_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Simulator_Layout.Size = new System.Drawing.Size(796, 371);
            this.Simulator_Layout.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Simulation Project";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Begins at:";
            // 
            // btn_simulate
            // 
            this.btn_simulate.Location = new System.Drawing.Point(3, 348);
            this.btn_simulate.Name = "btn_simulate";
            this.btn_simulate.Size = new System.Drawing.Size(120, 21);
            this.btn_simulate.TabIndex = 8;
            this.btn_simulate.Text = "Simulate";
            this.btn_simulate.UseVisualStyleBackColor = true;
            this.btn_simulate.Click += new System.EventHandler(this.btn_simulate_Click);
            // 
            // begin_simulator
            // 
            this.begin_simulator.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.begin_simulator.Location = new System.Drawing.Point(134, 30);
            this.begin_simulator.Name = "begin_simulator";
            this.begin_simulator.Size = new System.Drawing.Size(120, 21);
            this.begin_simulator.TabIndex = 3;
            // 
            // btn_select_simulator
            // 
            this.btn_select_simulator.Location = new System.Drawing.Point(662, 3);
            this.btn_select_simulator.Name = "btn_select_simulator";
            this.btn_select_simulator.Size = new System.Drawing.Size(120, 21);
            this.btn_select_simulator.TabIndex = 6;
            this.btn_select_simulator.Text = "Selece Project";
            this.btn_select_simulator.UseVisualStyleBackColor = true;
            this.btn_select_simulator.Click += new System.EventHandler(this.btn_select_simulator_Click);
            // 
            // btn_save_simulation_project
            // 
            this.btn_save_simulation_project.Location = new System.Drawing.Point(662, 348);
            this.btn_save_simulation_project.Name = "btn_save_simulation_project";
            this.btn_save_simulation_project.Size = new System.Drawing.Size(120, 21);
            this.btn_save_simulation_project.TabIndex = 7;
            this.btn_save_simulation_project.Text = "Save Project";
            this.btn_save_simulation_project.UseVisualStyleBackColor = true;
            this.btn_save_simulation_project.Click += new System.EventHandler(this.btn_save_simulation_project_Click);
            // 
            // btn_save_result
            // 
            this.btn_save_result.Location = new System.Drawing.Point(536, 348);
            this.btn_save_result.Name = "btn_save_result";
            this.btn_save_result.Size = new System.Drawing.Size(120, 21);
            this.btn_save_result.TabIndex = 9;
            this.btn_save_result.Text = "Save Result";
            this.btn_save_result.UseVisualStyleBackColor = true;
            // 
            // simulator_project
            // 
            this.Simulator_Layout.SetColumnSpan(this.simulator_project, 4);
            this.simulator_project.Location = new System.Drawing.Point(134, 3);
            this.simulator_project.Name = "simulator_project";
            this.simulator_project.Size = new System.Drawing.Size(522, 21);
            this.simulator_project.TabIndex = 2;
            // 
            // end_simulator
            // 
            this.end_simulator.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.end_simulator.Location = new System.Drawing.Point(662, 30);
            this.end_simulator.Name = "end_simulator";
            this.end_simulator.Size = new System.Drawing.Size(120, 21);
            this.end_simulator.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(536, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ends at:";
            // 
            // Modules_Tab
            // 
            this.Simulator_Layout.SetColumnSpan(this.Modules_Tab, 6);
            this.Modules_Tab.Controls.Add(this.tabPage3);
            this.Modules_Tab.Controls.Add(this.tabPage4);
            this.Modules_Tab.Controls.Add(this.tabPage5);
            this.Modules_Tab.Controls.Add(this.tabPage6);
            this.Modules_Tab.Location = new System.Drawing.Point(3, 57);
            this.Modules_Tab.Name = "Modules_Tab";
            this.Modules_Tab.SelectedIndex = 0;
            this.Modules_Tab.Size = new System.Drawing.Size(786, 285);
            this.Modules_Tab.TabIndex = 10;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.Climate_Table_Layout);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(778, 259);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Climate";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // Climate_Table_Layout
            // 
            this.Climate_Table_Layout.ColumnCount = 4;
            this.Climate_Table_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.Climate_Table_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.82645F));
            this.Climate_Table_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.Climate_Table_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.Climate_Table_Layout.Controls.Add(this.label19, 0, 0);
            this.Climate_Table_Layout.Controls.Add(this.label20, 0, 1);
            this.Climate_Table_Layout.Controls.Add(this.label21, 0, 2);
            this.Climate_Table_Layout.Controls.Add(this.cli_begin, 1, 0);
            this.Climate_Table_Layout.Controls.Add(this.label22, 2, 0);
            this.Climate_Table_Layout.Controls.Add(this.cli_end, 3, 0);
            this.Climate_Table_Layout.Controls.Add(this.cli_cbx, 1, 1);
            this.Climate_Table_Layout.Controls.Add(this.btn_cli_remove, 3, 1);
            this.Climate_Table_Layout.Controls.Add(this.cli_parameters, 1, 2);
            this.Climate_Table_Layout.Controls.Add(this.btn_cli_select, 2, 2);
            this.Climate_Table_Layout.Controls.Add(this.btn_cli_create, 3, 2);
            this.Climate_Table_Layout.Controls.Add(this.climate_ListView, 0, 3);
            this.Climate_Table_Layout.Controls.Add(this.btn_cli_add, 2, 1);
            this.Climate_Table_Layout.Location = new System.Drawing.Point(0, 0);
            this.Climate_Table_Layout.Name = "Climate_Table_Layout";
            this.Climate_Table_Layout.RowCount = 4;
            this.Climate_Table_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.Climate_Table_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.Climate_Table_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.Climate_Table_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 132F));
            this.Climate_Table_Layout.Size = new System.Drawing.Size(778, 259);
            this.Climate_Table_Layout.TabIndex = 1;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(3, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(120, 21);
            this.label19.TabIndex = 0;
            this.label19.Text = "From";
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(3, 27);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(120, 21);
            this.label20.TabIndex = 1;
            this.label20.Text = "ProgID";
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(3, 54);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(120, 21);
            this.label21.TabIndex = 2;
            this.label21.Text = "Parameter";
            // 
            // cli_begin
            // 
            this.cli_begin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.cli_begin.Location = new System.Drawing.Point(129, 3);
            this.cli_begin.Name = "cli_begin";
            this.cli_begin.Size = new System.Drawing.Size(120, 21);
            this.cli_begin.TabIndex = 4;
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(529, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(120, 21);
            this.label22.TabIndex = 3;
            this.label22.Text = "To";
            // 
            // cli_end
            // 
            this.cli_end.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.cli_end.Location = new System.Drawing.Point(655, 3);
            this.cli_end.Name = "cli_end";
            this.cli_end.Size = new System.Drawing.Size(120, 21);
            this.cli_end.TabIndex = 5;
            // 
            // cli_cbx
            // 
            this.cli_cbx.FormattingEnabled = true;
            this.cli_cbx.Location = new System.Drawing.Point(129, 30);
            this.cli_cbx.Name = "cli_cbx";
            this.cli_cbx.Size = new System.Drawing.Size(394, 20);
            this.cli_cbx.TabIndex = 6;
            // 
            // btn_cli_remove
            // 
            this.btn_cli_remove.Location = new System.Drawing.Point(655, 30);
            this.btn_cli_remove.Name = "btn_cli_remove";
            this.btn_cli_remove.Size = new System.Drawing.Size(120, 21);
            this.btn_cli_remove.TabIndex = 7;
            this.btn_cli_remove.Text = "Remove";
            this.btn_cli_remove.UseVisualStyleBackColor = true;
            this.btn_cli_remove.Click += new System.EventHandler(this.btn_cli_remove_Click);
            // 
            // cli_parameters
            // 
            this.cli_parameters.Location = new System.Drawing.Point(129, 57);
            this.cli_parameters.Name = "cli_parameters";
            this.cli_parameters.Size = new System.Drawing.Size(394, 21);
            this.cli_parameters.TabIndex = 8;
            // 
            // btn_cli_select
            // 
            this.btn_cli_select.Location = new System.Drawing.Point(529, 57);
            this.btn_cli_select.Name = "btn_cli_select";
            this.btn_cli_select.Size = new System.Drawing.Size(120, 21);
            this.btn_cli_select.TabIndex = 9;
            this.btn_cli_select.Text = "Select";
            this.btn_cli_select.UseVisualStyleBackColor = true;
            this.btn_cli_select.Click += new System.EventHandler(this.btn_cli_select_Click);
            // 
            // btn_cli_create
            // 
            this.btn_cli_create.Location = new System.Drawing.Point(655, 57);
            this.btn_cli_create.Name = "btn_cli_create";
            this.btn_cli_create.Size = new System.Drawing.Size(120, 21);
            this.btn_cli_create.TabIndex = 10;
            this.btn_cli_create.Text = "Create";
            this.btn_cli_create.UseVisualStyleBackColor = true;
            this.btn_cli_create.Click += new System.EventHandler(this.btn_cli_create_Click);
            // 
            // climate_ListView
            // 
            this.climate_ListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.Climate_Table_Layout.SetColumnSpan(this.climate_ListView, 6);
            this.climate_ListView.HideSelection = false;
            this.climate_ListView.Location = new System.Drawing.Point(3, 84);
            this.climate_ListView.Name = "climate_ListView";
            this.climate_ListView.Size = new System.Drawing.Size(772, 172);
            this.climate_ListView.TabIndex = 11;
            this.climate_ListView.UseCompatibleStateImageBehavior = false;
            this.climate_ListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Begins At";
            this.columnHeader5.Width = 160;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Ends At";
            this.columnHeader6.Width = 160;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "ProgID";
            this.columnHeader7.Width = 200;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Parameters";
            this.columnHeader8.Width = 252;
            // 
            // btn_cli_add
            // 
            this.btn_cli_add.Location = new System.Drawing.Point(529, 30);
            this.btn_cli_add.Name = "btn_cli_add";
            this.btn_cli_add.Size = new System.Drawing.Size(120, 21);
            this.btn_cli_add.TabIndex = 12;
            this.btn_cli_add.Text = "Add";
            this.btn_cli_add.UseVisualStyleBackColor = true;
            this.btn_cli_add.Click += new System.EventHandler(this.btn_cli_add_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.Plant_Table_Layout);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(778, 259);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Plant";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // Plant_Table_Layout
            // 
            this.Plant_Table_Layout.ColumnCount = 4;
            this.Plant_Table_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.Plant_Table_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.82645F));
            this.Plant_Table_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.Plant_Table_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.Plant_Table_Layout.Controls.Add(this.label15, 0, 0);
            this.Plant_Table_Layout.Controls.Add(this.label16, 0, 1);
            this.Plant_Table_Layout.Controls.Add(this.label17, 0, 2);
            this.Plant_Table_Layout.Controls.Add(this.plt_begin, 1, 0);
            this.Plant_Table_Layout.Controls.Add(this.label18, 2, 0);
            this.Plant_Table_Layout.Controls.Add(this.plt_end, 3, 0);
            this.Plant_Table_Layout.Controls.Add(this.plt_cbx, 1, 1);
            this.Plant_Table_Layout.Controls.Add(this.btn_plt_remove, 3, 1);
            this.Plant_Table_Layout.Controls.Add(this.plt_parameters, 1, 2);
            this.Plant_Table_Layout.Controls.Add(this.btn_plt_select, 2, 2);
            this.Plant_Table_Layout.Controls.Add(this.btn_plt_create, 3, 2);
            this.Plant_Table_Layout.Controls.Add(this.plant_ListView, 0, 3);
            this.Plant_Table_Layout.Controls.Add(this.btn_plt_add, 2, 1);
            this.Plant_Table_Layout.Location = new System.Drawing.Point(0, 0);
            this.Plant_Table_Layout.Name = "Plant_Table_Layout";
            this.Plant_Table_Layout.RowCount = 4;
            this.Plant_Table_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.Plant_Table_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.Plant_Table_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.Plant_Table_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 132F));
            this.Plant_Table_Layout.Size = new System.Drawing.Size(778, 259);
            this.Plant_Table_Layout.TabIndex = 2;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(3, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(120, 21);
            this.label15.TabIndex = 0;
            this.label15.Text = "From";
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(3, 27);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(120, 21);
            this.label16.TabIndex = 1;
            this.label16.Text = "ProgID";
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(3, 54);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(120, 21);
            this.label17.TabIndex = 2;
            this.label17.Text = "Parameter";
            // 
            // plt_begin
            // 
            this.plt_begin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.plt_begin.Location = new System.Drawing.Point(129, 3);
            this.plt_begin.Name = "plt_begin";
            this.plt_begin.Size = new System.Drawing.Size(120, 21);
            this.plt_begin.TabIndex = 4;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(529, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(120, 21);
            this.label18.TabIndex = 3;
            this.label18.Text = "To";
            // 
            // plt_end
            // 
            this.plt_end.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.plt_end.Location = new System.Drawing.Point(655, 3);
            this.plt_end.Name = "plt_end";
            this.plt_end.Size = new System.Drawing.Size(120, 21);
            this.plt_end.TabIndex = 5;
            // 
            // plt_cbx
            // 
            this.plt_cbx.FormattingEnabled = true;
            this.plt_cbx.Location = new System.Drawing.Point(129, 30);
            this.plt_cbx.Name = "plt_cbx";
            this.plt_cbx.Size = new System.Drawing.Size(394, 20);
            this.plt_cbx.TabIndex = 6;
            // 
            // btn_plt_remove
            // 
            this.btn_plt_remove.Location = new System.Drawing.Point(655, 30);
            this.btn_plt_remove.Name = "btn_plt_remove";
            this.btn_plt_remove.Size = new System.Drawing.Size(120, 21);
            this.btn_plt_remove.TabIndex = 7;
            this.btn_plt_remove.Text = "Remove";
            this.btn_plt_remove.UseVisualStyleBackColor = true;
            this.btn_plt_remove.Click += new System.EventHandler(this.btn_plt_remove_Click);
            // 
            // plt_parameters
            // 
            this.plt_parameters.Location = new System.Drawing.Point(129, 57);
            this.plt_parameters.Name = "plt_parameters";
            this.plt_parameters.Size = new System.Drawing.Size(394, 21);
            this.plt_parameters.TabIndex = 8;
            // 
            // btn_plt_select
            // 
            this.btn_plt_select.Location = new System.Drawing.Point(529, 57);
            this.btn_plt_select.Name = "btn_plt_select";
            this.btn_plt_select.Size = new System.Drawing.Size(120, 21);
            this.btn_plt_select.TabIndex = 9;
            this.btn_plt_select.Text = "Select";
            this.btn_plt_select.UseVisualStyleBackColor = true;
            this.btn_plt_select.Click += new System.EventHandler(this.btn_plt_select_Click);
            // 
            // btn_plt_create
            // 
            this.btn_plt_create.Location = new System.Drawing.Point(655, 57);
            this.btn_plt_create.Name = "btn_plt_create";
            this.btn_plt_create.Size = new System.Drawing.Size(120, 21);
            this.btn_plt_create.TabIndex = 10;
            this.btn_plt_create.Text = "Create";
            this.btn_plt_create.UseVisualStyleBackColor = true;
            // 
            // plant_ListView
            // 
            this.plant_ListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12});
            this.Plant_Table_Layout.SetColumnSpan(this.plant_ListView, 6);
            this.plant_ListView.HideSelection = false;
            this.plant_ListView.Location = new System.Drawing.Point(3, 84);
            this.plant_ListView.Name = "plant_ListView";
            this.plant_ListView.Size = new System.Drawing.Size(772, 172);
            this.plant_ListView.TabIndex = 11;
            this.plant_ListView.UseCompatibleStateImageBehavior = false;
            this.plant_ListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Begins At";
            this.columnHeader9.Width = 160;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Ends At";
            this.columnHeader10.Width = 160;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "ProgID";
            this.columnHeader11.Width = 200;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Parameters";
            this.columnHeader12.Width = 252;
            // 
            // btn_plt_add
            // 
            this.btn_plt_add.Location = new System.Drawing.Point(529, 30);
            this.btn_plt_add.Name = "btn_plt_add";
            this.btn_plt_add.Size = new System.Drawing.Size(120, 21);
            this.btn_plt_add.TabIndex = 12;
            this.btn_plt_add.Text = "Add";
            this.btn_plt_add.UseVisualStyleBackColor = true;
            this.btn_plt_add.Click += new System.EventHandler(this.btn_plt_add_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.Environment_Table_Layout);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(778, 259);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "Environment";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // Environment_Table_Layout
            // 
            this.Environment_Table_Layout.ColumnCount = 4;
            this.Environment_Table_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.Environment_Table_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.82645F));
            this.Environment_Table_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.Environment_Table_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.Environment_Table_Layout.Controls.Add(this.label11, 0, 0);
            this.Environment_Table_Layout.Controls.Add(this.label12, 0, 1);
            this.Environment_Table_Layout.Controls.Add(this.label13, 0, 2);
            this.Environment_Table_Layout.Controls.Add(this.env_begin, 1, 0);
            this.Environment_Table_Layout.Controls.Add(this.label14, 2, 0);
            this.Environment_Table_Layout.Controls.Add(this.env_end, 3, 0);
            this.Environment_Table_Layout.Controls.Add(this.env_cbx, 1, 1);
            this.Environment_Table_Layout.Controls.Add(this.btn_env_remove, 3, 1);
            this.Environment_Table_Layout.Controls.Add(this.env_parameters, 1, 2);
            this.Environment_Table_Layout.Controls.Add(this.btn_env_select, 2, 2);
            this.Environment_Table_Layout.Controls.Add(this.btn_env_create, 3, 2);
            this.Environment_Table_Layout.Controls.Add(this.environment_ListView, 0, 3);
            this.Environment_Table_Layout.Controls.Add(this.btn_env_add, 2, 1);
            this.Environment_Table_Layout.Location = new System.Drawing.Point(0, 0);
            this.Environment_Table_Layout.Name = "Environment_Table_Layout";
            this.Environment_Table_Layout.RowCount = 4;
            this.Environment_Table_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.Environment_Table_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.Environment_Table_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.Environment_Table_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 132F));
            this.Environment_Table_Layout.Size = new System.Drawing.Size(778, 259);
            this.Environment_Table_Layout.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(3, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(120, 21);
            this.label11.TabIndex = 0;
            this.label11.Text = "From";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(3, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(120, 21);
            this.label12.TabIndex = 1;
            this.label12.Text = "ProgID";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(3, 54);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(120, 21);
            this.label13.TabIndex = 2;
            this.label13.Text = "Parameter";
            // 
            // env_begin
            // 
            this.env_begin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.env_begin.Location = new System.Drawing.Point(129, 3);
            this.env_begin.Name = "env_begin";
            this.env_begin.Size = new System.Drawing.Size(120, 21);
            this.env_begin.TabIndex = 4;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(529, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(120, 21);
            this.label14.TabIndex = 3;
            this.label14.Text = "To";
            // 
            // env_end
            // 
            this.env_end.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.env_end.Location = new System.Drawing.Point(655, 3);
            this.env_end.Name = "env_end";
            this.env_end.Size = new System.Drawing.Size(120, 21);
            this.env_end.TabIndex = 5;
            // 
            // env_cbx
            // 
            this.env_cbx.FormattingEnabled = true;
            this.env_cbx.Location = new System.Drawing.Point(129, 30);
            this.env_cbx.Name = "env_cbx";
            this.env_cbx.Size = new System.Drawing.Size(394, 20);
            this.env_cbx.TabIndex = 6;
            // 
            // btn_env_remove
            // 
            this.btn_env_remove.Location = new System.Drawing.Point(655, 30);
            this.btn_env_remove.Name = "btn_env_remove";
            this.btn_env_remove.Size = new System.Drawing.Size(120, 21);
            this.btn_env_remove.TabIndex = 7;
            this.btn_env_remove.Text = "Remove";
            this.btn_env_remove.UseVisualStyleBackColor = true;
            this.btn_env_remove.Click += new System.EventHandler(this.btn_env_remove_Click);
            // 
            // env_parameters
            // 
            this.env_parameters.Location = new System.Drawing.Point(129, 57);
            this.env_parameters.Name = "env_parameters";
            this.env_parameters.Size = new System.Drawing.Size(394, 21);
            this.env_parameters.TabIndex = 8;
            // 
            // btn_env_select
            // 
            this.btn_env_select.Location = new System.Drawing.Point(529, 57);
            this.btn_env_select.Name = "btn_env_select";
            this.btn_env_select.Size = new System.Drawing.Size(120, 21);
            this.btn_env_select.TabIndex = 9;
            this.btn_env_select.Text = "Select";
            this.btn_env_select.UseVisualStyleBackColor = true;
            this.btn_env_select.Click += new System.EventHandler(this.btn_env_select_Click);
            // 
            // btn_env_create
            // 
            this.btn_env_create.Location = new System.Drawing.Point(655, 57);
            this.btn_env_create.Name = "btn_env_create";
            this.btn_env_create.Size = new System.Drawing.Size(120, 21);
            this.btn_env_create.TabIndex = 10;
            this.btn_env_create.Text = "Create";
            this.btn_env_create.UseVisualStyleBackColor = true;
            // 
            // environment_ListView
            // 
            this.environment_ListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16});
            this.Environment_Table_Layout.SetColumnSpan(this.environment_ListView, 6);
            this.environment_ListView.HideSelection = false;
            this.environment_ListView.Location = new System.Drawing.Point(3, 84);
            this.environment_ListView.Name = "environment_ListView";
            this.environment_ListView.Size = new System.Drawing.Size(772, 172);
            this.environment_ListView.TabIndex = 11;
            this.environment_ListView.UseCompatibleStateImageBehavior = false;
            this.environment_ListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Begins At";
            this.columnHeader13.Width = 160;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Ends At";
            this.columnHeader14.Width = 160;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "ProgID";
            this.columnHeader15.Width = 200;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Parameters";
            this.columnHeader16.Width = 252;
            // 
            // btn_env_add
            // 
            this.btn_env_add.Location = new System.Drawing.Point(529, 30);
            this.btn_env_add.Name = "btn_env_add";
            this.btn_env_add.Size = new System.Drawing.Size(120, 21);
            this.btn_env_add.TabIndex = 12;
            this.btn_env_add.Text = "Add";
            this.btn_env_add.UseVisualStyleBackColor = true;
            this.btn_env_add.Click += new System.EventHandler(this.btn_env_add_Click);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.Management_Table_Layout);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(778, 259);
            this.tabPage6.TabIndex = 3;
            this.tabPage6.Text = "Management";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // Management_Table_Layout
            // 
            this.Management_Table_Layout.ColumnCount = 4;
            this.Management_Table_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.Management_Table_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.82645F));
            this.Management_Table_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.Management_Table_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.Management_Table_Layout.Controls.Add(this.label7, 0, 0);
            this.Management_Table_Layout.Controls.Add(this.label8, 0, 1);
            this.Management_Table_Layout.Controls.Add(this.label9, 0, 2);
            this.Management_Table_Layout.Controls.Add(this.mgt_begin, 1, 0);
            this.Management_Table_Layout.Controls.Add(this.label10, 2, 0);
            this.Management_Table_Layout.Controls.Add(this.mgt_end, 3, 0);
            this.Management_Table_Layout.Controls.Add(this.mgt_cbx, 1, 1);
            this.Management_Table_Layout.Controls.Add(this.btn_mgt_remove, 3, 1);
            this.Management_Table_Layout.Controls.Add(this.mgt_parameters, 1, 2);
            this.Management_Table_Layout.Controls.Add(this.btn_mgt_select, 2, 2);
            this.Management_Table_Layout.Controls.Add(this.btn_mgt_create, 3, 2);
            this.Management_Table_Layout.Controls.Add(this.management_ListView, 0, 3);
            this.Management_Table_Layout.Controls.Add(this.btn_mgt_add, 2, 1);
            this.Management_Table_Layout.Location = new System.Drawing.Point(0, 0);
            this.Management_Table_Layout.Name = "Management_Table_Layout";
            this.Management_Table_Layout.RowCount = 4;
            this.Management_Table_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.Management_Table_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.Management_Table_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.Management_Table_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 132F));
            this.Management_Table_Layout.Size = new System.Drawing.Size(778, 259);
            this.Management_Table_Layout.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 21);
            this.label7.TabIndex = 0;
            this.label7.Text = "From";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(3, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 21);
            this.label8.TabIndex = 1;
            this.label8.Text = "ProgID";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(3, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 21);
            this.label9.TabIndex = 2;
            this.label9.Text = "Parameter";
            // 
            // mgt_begin
            // 
            this.mgt_begin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.mgt_begin.Location = new System.Drawing.Point(129, 3);
            this.mgt_begin.Name = "mgt_begin";
            this.mgt_begin.Size = new System.Drawing.Size(120, 21);
            this.mgt_begin.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(529, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(120, 21);
            this.label10.TabIndex = 3;
            this.label10.Text = "To";
            // 
            // mgt_end
            // 
            this.mgt_end.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.mgt_end.Location = new System.Drawing.Point(655, 3);
            this.mgt_end.Name = "mgt_end";
            this.mgt_end.Size = new System.Drawing.Size(120, 21);
            this.mgt_end.TabIndex = 5;
            // 
            // mgt_cbx
            // 
            this.mgt_cbx.FormattingEnabled = true;
            this.mgt_cbx.Location = new System.Drawing.Point(129, 30);
            this.mgt_cbx.Name = "mgt_cbx";
            this.mgt_cbx.Size = new System.Drawing.Size(394, 20);
            this.mgt_cbx.TabIndex = 6;
            // 
            // btn_mgt_remove
            // 
            this.btn_mgt_remove.Location = new System.Drawing.Point(655, 30);
            this.btn_mgt_remove.Name = "btn_mgt_remove";
            this.btn_mgt_remove.Size = new System.Drawing.Size(120, 21);
            this.btn_mgt_remove.TabIndex = 7;
            this.btn_mgt_remove.Text = "Remove";
            this.btn_mgt_remove.UseVisualStyleBackColor = true;
            this.btn_mgt_remove.Click += new System.EventHandler(this.btn_mgt_remove_Click);
            // 
            // mgt_parameters
            // 
            this.mgt_parameters.Location = new System.Drawing.Point(129, 57);
            this.mgt_parameters.Name = "mgt_parameters";
            this.mgt_parameters.Size = new System.Drawing.Size(394, 21);
            this.mgt_parameters.TabIndex = 8;
            // 
            // btn_mgt_select
            // 
            this.btn_mgt_select.Location = new System.Drawing.Point(529, 57);
            this.btn_mgt_select.Name = "btn_mgt_select";
            this.btn_mgt_select.Size = new System.Drawing.Size(120, 21);
            this.btn_mgt_select.TabIndex = 9;
            this.btn_mgt_select.Text = "Select";
            this.btn_mgt_select.UseVisualStyleBackColor = true;
            this.btn_mgt_select.Click += new System.EventHandler(this.btn_mgt_select_Click);
            // 
            // btn_mgt_create
            // 
            this.btn_mgt_create.Location = new System.Drawing.Point(655, 57);
            this.btn_mgt_create.Name = "btn_mgt_create";
            this.btn_mgt_create.Size = new System.Drawing.Size(120, 21);
            this.btn_mgt_create.TabIndex = 10;
            this.btn_mgt_create.Text = "Create";
            this.btn_mgt_create.UseVisualStyleBackColor = true;
            // 
            // management_ListView
            // 
            this.management_ListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.Management_Table_Layout.SetColumnSpan(this.management_ListView, 6);
            this.management_ListView.HideSelection = false;
            this.management_ListView.Location = new System.Drawing.Point(3, 84);
            this.management_ListView.Name = "management_ListView";
            this.management_ListView.Size = new System.Drawing.Size(772, 172);
            this.management_ListView.TabIndex = 11;
            this.management_ListView.UseCompatibleStateImageBehavior = false;
            this.management_ListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Begins At";
            this.columnHeader1.Width = 160;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Ends At";
            this.columnHeader2.Width = 160;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "ProgID";
            this.columnHeader3.Width = 200;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Parameters";
            this.columnHeader4.Width = 252;
            // 
            // btn_mgt_add
            // 
            this.btn_mgt_add.Location = new System.Drawing.Point(529, 30);
            this.btn_mgt_add.Name = "btn_mgt_add";
            this.btn_mgt_add.Size = new System.Drawing.Size(120, 21);
            this.btn_mgt_add.TabIndex = 12;
            this.btn_mgt_add.Text = "Add";
            this.btn_mgt_add.UseVisualStyleBackColor = true;
            this.btn_mgt_add.Click += new System.EventHandler(this.btn_mgt_add_Click);
            // 
            // btn_display
            // 
            this.btn_display.Location = new System.Drawing.Point(134, 348);
            this.btn_display.Name = "btn_display";
            this.btn_display.Size = new System.Drawing.Size(120, 21);
            this.btn_display.TabIndex = 11;
            this.btn_display.Text = "Display";
            this.btn_display.UseVisualStyleBackColor = true;
            this.btn_display.Click += new System.EventHandler(this.btn_display_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.Analyzer_Layout);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 371);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Analyzer";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Analyzer_Layout
            // 
            this.Analyzer_Layout.ColumnCount = 3;
            this.Analyzer_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.05814F));
            this.Analyzer_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.94186F));
            this.Analyzer_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.Analyzer_Layout.Controls.Add(this.label4, 0, 0);
            this.Analyzer_Layout.Controls.Add(this.label5, 0, 1);
            this.Analyzer_Layout.Controls.Add(this.label6, 0, 2);
            this.Analyzer_Layout.Controls.Add(this.btn_analyze, 0, 4);
            this.Analyzer_Layout.Controls.Add(this.btn_select_simulation, 2, 1);
            this.Analyzer_Layout.Controls.Add(this.btn_select_algorithm, 2, 2);
            this.Analyzer_Layout.Controls.Add(this.btn_save_analysis, 2, 4);
            this.Analyzer_Layout.Controls.Add(this.txt_analysis, 1, 0);
            this.Analyzer_Layout.Controls.Add(this.txt_simulation, 1, 1);
            this.Analyzer_Layout.Controls.Add(this.out_tree, 2, 3);
            this.Analyzer_Layout.Controls.Add(this.input_tab, 1, 3);
            this.Analyzer_Layout.Controls.Add(this.btn_select_analysis, 2, 0);
            this.Analyzer_Layout.Controls.Add(this.analysis_cbx, 1, 2);
            this.Analyzer_Layout.Controls.Add(this.algorithm_datagrid, 0, 3);
            this.Analyzer_Layout.Location = new System.Drawing.Point(0, 0);
            this.Analyzer_Layout.Name = "Analyzer_Layout";
            this.Analyzer_Layout.RowCount = 5;
            this.Analyzer_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.Analyzer_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.Analyzer_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.Analyzer_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.Analyzer_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.Analyzer_Layout.Size = new System.Drawing.Size(792, 371);
            this.Analyzer_Layout.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "Analysis Project";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 21);
            this.label5.TabIndex = 1;
            this.label5.Text = "Simulation Project";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(3, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 21);
            this.label6.TabIndex = 2;
            this.label6.Text = "Algorithm Component";
            // 
            // btn_analyze
            // 
            this.btn_analyze.Location = new System.Drawing.Point(3, 351);
            this.btn_analyze.Name = "btn_analyze";
            this.btn_analyze.Size = new System.Drawing.Size(120, 21);
            this.btn_analyze.TabIndex = 3;
            this.btn_analyze.Text = "Analyze";
            this.btn_analyze.UseVisualStyleBackColor = true;
            this.btn_analyze.Click += new System.EventHandler(this.btn_analyze_Click);
            // 
            // btn_select_simulation
            // 
            this.btn_select_simulation.Location = new System.Drawing.Point(668, 30);
            this.btn_select_simulation.Name = "btn_select_simulation";
            this.btn_select_simulation.Size = new System.Drawing.Size(120, 21);
            this.btn_select_simulation.TabIndex = 5;
            this.btn_select_simulation.Text = "Select Project";
            this.btn_select_simulation.UseVisualStyleBackColor = true;
            this.btn_select_simulation.Click += new System.EventHandler(this.btn_select_simulation_Click);
            // 
            // btn_select_algorithm
            // 
            this.btn_select_algorithm.Location = new System.Drawing.Point(668, 57);
            this.btn_select_algorithm.Name = "btn_select_algorithm";
            this.btn_select_algorithm.Size = new System.Drawing.Size(120, 21);
            this.btn_select_algorithm.TabIndex = 6;
            this.btn_select_algorithm.Text = "Select Algorithm";
            this.btn_select_algorithm.UseVisualStyleBackColor = true;
            this.btn_select_algorithm.Click += new System.EventHandler(this.btn_select_algorithm_Click);
            // 
            // btn_save_analysis
            // 
            this.btn_save_analysis.Location = new System.Drawing.Point(668, 351);
            this.btn_save_analysis.Name = "btn_save_analysis";
            this.btn_save_analysis.Size = new System.Drawing.Size(120, 21);
            this.btn_save_analysis.TabIndex = 7;
            this.btn_save_analysis.Text = "Save Project";
            this.btn_save_analysis.UseVisualStyleBackColor = true;
            this.btn_save_analysis.Click += new System.EventHandler(this.btn_save_analysis_Click);
            // 
            // txt_analysis
            // 
            this.txt_analysis.Location = new System.Drawing.Point(136, 3);
            this.txt_analysis.Name = "txt_analysis";
            this.txt_analysis.Size = new System.Drawing.Size(522, 21);
            this.txt_analysis.TabIndex = 8;
            // 
            // txt_simulation
            // 
            this.txt_simulation.Location = new System.Drawing.Point(136, 30);
            this.txt_simulation.Name = "txt_simulation";
            this.txt_simulation.Size = new System.Drawing.Size(522, 21);
            this.txt_simulation.TabIndex = 9;
            // 
            // out_tree
            // 
            this.out_tree.CheckBoxes = true;
            this.out_tree.Location = new System.Drawing.Point(668, 86);
            this.out_tree.Name = "out_tree";
            treeNode1.Checked = true;
            treeNode1.Name = "Climate_Node";
            treeNode1.Text = "climate";
            treeNode2.Checked = true;
            treeNode2.Name = "Plant_Node";
            treeNode2.Text = "plant";
            treeNode3.Checked = true;
            treeNode3.Name = "Environment_Node";
            treeNode3.Text = "environment";
            treeNode4.Checked = true;
            treeNode4.Name = "Management_Node";
            treeNode4.Text = "management";
            this.out_tree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            this.out_tree.Size = new System.Drawing.Size(120, 259);
            this.out_tree.TabIndex = 11;
            // 
            // input_tab
            // 
            this.input_tab.Controls.Add(this.climate_input_tab);
            this.input_tab.Controls.Add(this.plant_input_tab);
            this.input_tab.Controls.Add(this.environment_input_tab);
            this.input_tab.Controls.Add(this.management_input_tab);
            this.input_tab.Location = new System.Drawing.Point(136, 86);
            this.input_tab.Name = "input_tab";
            this.input_tab.SelectedIndex = 0;
            this.input_tab.Size = new System.Drawing.Size(522, 259);
            this.input_tab.TabIndex = 12;
            // 
            // climate_input_tab
            // 
            this.climate_input_tab.Controls.Add(this.climate_inputs);
            this.climate_input_tab.Location = new System.Drawing.Point(4, 22);
            this.climate_input_tab.Name = "climate_input_tab";
            this.climate_input_tab.Padding = new System.Windows.Forms.Padding(3);
            this.climate_input_tab.Size = new System.Drawing.Size(514, 233);
            this.climate_input_tab.TabIndex = 0;
            this.climate_input_tab.Text = "Climate";
            this.climate_input_tab.UseVisualStyleBackColor = true;
            // 
            // climate_inputs
            // 
            this.climate_inputs.Location = new System.Drawing.Point(0, 0);
            this.climate_inputs.Name = "climate_inputs";
            this.climate_inputs.SelectedIndex = 0;
            this.climate_inputs.Size = new System.Drawing.Size(514, 233);
            this.climate_inputs.TabIndex = 0;
            // 
            // plant_input_tab
            // 
            this.plant_input_tab.Controls.Add(this.plant_inputs);
            this.plant_input_tab.Location = new System.Drawing.Point(4, 22);
            this.plant_input_tab.Name = "plant_input_tab";
            this.plant_input_tab.Padding = new System.Windows.Forms.Padding(3);
            this.plant_input_tab.Size = new System.Drawing.Size(514, 233);
            this.plant_input_tab.TabIndex = 1;
            this.plant_input_tab.Text = "Plant";
            this.plant_input_tab.UseVisualStyleBackColor = true;
            // 
            // plant_inputs
            // 
            this.plant_inputs.Location = new System.Drawing.Point(0, 0);
            this.plant_inputs.Name = "plant_inputs";
            this.plant_inputs.SelectedIndex = 0;
            this.plant_inputs.Size = new System.Drawing.Size(514, 233);
            this.plant_inputs.TabIndex = 0;
            // 
            // environment_input_tab
            // 
            this.environment_input_tab.Controls.Add(this.environment_inputs);
            this.environment_input_tab.Location = new System.Drawing.Point(4, 22);
            this.environment_input_tab.Name = "environment_input_tab";
            this.environment_input_tab.Padding = new System.Windows.Forms.Padding(3);
            this.environment_input_tab.Size = new System.Drawing.Size(514, 233);
            this.environment_input_tab.TabIndex = 2;
            this.environment_input_tab.Text = "Environment";
            this.environment_input_tab.UseVisualStyleBackColor = true;
            // 
            // environment_inputs
            // 
            this.environment_inputs.Location = new System.Drawing.Point(0, 0);
            this.environment_inputs.Name = "environment_inputs";
            this.environment_inputs.SelectedIndex = 0;
            this.environment_inputs.Size = new System.Drawing.Size(514, 233);
            this.environment_inputs.TabIndex = 0;
            // 
            // management_input_tab
            // 
            this.management_input_tab.Controls.Add(this.management_inputs);
            this.management_input_tab.Location = new System.Drawing.Point(4, 22);
            this.management_input_tab.Name = "management_input_tab";
            this.management_input_tab.Padding = new System.Windows.Forms.Padding(3);
            this.management_input_tab.Size = new System.Drawing.Size(514, 233);
            this.management_input_tab.TabIndex = 3;
            this.management_input_tab.Text = "Management";
            this.management_input_tab.UseVisualStyleBackColor = true;
            // 
            // management_inputs
            // 
            this.management_inputs.Location = new System.Drawing.Point(0, 0);
            this.management_inputs.Name = "management_inputs";
            this.management_inputs.SelectedIndex = 0;
            this.management_inputs.Size = new System.Drawing.Size(514, 233);
            this.management_inputs.TabIndex = 0;
            // 
            // btn_select_analysis
            // 
            this.btn_select_analysis.Location = new System.Drawing.Point(668, 3);
            this.btn_select_analysis.Name = "btn_select_analysis";
            this.btn_select_analysis.Size = new System.Drawing.Size(120, 21);
            this.btn_select_analysis.TabIndex = 4;
            this.btn_select_analysis.Text = "Select Project";
            this.btn_select_analysis.UseVisualStyleBackColor = true;
            this.btn_select_analysis.Click += new System.EventHandler(this.btn_select_analysis_Click);
            // 
            // analysis_cbx
            // 
            this.analysis_cbx.FormattingEnabled = true;
            this.analysis_cbx.Location = new System.Drawing.Point(136, 57);
            this.analysis_cbx.Name = "analysis_cbx";
            this.analysis_cbx.Size = new System.Drawing.Size(522, 20);
            this.analysis_cbx.TabIndex = 14;
            // 
            // algorithm_datagrid
            // 
            this.algorithm_datagrid.AllowUserToAddRows = false;
            this.algorithm_datagrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.algorithm_datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.algorithm_datagrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Algorithm_Name_Column,
            this.Algorithm_Value_Column,
            this.Algorithm_Size_Column,
            this.Algorithm_Type_Column});
            this.algorithm_datagrid.Location = new System.Drawing.Point(3, 86);
            this.algorithm_datagrid.Name = "algorithm_datagrid";
            this.algorithm_datagrid.RowTemplate.Height = 23;
            this.algorithm_datagrid.Size = new System.Drawing.Size(127, 259);
            this.algorithm_datagrid.TabIndex = 15;
            // 
            // Algorithm_Name_Column
            // 
            this.Algorithm_Name_Column.HeaderText = "Name";
            this.Algorithm_Name_Column.Name = "Algorithm_Name_Column";
            this.Algorithm_Name_Column.ReadOnly = true;
            this.Algorithm_Name_Column.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Algorithm_Name_Column.Width = 40;
            // 
            // Algorithm_Value_Column
            // 
            this.Algorithm_Value_Column.HeaderText = "Value";
            this.Algorithm_Value_Column.Name = "Algorithm_Value_Column";
            // 
            // Algorithm_Size_Column
            // 
            this.Algorithm_Size_Column.HeaderText = "Size";
            this.Algorithm_Size_Column.Name = "Algorithm_Size_Column";
            this.Algorithm_Size_Column.ReadOnly = true;
            // 
            // Algorithm_Type_Column
            // 
            this.Algorithm_Type_Column.HeaderText = "Type";
            this.Algorithm_Type_Column.Name = "Algorithm_Type_Column";
            this.Algorithm_Type_Column.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CropModelMKS_Tab);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "CropModelMKS";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.CropModelMKS_Tab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.Simulator_Layout.ResumeLayout(false);
            this.Simulator_Layout.PerformLayout();
            this.Modules_Tab.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.Climate_Table_Layout.ResumeLayout(false);
            this.Climate_Table_Layout.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.Plant_Table_Layout.ResumeLayout(false);
            this.Plant_Table_Layout.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.Environment_Table_Layout.ResumeLayout(false);
            this.Environment_Table_Layout.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.Management_Table_Layout.ResumeLayout(false);
            this.Management_Table_Layout.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.Analyzer_Layout.ResumeLayout(false);
            this.Analyzer_Layout.PerformLayout();
            this.input_tab.ResumeLayout(false);
            this.climate_input_tab.ResumeLayout(false);
            this.plant_input_tab.ResumeLayout(false);
            this.environment_input_tab.ResumeLayout(false);
            this.management_input_tab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.algorithm_datagrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem registerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addOneComponentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkTheRegistrationsToolStripMenuItem;
        private System.Windows.Forms.TabControl CropModelMKS_Tab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel Simulator_Layout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox simulator_project;
        private System.Windows.Forms.DateTimePicker begin_simulator;
        private System.Windows.Forms.DateTimePicker end_simulator;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_select_simulator;
        private System.Windows.Forms.Button btn_save_simulation_project;
        private System.Windows.Forms.Button btn_simulate;
        private System.Windows.Forms.Button btn_save_result;
        private System.Windows.Forms.TabControl Modules_Tab;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TableLayoutPanel Analyzer_Layout;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_analyze;
        private System.Windows.Forms.Button btn_select_analysis;
        private System.Windows.Forms.Button btn_select_simulation;
        private System.Windows.Forms.Button btn_select_algorithm;
        private System.Windows.Forms.Button btn_save_analysis;
        private System.Windows.Forms.TextBox txt_analysis;
        private System.Windows.Forms.TextBox txt_simulation;
        private System.Windows.Forms.TreeView out_tree;
        private System.Windows.Forms.TabControl input_tab;
        private System.Windows.Forms.TabPage climate_input_tab;
        private System.Windows.Forms.TabPage plant_input_tab;
        private System.Windows.Forms.TabPage environment_input_tab;
        private System.Windows.Forms.TabPage management_input_tab;
        private System.Windows.Forms.TableLayoutPanel Climate_Table_Layout;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.DateTimePicker cli_begin;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.DateTimePicker cli_end;
        private System.Windows.Forms.ComboBox cli_cbx;
        private System.Windows.Forms.Button btn_cli_remove;
        private System.Windows.Forms.TextBox cli_parameters;
        private System.Windows.Forms.Button btn_cli_select;
        private System.Windows.Forms.Button btn_cli_create;
        private System.Windows.Forms.ListView climate_ListView;
        private System.Windows.Forms.Button btn_cli_add;
        private System.Windows.Forms.TableLayoutPanel Plant_Table_Layout;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DateTimePicker plt_begin;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DateTimePicker plt_end;
        private System.Windows.Forms.ComboBox plt_cbx;
        private System.Windows.Forms.Button btn_plt_remove;
        private System.Windows.Forms.TextBox plt_parameters;
        private System.Windows.Forms.Button btn_plt_select;
        private System.Windows.Forms.Button btn_plt_create;
        private System.Windows.Forms.ListView plant_ListView;
        private System.Windows.Forms.Button btn_plt_add;
        private System.Windows.Forms.TableLayoutPanel Environment_Table_Layout;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker env_begin;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker env_end;
        private System.Windows.Forms.ComboBox env_cbx;
        private System.Windows.Forms.Button btn_env_remove;
        private System.Windows.Forms.TextBox env_parameters;
        private System.Windows.Forms.Button btn_env_select;
        private System.Windows.Forms.Button btn_env_create;
        private System.Windows.Forms.ListView environment_ListView;
        private System.Windows.Forms.Button btn_env_add;
        private System.Windows.Forms.TableLayoutPanel Management_Table_Layout;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker mgt_begin;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker mgt_end;
        private System.Windows.Forms.ComboBox mgt_cbx;
        private System.Windows.Forms.Button btn_mgt_remove;
        private System.Windows.Forms.TextBox mgt_parameters;
        private System.Windows.Forms.Button btn_mgt_select;
        private System.Windows.Forms.Button btn_mgt_create;
        private System.Windows.Forms.ListView management_ListView;
        private System.Windows.Forms.Button btn_mgt_add;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.Button btn_display;
        private System.Windows.Forms.ComboBox analysis_cbx;
        private System.Windows.Forms.DataGridView algorithm_datagrid;
        private System.Windows.Forms.TabControl climate_inputs;
        private System.Windows.Forms.TabControl plant_inputs;
        private System.Windows.Forms.TabControl environment_inputs;
        private System.Windows.Forms.TabControl management_inputs;
        private System.Windows.Forms.DataGridViewTextBoxColumn Algorithm_Name_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn Algorithm_Value_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn Algorithm_Size_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn Algorithm_Type_Column;
    }
}

