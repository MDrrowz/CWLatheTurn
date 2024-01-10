namespace CWLatheTurn
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabCalcs = new System.Windows.Forms.TabPage();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jobInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.measurementNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.angleColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.measColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AngleTextBox1 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.addButton1 = new System.Windows.Forms.Button();
            this.modButton2 = new System.Windows.Forms.Button();
            this.remButton3 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 405);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(721, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabCalcs);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(721, 378);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(713, 352);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Measurements";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabCalcs
            // 
            this.tabCalcs.Location = new System.Drawing.Point(4, 22);
            this.tabCalcs.Name = "tabCalcs";
            this.tabCalcs.Padding = new System.Windows.Forms.Padding(3);
            this.tabCalcs.Size = new System.Drawing.Size(579, 423);
            this.tabCalcs.TabIndex = 1;
            this.tabCalcs.Text = "Calculations";
            this.tabCalcs.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.jobInfoToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(721, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(579, 423);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Job Info";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // jobInfoToolStripMenuItem
            // 
            this.jobInfoToolStripMenuItem.Name = "jobInfoToolStripMenuItem";
            this.jobInfoToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.jobInfoToolStripMenuItem.Text = "Job Info";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.measurementNumber,
            this.angleColumn,
            this.measColumn});
            this.dataGridView1.Location = new System.Drawing.Point(8, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.DividerHeight = 1;
            this.dataGridView1.RowTemplate.Height = 20;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(184, 340);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // measurementNumber
            // 
            this.measurementNumber.DividerWidth = 2;
            this.measurementNumber.HeaderText = "#";
            this.measurementNumber.Name = "measurementNumber";
            this.measurementNumber.ReadOnly = true;
            this.measurementNumber.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.measurementNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.measurementNumber.Width = 30;
            // 
            // angleColumn
            // 
            this.angleColumn.DividerWidth = 2;
            this.angleColumn.HeaderText = "Angle";
            this.angleColumn.Name = "angleColumn";
            this.angleColumn.ReadOnly = true;
            this.angleColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.angleColumn.Width = 50;
            // 
            // measColumn
            // 
            this.measColumn.DividerWidth = 2;
            this.measColumn.HeaderText = "Measurement";
            this.measColumn.Name = "measColumn";
            this.measColumn.ReadOnly = true;
            this.measColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // AngleTextBox1
            // 
            this.AngleTextBox1.Location = new System.Drawing.Point(3, 22);
            this.AngleTextBox1.Name = "AngleTextBox1";
            this.AngleTextBox1.Size = new System.Drawing.Size(100, 20);
            this.AngleTextBox1.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 67);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.remButton3);
            this.panel1.Controls.Add(this.modButton2);
            this.panel1.Controls.Add(this.addButton1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.AngleTextBox1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Location = new System.Drawing.Point(198, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(107, 165);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Angle";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Measurement";
            // 
            // addButton1
            // 
            this.addButton1.Location = new System.Drawing.Point(6, 93);
            this.addButton1.Name = "addButton1";
            this.addButton1.Size = new System.Drawing.Size(41, 23);
            this.addButton1.TabIndex = 4;
            this.addButton1.Text = "Add";
            this.addButton1.UseVisualStyleBackColor = true;
            // 
            // modButton2
            // 
            this.modButton2.Location = new System.Drawing.Point(53, 93);
            this.modButton2.Name = "modButton2";
            this.modButton2.Size = new System.Drawing.Size(50, 23);
            this.modButton2.TabIndex = 5;
            this.modButton2.Text = "Modify";
            this.modButton2.UseVisualStyleBackColor = true;
            // 
            // remButton3
            // 
            this.remButton3.Location = new System.Drawing.Point(6, 131);
            this.remButton3.Name = "remButton3";
            this.remButton3.Size = new System.Drawing.Size(59, 23);
            this.remButton3.TabIndex = 6;
            this.remButton3.Text = "Remove";
            this.remButton3.UseVisualStyleBackColor = true;
            this.remButton3.Click += new System.EventHandler(this.button3_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Radius",
            "Indicator Reading"});
            this.comboBox1.Location = new System.Drawing.Point(198, 194);
            this.comboBox1.MaxDropDownItems = 2;
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(103, 21);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.Text = "Radius";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(198, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Measurement Type";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 427);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabCalcs;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jobInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn measurementNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn angleColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn measColumn;
        private System.Windows.Forms.TextBox AngleTextBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button remButton3;
        private System.Windows.Forms.Button modButton2;
        private System.Windows.Forms.Button addButton1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

