namespace MWPC_Selector
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_PerformanceCounterCategories = new System.Windows.Forms.ListBox();
            this.lb_PerformanceCounterInstances = new System.Windows.Forms.ListBox();
            this.lb_PerformanceCounters = new System.Windows.Forms.ListBox();
            this.btn_AddCounter = new System.Windows.Forms.Button();
            this.btn_RemoveCounter = new System.Windows.Forms.Button();
            this.dgv_SelectedPerformanceCounters = new System.Windows.Forms.DataGridView();
            this.dgc_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgc_PerformanceCounterCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgc_PerformanceCounterInstances = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgc_PerformanceCounter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgc_Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgc_YLabel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgc_Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgc_Base = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgc_Multiplicator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgc_LowerLimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgc_UpperLimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgc_Draw = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgc_DataType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgc_Scale = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgc_Warning = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgc_Critical = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbl_Dummy1 = new System.Windows.Forms.Label();
            this.lbl_Line1 = new System.Windows.Forms.Label();
            this.lbl_ServiceStatus = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_CounterDescription = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SelectedPerformanceCounters)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.serviceToolStripMenuItem,
            this.infoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1258, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(136, 30);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(136, 30);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(136, 30);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // serviceToolStripMenuItem
            // 
            this.serviceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.restartToolStripMenuItem});
            this.serviceToolStripMenuItem.Name = "serviceToolStripMenuItem";
            this.serviceToolStripMenuItem.Size = new System.Drawing.Size(79, 29);
            this.serviceToolStripMenuItem.Text = "Service";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(151, 30);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(151, 30);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(151, 30);
            this.restartToolStripMenuItem.Text = "Restart";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(56, 29);
            this.infoToolStripMenuItem.Text = "Info";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Categories";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(425, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Instances";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(842, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Counter";
            // 
            // lb_PerformanceCounterCategories
            // 
            this.lb_PerformanceCounterCategories.FormattingEnabled = true;
            this.lb_PerformanceCounterCategories.ItemHeight = 20;
            this.lb_PerformanceCounterCategories.Location = new System.Drawing.Point(12, 122);
            this.lb_PerformanceCounterCategories.Name = "lb_PerformanceCounterCategories";
            this.lb_PerformanceCounterCategories.Size = new System.Drawing.Size(400, 244);
            this.lb_PerformanceCounterCategories.TabIndex = 4;
            this.lb_PerformanceCounterCategories.SelectedIndexChanged += new System.EventHandler(this.lb_PerformanceCounterCategories_SelectedIndexChanged);
            // 
            // lb_PerformanceCounterInstances
            // 
            this.lb_PerformanceCounterInstances.FormattingEnabled = true;
            this.lb_PerformanceCounterInstances.ItemHeight = 20;
            this.lb_PerformanceCounterInstances.Location = new System.Drawing.Point(429, 122);
            this.lb_PerformanceCounterInstances.Name = "lb_PerformanceCounterInstances";
            this.lb_PerformanceCounterInstances.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lb_PerformanceCounterInstances.Size = new System.Drawing.Size(400, 244);
            this.lb_PerformanceCounterInstances.TabIndex = 5;
            this.lb_PerformanceCounterInstances.SelectedIndexChanged += new System.EventHandler(this.lb_PerformanceCounterInstances_SelectedIndexChanged);
            // 
            // lb_PerformanceCounters
            // 
            this.lb_PerformanceCounters.FormattingEnabled = true;
            this.lb_PerformanceCounters.ItemHeight = 20;
            this.lb_PerformanceCounters.Location = new System.Drawing.Point(846, 122);
            this.lb_PerformanceCounters.Name = "lb_PerformanceCounters";
            this.lb_PerformanceCounters.Size = new System.Drawing.Size(400, 244);
            this.lb_PerformanceCounters.TabIndex = 6;
            this.lb_PerformanceCounters.SelectedIndexChanged += new System.EventHandler(this.lb_PerformanceCounters_SelectedIndexChanged);
            // 
            // btn_AddCounter
            // 
            this.btn_AddCounter.Location = new System.Drawing.Point(12, 421);
            this.btn_AddCounter.Name = "btn_AddCounter";
            this.btn_AddCounter.Size = new System.Drawing.Size(200, 50);
            this.btn_AddCounter.TabIndex = 7;
            this.btn_AddCounter.Text = "Add Counter";
            this.btn_AddCounter.UseVisualStyleBackColor = true;
            this.btn_AddCounter.Click += new System.EventHandler(this.btn_AddCounter_Click);
            // 
            // btn_RemoveCounter
            // 
            this.btn_RemoveCounter.Location = new System.Drawing.Point(248, 421);
            this.btn_RemoveCounter.Name = "btn_RemoveCounter";
            this.btn_RemoveCounter.Size = new System.Drawing.Size(200, 50);
            this.btn_RemoveCounter.TabIndex = 8;
            this.btn_RemoveCounter.Text = "Remove Counter";
            this.btn_RemoveCounter.UseVisualStyleBackColor = true;
            this.btn_RemoveCounter.Click += new System.EventHandler(this.btn_RemoveCounter_Click);
            // 
            // dgv_SelectedPerformanceCounters
            // 
            this.dgv_SelectedPerformanceCounters.AllowUserToAddRows = false;
            this.dgv_SelectedPerformanceCounters.AllowUserToDeleteRows = false;
            this.dgv_SelectedPerformanceCounters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_SelectedPerformanceCounters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgc_Id,
            this.dgc_PerformanceCounterCategory,
            this.dgc_PerformanceCounterInstances,
            this.dgc_PerformanceCounter,
            this.dgc_Title,
            this.dgc_YLabel,
            this.dgc_Category,
            this.dgc_Base,
            this.dgc_Multiplicator,
            this.dgc_LowerLimit,
            this.dgc_UpperLimit,
            this.dgc_Draw,
            this.dgc_DataType,
            this.dgc_Scale,
            this.dgc_Warning,
            this.dgc_Critical});
            this.dgv_SelectedPerformanceCounters.Location = new System.Drawing.Point(12, 522);
            this.dgv_SelectedPerformanceCounters.Name = "dgv_SelectedPerformanceCounters";
            this.dgv_SelectedPerformanceCounters.RowTemplate.Height = 28;
            this.dgv_SelectedPerformanceCounters.Size = new System.Drawing.Size(1234, 410);
            this.dgv_SelectedPerformanceCounters.TabIndex = 9;
            this.dgv_SelectedPerformanceCounters.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgv_SelectedPerformanceCounters_EditingControlShowing);
            // 
            // dgc_Id
            // 
            this.dgc_Id.DataPropertyName = "Id";
            this.dgc_Id.HeaderText = "Id";
            this.dgc_Id.Name = "dgc_Id";
            this.dgc_Id.ReadOnly = true;
            // 
            // dgc_PerformanceCounterCategory
            // 
            this.dgc_PerformanceCounterCategory.DataPropertyName = "PerformanceCounterCategory";
            this.dgc_PerformanceCounterCategory.HeaderText = "Performance Counter Category";
            this.dgc_PerformanceCounterCategory.Name = "dgc_PerformanceCounterCategory";
            this.dgc_PerformanceCounterCategory.ReadOnly = true;
            // 
            // dgc_PerformanceCounterInstances
            // 
            this.dgc_PerformanceCounterInstances.DataPropertyName = "PerformanceCounterInstances";
            this.dgc_PerformanceCounterInstances.HeaderText = "Performance Counter Instances";
            this.dgc_PerformanceCounterInstances.Name = "dgc_PerformanceCounterInstances";
            this.dgc_PerformanceCounterInstances.ReadOnly = true;
            // 
            // dgc_PerformanceCounter
            // 
            this.dgc_PerformanceCounter.DataPropertyName = "PerformanceCounterName";
            this.dgc_PerformanceCounter.HeaderText = "Performance Counter";
            this.dgc_PerformanceCounter.Name = "dgc_PerformanceCounter";
            this.dgc_PerformanceCounter.ReadOnly = true;
            // 
            // dgc_Title
            // 
            this.dgc_Title.DataPropertyName = "Title";
            this.dgc_Title.HeaderText = "Title";
            this.dgc_Title.Name = "dgc_Title";
            // 
            // dgc_YLabel
            // 
            this.dgc_YLabel.DataPropertyName = "YLabel";
            this.dgc_YLabel.HeaderText = "YLabel";
            this.dgc_YLabel.Name = "dgc_YLabel";
            // 
            // dgc_Category
            // 
            this.dgc_Category.DataPropertyName = "Category";
            this.dgc_Category.HeaderText = "Category";
            this.dgc_Category.Name = "dgc_Category";
            // 
            // dgc_Base
            // 
            this.dgc_Base.DataPropertyName = "Base";
            this.dgc_Base.HeaderText = "Base";
            this.dgc_Base.Items.AddRange(new object[] {
            "1000",
            "1024"});
            this.dgc_Base.Name = "dgc_Base";
            // 
            // dgc_Multiplicator
            // 
            this.dgc_Multiplicator.DataPropertyName = "Multiplicator";
            this.dgc_Multiplicator.HeaderText = "Multiplicator";
            this.dgc_Multiplicator.Name = "dgc_Multiplicator";
            // 
            // dgc_LowerLimit
            // 
            this.dgc_LowerLimit.DataPropertyName = "LowerLimit";
            this.dgc_LowerLimit.HeaderText = "Lower Limit";
            this.dgc_LowerLimit.Name = "dgc_LowerLimit";
            this.dgc_LowerLimit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgc_LowerLimit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgc_UpperLimit
            // 
            this.dgc_UpperLimit.DataPropertyName = "UpperLimit";
            this.dgc_UpperLimit.HeaderText = "Upper Limit";
            this.dgc_UpperLimit.Name = "dgc_UpperLimit";
            this.dgc_UpperLimit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgc_UpperLimit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgc_Draw
            // 
            this.dgc_Draw.DataPropertyName = "Draw";
            this.dgc_Draw.HeaderText = "Plot Type";
            this.dgc_Draw.Items.AddRange(new object[] {
            "LINE",
            "AREA",
            "LINESTACK",
            "AREASTACK"});
            this.dgc_Draw.Name = "dgc_Draw";
            // 
            // dgc_DataType
            // 
            this.dgc_DataType.DataPropertyName = "Type";
            this.dgc_DataType.HeaderText = "Data Type";
            this.dgc_DataType.Items.AddRange(new object[] {
            "GAUGE",
            "COUNTER",
            "DERIVE",
            "ABSOLUTE"});
            this.dgc_DataType.Name = "dgc_DataType";
            // 
            // dgc_Scale
            // 
            this.dgc_Scale.DataPropertyName = "Scale";
            this.dgc_Scale.HeaderText = "Scale";
            this.dgc_Scale.Name = "dgc_Scale";
            // 
            // dgc_Warning
            // 
            this.dgc_Warning.DataPropertyName = "Warning";
            this.dgc_Warning.HeaderText = "Warning";
            this.dgc_Warning.Name = "dgc_Warning";
            // 
            // dgc_Critical
            // 
            this.dgc_Critical.DataPropertyName = "Critical";
            this.dgc_Critical.HeaderText = "Critical";
            this.dgc_Critical.Name = "dgc_Critical";
            // 
            // lbl_Dummy1
            // 
            this.lbl_Dummy1.AutoSize = true;
            this.lbl_Dummy1.Location = new System.Drawing.Point(8, 51);
            this.lbl_Dummy1.Name = "lbl_Dummy1";
            this.lbl_Dummy1.Size = new System.Drawing.Size(116, 20);
            this.lbl_Dummy1.TabIndex = 10;
            this.lbl_Dummy1.Text = "Service Status:";
            // 
            // lbl_Line1
            // 
            this.lbl_Line1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Line1.Location = new System.Drawing.Point(0, 82);
            this.lbl_Line1.Name = "lbl_Line1";
            this.lbl_Line1.Size = new System.Drawing.Size(1258, 2);
            this.lbl_Line1.TabIndex = 11;
            // 
            // lbl_ServiceStatus
            // 
            this.lbl_ServiceStatus.AutoSize = true;
            this.lbl_ServiceStatus.Location = new System.Drawing.Point(130, 51);
            this.lbl_ServiceStatus.Name = "lbl_ServiceStatus";
            this.lbl_ServiceStatus.Size = new System.Drawing.Size(0, 20);
            this.lbl_ServiceStatus.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(0, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1258, 2);
            this.label4.TabIndex = 13;
            // 
            // tb_CounterDescription
            // 
            this.tb_CounterDescription.Location = new System.Drawing.Point(846, 372);
            this.tb_CounterDescription.Multiline = true;
            this.tb_CounterDescription.Name = "tb_CounterDescription";
            this.tb_CounterDescription.ReadOnly = true;
            this.tb_CounterDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_CounterDescription.Size = new System.Drawing.Size(400, 144);
            this.tb_CounterDescription.TabIndex = 15;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 944);
            this.Controls.Add(this.tb_CounterDescription);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl_ServiceStatus);
            this.Controls.Add(this.lbl_Line1);
            this.Controls.Add(this.lbl_Dummy1);
            this.Controls.Add(this.dgv_SelectedPerformanceCounters);
            this.Controls.Add(this.btn_RemoveCounter);
            this.Controls.Add(this.btn_AddCounter);
            this.Controls.Add(this.lb_PerformanceCounters);
            this.Controls.Add(this.lb_PerformanceCounterInstances);
            this.Controls.Add(this.lb_PerformanceCounterCategories);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MWPC Selector";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SelectedPerformanceCounters)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lb_PerformanceCounterCategories;
        private System.Windows.Forms.ListBox lb_PerformanceCounterInstances;
        private System.Windows.Forms.ListBox lb_PerformanceCounters;
        private System.Windows.Forms.Button btn_AddCounter;
        private System.Windows.Forms.Button btn_RemoveCounter;
        private System.Windows.Forms.DataGridView dgv_SelectedPerformanceCounters;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serviceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.Label lbl_Dummy1;
        private System.Windows.Forms.Label lbl_Line1;
        private System.Windows.Forms.Label lbl_ServiceStatus;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_CounterDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgc_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgc_PerformanceCounterCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgc_PerformanceCounterInstances;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgc_PerformanceCounter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgc_Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgc_YLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgc_Category;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgc_Base;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgc_Multiplicator;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgc_LowerLimit;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgc_UpperLimit;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgc_Draw;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgc_DataType;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgc_Scale;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgc_Warning;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgc_Critical;
    }
}

