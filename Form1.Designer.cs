﻿using System.Data;
using System.Runtime.CompilerServices;

namespace CWLatheTurn
{
    public partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jobInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabCalcs = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.AngleTextBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.addButton1 = new System.Windows.Forms.Button();
            this.modButton2 = new System.Windows.Forms.Button();
            this.remButton3 = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.outputTB1 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cwrCalcTB = new System.Windows.Forms.TextBox();
            this.CWMaxR = new System.Windows.Forms.Label();
            this.CWRadButton = new System.Windows.Forms.Button();
            this.journalDiaLabel = new System.Windows.Forms.Label();
            this.journalDiaTB = new System.Windows.Forms.TextBox();
            this.jtcwTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cwrTB = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.measTypeButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 421);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(858, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.jobInfoToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(858, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
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
            // tabCalcs
            // 
            this.tabCalcs.Location = new System.Drawing.Point(4, 22);
            this.tabCalcs.Name = "tabCalcs";
            this.tabCalcs.Padding = new System.Windows.Forms.Padding(3);
            this.tabCalcs.Size = new System.Drawing.Size(713, 352);
            this.tabCalcs.TabIndex = 1;
            this.tabCalcs.Text = "Calculations";
            this.tabCalcs.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.outputTB1);
            this.tabPage1.Controls.Add(this.LoadButton);
            this.tabPage1.Controls.Add(this.SaveButton);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(850, 368);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Measurements";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(8, 6);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.RowTemplate.DividerHeight = 1;
            this.dataGridView1.RowTemplate.Height = 20;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(184, 356);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.remButton3);
            this.panel1.Controls.Add(this.modButton2);
            this.panel1.Controls.Add(this.addButton1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.AngleTextBox1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Location = new System.Drawing.Point(198, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(110, 142);
            this.panel1.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 59);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox1_KeyPress);
            // 
            // AngleTextBox1
            // 
            this.AngleTextBox1.Location = new System.Drawing.Point(3, 19);
            this.AngleTextBox1.Name = "AngleTextBox1";
            this.AngleTextBox1.Size = new System.Drawing.Size(100, 20);
            this.AngleTextBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Angle";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Measurement";
            // 
            // addButton1
            // 
            this.addButton1.Location = new System.Drawing.Point(3, 85);
            this.addButton1.Name = "addButton1";
            this.addButton1.Size = new System.Drawing.Size(41, 23);
            this.addButton1.TabIndex = 4;
            this.addButton1.Text = "Add";
            this.addButton1.UseVisualStyleBackColor = true;
            this.addButton1.Click += new System.EventHandler(this.AddButton1_Click);
            // 
            // modButton2
            // 
            this.modButton2.Location = new System.Drawing.Point(50, 85);
            this.modButton2.Name = "modButton2";
            this.modButton2.Size = new System.Drawing.Size(50, 23);
            this.modButton2.TabIndex = 5;
            this.modButton2.Text = "Modify";
            this.modButton2.UseVisualStyleBackColor = true;
            this.modButton2.Click += new System.EventHandler(this.ModButton2_Click);
            // 
            // remButton3
            // 
            this.remButton3.Location = new System.Drawing.Point(3, 113);
            this.remButton3.Name = "remButton3";
            this.remButton3.Size = new System.Drawing.Size(59, 23);
            this.remButton3.TabIndex = 6;
            this.remButton3.Text = "Remove";
            this.remButton3.UseVisualStyleBackColor = true;
            this.remButton3.Click += new System.EventHandler(this.RemButton3_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(202, 158);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(105, 23);
            this.SaveButton.TabIndex = 7;
            this.SaveButton.Text = "Save Data";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(202, 187);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(105, 23);
            this.LoadButton.TabIndex = 8;
            this.LoadButton.Text = "Load Data";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // outputTB1
            // 
            this.outputTB1.Location = new System.Drawing.Point(205, 248);
            this.outputTB1.Multiline = true;
            this.outputTB1.Name = "outputTB1";
            this.outputTB1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputTB1.Size = new System.Drawing.Size(491, 86);
            this.outputTB1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cwrTB);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.jtcwTB);
            this.panel2.Controls.Add(this.journalDiaTB);
            this.panel2.Controls.Add(this.journalDiaLabel);
            this.panel2.Controls.Add(this.CWRadButton);
            this.panel2.Controls.Add(this.CWMaxR);
            this.panel2.Controls.Add(this.cwrCalcTB);
            this.panel2.Location = new System.Drawing.Point(313, 57);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(122, 167);
            this.panel2.TabIndex = 13;
            // 
            // cwrCalcTB
            // 
            this.cwrCalcTB.Enabled = false;
            this.cwrCalcTB.Location = new System.Drawing.Point(3, 140);
            this.cwrCalcTB.Name = "cwrCalcTB";
            this.cwrCalcTB.Size = new System.Drawing.Size(86, 20);
            this.cwrCalcTB.TabIndex = 12;
            this.cwrCalcTB.Visible = false;
            // 
            // CWMaxR
            // 
            this.CWMaxR.AutoSize = true;
            this.CWMaxR.Location = new System.Drawing.Point(3, 2);
            this.CWMaxR.Name = "CWMaxR";
            this.CWMaxR.Size = new System.Drawing.Size(112, 13);
            this.CWMaxR.TabIndex = 0;
            this.CWMaxR.Text = "Indicator Zero Radius:";
            // 
            // CWRadButton
            // 
            this.CWRadButton.Location = new System.Drawing.Point(3, 19);
            this.CWRadButton.Name = "CWRadButton";
            this.CWRadButton.Size = new System.Drawing.Size(86, 23);
            this.CWRadButton.TabIndex = 1;
            this.CWRadButton.Text = "Radius";
            this.CWRadButton.UseVisualStyleBackColor = true;
            this.CWRadButton.Click += new System.EventHandler(this.CWRadButton_Click);
            // 
            // journalDiaLabel
            // 
            this.journalDiaLabel.AutoSize = true;
            this.journalDiaLabel.Location = new System.Drawing.Point(3, 46);
            this.journalDiaLabel.Name = "journalDiaLabel";
            this.journalDiaLabel.Size = new System.Drawing.Size(86, 13);
            this.journalDiaLabel.TabIndex = 2;
            this.journalDiaLabel.Text = "Journal Diameter";
            // 
            // journalDiaTB
            // 
            this.journalDiaTB.Enabled = false;
            this.journalDiaTB.Location = new System.Drawing.Point(3, 62);
            this.journalDiaTB.Name = "journalDiaTB";
            this.journalDiaTB.Size = new System.Drawing.Size(86, 20);
            this.journalDiaTB.TabIndex = 7;
            this.journalDiaTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.journalDiaTB.Leave += new System.EventHandler(this.journalDiaTB_Leave);
            // 
            // jtcwTB
            // 
            this.jtcwTB.Enabled = false;
            this.jtcwTB.Location = new System.Drawing.Point(3, 101);
            this.jtcwTB.Name = "jtcwTB";
            this.jtcwTB.Size = new System.Drawing.Size(86, 20);
            this.jtcwTB.TabIndex = 8;
            this.jtcwTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.jtcwTB.Leave += new System.EventHandler(this.jtcwTB_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Journal to Zero Dist.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Indicator Zero Radius";
            // 
            // cwrTB
            // 
            this.cwrTB.Location = new System.Drawing.Point(3, 140);
            this.cwrTB.Name = "cwrTB";
            this.cwrTB.Size = new System.Drawing.Size(86, 20);
            this.cwrTB.TabIndex = 11;
            this.cwrTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cwrTB.Leave += new System.EventHandler(this.cwrTB_Leave);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.measTypeButton);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(313, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(112, 45);
            this.panel3.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Measurement Type:";
            // 
            // measTypeButton
            // 
            this.measTypeButton.Location = new System.Drawing.Point(3, 19);
            this.measTypeButton.Name = "measTypeButton";
            this.measTypeButton.Size = new System.Drawing.Size(106, 22);
            this.measTypeButton.TabIndex = 6;
            this.measTypeButton.Text = "Indicator Reading";
            this.measTypeButton.UseVisualStyleBackColor = true;
            this.measTypeButton.Click += new System.EventHandler(this.measTypeButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabCalcs);
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(858, 394);
            this.tabControl1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 443);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jobInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.TabPage tabCalcs;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button measTypeButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox cwrTB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox jtcwTB;
        private System.Windows.Forms.TextBox journalDiaTB;
        private System.Windows.Forms.Label journalDiaLabel;
        private System.Windows.Forms.Button CWRadButton;
        private System.Windows.Forms.Label CWMaxR;
        private System.Windows.Forms.TextBox cwrCalcTB;
        private System.Windows.Forms.TextBox outputTB1;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button remButton3;
        private System.Windows.Forms.Button modButton2;
        private System.Windows.Forms.Button addButton1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox AngleTextBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabControl tabControl1;
    }

    
}

