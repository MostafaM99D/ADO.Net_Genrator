using Ado_Net_UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Ado_Net_Core
{
    public partial class frmGenerator : Form
    {
        private string _ServerName;
        private string _DatabaseName;
        private string _TableName;
        private string _SingleTableName;
        private bool _IsConnected;
        private List<clsColumnInfo> _ColumnInfo;
        private string _DALOutput;
        private string _BLLOutput;
        public frmGenerator()
        {
            InitializeComponent();
        }
        private bool _ConnectedValidate()
        {
            if (!clsGlobal.IsValidString(_ServerName, "Server cannot be empty")) return false;
            if (!clsGlobal.IsValidString(_DatabaseName, "database cannot be empty")) return false;
            return true;
        }

        private void _LoadTablesToComboBox()
        {
            List<string> tables = clsDatabaseSettings.LoadAllTabels(_ServerName, _DatabaseName);
            if (tables.Count == 0)
            {
                MessageBox.Show("No Tables in this database", "excalamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            cbTables.Items.AddRange(tables.ToArray());
        }
        private void _LoadDatabasesToComboBox()
        {
            List<string> dbs = clsDatabaseSettings.LoadAllDatabases(_ServerName, _DatabaseName);
            if (dbs.Count == 0)
            {
                MessageBox.Show("No databases in this server", "excalamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            cbDatabases.Items.AddRange(dbs.ToArray());
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (cbDatabases.SelectedItem == null)
            {
                MessageBox.Show("Please pick up database", "excalamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            _ServerName = txtServerName.Text.Trim();
            _DatabaseName = cbDatabases.SelectedItem.ToString().Trim();

            if (!_ConnectedValidate())
                return;

            try
            {
                string conStr = "";
                if (clsDatabaseSettings.ConnectedToDatabase(_ServerName, _DatabaseName,ref conStr))
                {
                    _IsConnected = true;
                    gbConnectionSettings.Enabled = false;
                    gbDbSettings.Enabled = true;
                    lblConnectedDatabase.Text = _DatabaseName;
                    _LoadTablesToComboBox();
                    this.AcceptButton = btnNext;
                    txtOutput.Text = conStr;
                    btnCopy.Enabled = true;
                }
                else
                    _IsConnected = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _IsConnected = false;
                gbConnectionSettings.Enabled = true;
                gbDbSettings.Enabled = false;
            }
        }

        private void frmGenerator_Load(object sender, EventArgs e)
        {
            _LoadDatabasesToComboBox();
            btnReset.Enabled = false;
            cbDatabases.Select();
            btnShawBLL.Enabled = false;
            btnShawDAL.Enabled = false;
            btnChangeTable.Enabled = false;
            gbDbSettings.Enabled = false;
            gbGeneratingSettings.Enabled = false;
            btnGenerate.Enabled = false;
            btnCopy.Enabled = false;
        }


        private bool LoadColumnInfo()
        {
            _ColumnInfo = clsDatabaseSettings.GetShcemaDetails(_ServerName, _DatabaseName, _TableName);
            return _ColumnInfo != null;
        }


        private void _dgvDesign()
        {
            if (dgvColumnsInfo.Rows.Count > 0)
            {
                dgvColumnsInfo.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 12, FontStyle.Bold);
                dgvColumnsInfo.DefaultCellStyle.Font = new Font("Verdana", 12, FontStyle.Italic);

                dgvColumnsInfo.Columns[0].HeaderText = "Col.Name";
                dgvColumnsInfo.Columns[0].Width = 200;

                dgvColumnsInfo.Columns[1].HeaderText = "Col.Data Type";
                dgvColumnsInfo.Columns[1].Width = 170;

                dgvColumnsInfo.Columns[2].HeaderText = "Is Nullable";
                dgvColumnsInfo.Columns[2].Width = 150;

                dgvColumnsInfo.Columns[3].HeaderText = "Is Primary Key";
                dgvColumnsInfo.Columns[3].Width = 150;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (cbTables.SelectedItem == null)
            {
                MessageBox.Show("Please pick up a table", "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!_IsConnected)
            {
                MessageBox.Show("Please connect to the database first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _TableName = cbTables.SelectedItem.ToString();

            if (LoadColumnInfo())
            {
                if (_ColumnInfo.Count == 0)
                {
                    MessageBox.Show("Table Is Empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                dgvColumnsInfo.DataSource = _ColumnInfo;
                _dgvDesign();
            }

            txtSingleTableName.Select();
            txtOutput.Text = "";
            gbDbSettings.Enabled = false;
            gbGeneratingSettings.Enabled = true;
            btnGenerate.Enabled = true;
            lblSelectedTable.Text = cbTables.SelectedItem.ToString();
            this.AcceptButton = btnGenerate;
            btnChangeTable.Enabled = true;
            btnReset.Enabled = true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

            _IsConnected = false;
            btnChangeTable.Enabled = false;
            dgvColumnsInfo.DataSource = null;
            cbDatabases.SelectedItem = null;
            cbTables.SelectedItem = null;
            lblConnectedDatabase.Text = "????";
            lblSelectedTable.Text = "????";
            btnShawBLL.Enabled = false;
            btnShawDAL.Enabled = false;
            gbDbSettings.Enabled = false;
            gbGeneratingSettings.Enabled = false;
            btnGenerate.Enabled = false;
            btnCopy.Enabled = false;
            gbConnectionSettings.Enabled = true;
            txtSingleTableName.Text = "";
            cbDatabases.Items.Clear();
            cbTables.Items.Clear();
            txtOutput.Clear();
            _DALOutput = "";
            _BLLOutput = "";
            _LoadDatabasesToComboBox();
        }

        private bool isTableHavePrimaryKey()
        {
            foreach (clsColumnInfo c in _ColumnInfo)
                if (c.IsPrimaryKey) return true;
            return false;
        }


        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (!isTableHavePrimaryKey())
            {
                MessageBox.Show("Table have not any Primary Key", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _SingleTableName = txtSingleTableName.Text;
            if (!Regex.IsMatch(_SingleTableName, @"^[A-Za-z_][A-Za-z0-9_]*$"))
            {
                MessageBox.Show("Invalid class name format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!clsGlobal.IsValidString(_SingleTableName, "Class name connot be empty"))
                return;
            if (!_IsConnected)
            {
                MessageBox.Show("Connection is lost", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            btnCopy.Enabled = true;
            btnShawBLL.Enabled = true;
            btnShawDAL.Enabled = true;
            try
            {
                _DALOutput = clsDataAccessLayerGenerator.GenerateCode(_ServerName, _DatabaseName, _TableName, _SingleTableName);
                if (chkGenerateBLL.Checked)
                    _BLLOutput = clsBuisnessLogicLayerGenerator.GenerateCode(_ServerName, _DatabaseName, _TableName, _SingleTableName);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            txtOutput.Text = _DALOutput;
        }

        private void btnShawBLL_Click(object sender, EventArgs e)
        {
            if (!chkGenerateBLL.Checked)
            {
                MessageBox.Show("You didn't choose Generate BLL", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return ;
            }
            txtOutput.Text = _BLLOutput;
        }

        private void btnShawDAL_Click(object sender, EventArgs e)
        {
            txtOutput.Text = _DALOutput;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtOutput.Text);
          //  MessageBox.Show("Code copied to clipboard!", "Copied", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnChangeTable_Click(object sender, EventArgs e)
        {
            lblSelectedTable.Text = "????";
            txtOutput.Text = "";
            gbDbSettings.Enabled = true;
            txtSingleTableName.Text ="";
            gbGeneratingSettings.Enabled = false;
            dgvColumnsInfo.DataSource = null;
        }
    }
}