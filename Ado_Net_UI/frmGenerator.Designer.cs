namespace Ado_Net_Core
{
    partial class frmGenerator
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbConnectionSettings = new System.Windows.Forms.GroupBox();
            this.cbDatabases = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbDbSettings = new System.Windows.Forms.GroupBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.cbTables = new System.Windows.Forms.ComboBox();
            this.lblConnectedDatabase = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.gbGeneratingSettings = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkGenerateBLL = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblSelectedTable = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnShawDAL = new System.Windows.Forms.Button();
            this.btnShawBLL = new System.Windows.Forms.Button();
            this.dgvColumnsInfo = new System.Windows.Forms.DataGridView();
            this.gbConnectionSettings.SuspendLayout();
            this.gbDbSettings.SuspendLayout();
            this.gbGeneratingSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumnsInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // gbConnectionSettings
            // 
            this.gbConnectionSettings.Controls.Add(this.cbDatabases);
            this.gbConnectionSettings.Controls.Add(this.btnConnect);
            this.gbConnectionSettings.Controls.Add(this.txtServerName);
            this.gbConnectionSettings.Controls.Add(this.label4);
            this.gbConnectionSettings.Controls.Add(this.label3);
            this.gbConnectionSettings.Controls.Add(this.label2);
            this.gbConnectionSettings.Controls.Add(this.label1);
            this.gbConnectionSettings.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbConnectionSettings.Location = new System.Drawing.Point(12, 12);
            this.gbConnectionSettings.Name = "gbConnectionSettings";
            this.gbConnectionSettings.Size = new System.Drawing.Size(385, 213);
            this.gbConnectionSettings.TabIndex = 0;
            this.gbConnectionSettings.TabStop = false;
            this.gbConnectionSettings.Text = "Connection Settings";
            // 
            // cbDatabases
            // 
            this.cbDatabases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDatabases.FormattingEnabled = true;
            this.cbDatabases.Location = new System.Drawing.Point(186, 101);
            this.cbDatabases.Name = "cbDatabases";
            this.cbDatabases.Size = new System.Drawing.Size(184, 31);
            this.cbDatabases.TabIndex = 9;
            // 
            // btnConnect
            // 
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.Location = new System.Drawing.Point(117, 156);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(124, 45);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(186, 53);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.ReadOnly = true;
            this.txtServerName.Size = new System.Drawing.Size(184, 31);
            this.txtServerName.TabIndex = 4;
            this.txtServerName.Text = ".";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(161, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = ":";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(161, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = ":";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Database Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server Name ";
            // 
            // gbDbSettings
            // 
            this.gbDbSettings.Controls.Add(this.btnNext);
            this.gbDbSettings.Controls.Add(this.cbTables);
            this.gbDbSettings.Controls.Add(this.lblConnectedDatabase);
            this.gbDbSettings.Controls.Add(this.label9);
            this.gbDbSettings.Controls.Add(this.label10);
            this.gbDbSettings.Controls.Add(this.label5);
            this.gbDbSettings.Controls.Add(this.label7);
            this.gbDbSettings.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDbSettings.Location = new System.Drawing.Point(404, 12);
            this.gbDbSettings.Name = "gbDbSettings";
            this.gbDbSettings.Size = new System.Drawing.Size(422, 213);
            this.gbDbSettings.TabIndex = 7;
            this.gbDbSettings.TabStop = false;
            this.gbDbSettings.Text = "Database Settings";
            // 
            // btnNext
            // 
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Location = new System.Drawing.Point(121, 156);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(124, 45);
            this.btnNext.TabIndex = 7;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // cbTables
            // 
            this.cbTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTables.FormattingEnabled = true;
            this.cbTables.Location = new System.Drawing.Point(190, 103);
            this.cbTables.Name = "cbTables";
            this.cbTables.Size = new System.Drawing.Size(216, 31);
            this.cbTables.TabIndex = 8;
            // 
            // lblConnectedDatabase
            // 
            this.lblConnectedDatabase.AutoSize = true;
            this.lblConnectedDatabase.Location = new System.Drawing.Point(238, 55);
            this.lblConnectedDatabase.Name = "lblConnectedDatabase";
            this.lblConnectedDatabase.Size = new System.Drawing.Size(50, 23);
            this.lblConnectedDatabase.TabIndex = 6;
            this.lblConnectedDatabase.Text = "????";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(213, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(19, 23);
            this.label9.TabIndex = 5;
            this.label9.Text = ":";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(205, 23);
            this.label10.TabIndex = 4;
            this.label10.Text = "Connected Database";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(170, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 23);
            this.label5.TabIndex = 3;
            this.label5.Text = ":";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(162, 23);
            this.label7.TabIndex = 1;
            this.label7.Text = "Available Tables";
            // 
            // gbGeneratingSettings
            // 
            this.gbGeneratingSettings.Controls.Add(this.label11);
            this.gbGeneratingSettings.Controls.Add(this.txtClassName);
            this.gbGeneratingSettings.Controls.Add(this.label6);
            this.gbGeneratingSettings.Controls.Add(this.chkGenerateBLL);
            this.gbGeneratingSettings.Controls.Add(this.label8);
            this.gbGeneratingSettings.Controls.Add(this.lblSelectedTable);
            this.gbGeneratingSettings.Controls.Add(this.label12);
            this.gbGeneratingSettings.Controls.Add(this.label13);
            this.gbGeneratingSettings.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbGeneratingSettings.Location = new System.Drawing.Point(12, 231);
            this.gbGeneratingSettings.Name = "gbGeneratingSettings";
            this.gbGeneratingSettings.Size = new System.Drawing.Size(814, 203);
            this.gbGeneratingSettings.TabIndex = 7;
            this.gbGeneratingSettings.TabStop = false;
            this.gbGeneratingSettings.Text = "Generating Settings";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(389, 96);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(394, 46);
            this.label11.TabIndex = 13;
            this.label11.Text = "Recommended : Singular form of the table name like (Person, Book, Employee, ..., " +
    "etc) \r\n";
            // 
            // txtClassName
            // 
            this.txtClassName.Location = new System.Drawing.Point(199, 100);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Size = new System.Drawing.Size(184, 31);
            this.txtClassName.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(170, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 23);
            this.label6.TabIndex = 11;
            this.label6.Text = ":";
            // 
            // chkGenerateBLL
            // 
            this.chkGenerateBLL.AutoSize = true;
            this.chkGenerateBLL.Checked = true;
            this.chkGenerateBLL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGenerateBLL.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkGenerateBLL.Location = new System.Drawing.Point(174, 157);
            this.chkGenerateBLL.Name = "chkGenerateBLL";
            this.chkGenerateBLL.Size = new System.Drawing.Size(338, 27);
            this.chkGenerateBLL.TabIndex = 11;
            this.chkGenerateBLL.Text = "Generate Business Logic Layer ?";
            this.chkGenerateBLL.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 103);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(127, 23);
            this.label8.TabIndex = 10;
            this.label8.Text = "Class Name ";
            // 
            // lblSelectedTable
            // 
            this.lblSelectedTable.AutoSize = true;
            this.lblSelectedTable.Location = new System.Drawing.Point(195, 56);
            this.lblSelectedTable.Name = "lblSelectedTable";
            this.lblSelectedTable.Size = new System.Drawing.Size(50, 23);
            this.lblSelectedTable.TabIndex = 9;
            this.lblSelectedTable.Text = "????";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(170, 56);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(19, 23);
            this.label12.TabIndex = 8;
            this.label12.Text = ":";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 56);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(148, 23);
            this.label13.TabIndex = 7;
            this.label13.Text = "Selected Table";
            // 
            // txtOutput
            // 
            this.txtOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOutput.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutput.Location = new System.Drawing.Point(842, 73);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutput.Size = new System.Drawing.Size(582, 736);
            this.txtOutput.TabIndex = 8;
            // 
            // btnGenerate
            // 
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.Location = new System.Drawing.Point(129, 764);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(124, 45);
            this.btnGenerate.TabIndex = 7;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnReset
            // 
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(473, 764);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(124, 45);
            this.btnReset.TabIndex = 9;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopy.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopy.Location = new System.Drawing.Point(305, 764);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(124, 45);
            this.btnCopy.TabIndex = 10;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnShawDAL
            // 
            this.btnShawDAL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShawDAL.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShawDAL.Location = new System.Drawing.Point(842, 22);
            this.btnShawDAL.Name = "btnShawDAL";
            this.btnShawDAL.Size = new System.Drawing.Size(284, 45);
            this.btnShawDAL.TabIndex = 12;
            this.btnShawDAL.Text = "Data Access Layer";
            this.btnShawDAL.UseVisualStyleBackColor = true;
            this.btnShawDAL.Click += new System.EventHandler(this.btnShawDAL_Click);
            // 
            // btnShawBLL
            // 
            this.btnShawBLL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShawBLL.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShawBLL.Location = new System.Drawing.Point(1159, 22);
            this.btnShawBLL.Name = "btnShawBLL";
            this.btnShawBLL.Size = new System.Drawing.Size(269, 45);
            this.btnShawBLL.TabIndex = 13;
            this.btnShawBLL.Text = "Bussiness Logic Layer";
            this.btnShawBLL.UseVisualStyleBackColor = true;
            this.btnShawBLL.Click += new System.EventHandler(this.btnShawBLL_Click);
            // 
            // dgvColumnsInfo
            // 
            this.dgvColumnsInfo.AllowUserToAddRows = false;
            this.dgvColumnsInfo.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvColumnsInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvColumnsInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColumnsInfo.Location = new System.Drawing.Point(62, 440);
            this.dgvColumnsInfo.Name = "dgvColumnsInfo";
            this.dgvColumnsInfo.ReadOnly = true;
            this.dgvColumnsInfo.Size = new System.Drawing.Size(713, 283);
            this.dgvColumnsInfo.TabIndex = 14;
            // 
            // frmGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1440, 821);
            this.Controls.Add(this.dgvColumnsInfo);
            this.Controls.Add(this.btnShawBLL);
            this.Controls.Add(this.btnShawDAL);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.gbGeneratingSettings);
            this.Controls.Add(this.gbDbSettings);
            this.Controls.Add(this.gbConnectionSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmGenerator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmGenerator";
            this.Load += new System.EventHandler(this.frmGenerator_Load);
            this.gbConnectionSettings.ResumeLayout(false);
            this.gbConnectionSettings.PerformLayout();
            this.gbDbSettings.ResumeLayout(false);
            this.gbDbSettings.PerformLayout();
            this.gbGeneratingSettings.ResumeLayout(false);
            this.gbGeneratingSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumnsInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbConnectionSettings;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gbDbSettings;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbTables;
        private System.Windows.Forms.Label lblConnectedDatabase;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox gbGeneratingSettings;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.CheckBox chkGenerateBLL;
        private System.Windows.Forms.Button btnShawDAL;
        private System.Windows.Forms.Button btnShawBLL;
        private System.Windows.Forms.Label lblSelectedTable;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbDatabases;
        private System.Windows.Forms.DataGridView dgvColumnsInfo;
    }
}