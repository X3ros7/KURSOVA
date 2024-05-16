using Kursova.services;
using Kursova.utils;
using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace Kursova
{
    public partial class MainForm : Form
    {
        private readonly string _connString;
        private readonly NpgsqlConnection _conn;
        private readonly DataTableHandler _dataTableHandler;
        private readonly ComboBoxHandler _comboBoxHandler;
        private readonly CommandExecutor _commandExecutor;

        #region Table's columns region
        private readonly string[] clientFields = { "id", "name", "email", "phone_number" };
        private readonly string[] vehicleFields = { "id", "brand", "name", "body_type", "body_color", "transmission", "fuel_type", "hp", "product_year", "product_country", "price" };
        private readonly string[] accessoryFields = { "id", "type", "brand", "name", "price", "quantity" };
        private readonly string[] testDriveRecordFields = { "id", "client_id", "vehicle_id", "testdrive_date", "duration" };
        private readonly string[] vehicleFeeFields = { "id", "client_id", "vehicle_id", "payment_date", "price" };
        private readonly string[] accessoryFeeFields = { "id", "client_id", "accessory_id", "payment_date", "quantity" };
        private readonly string[] leasingRecordFields = { "id", "client_id", "vehicle_id", "record_date", "end_date" };
        #endregion

        public MainForm(NpgsqlConnection conn, string connString)
        {
            InitializeComponent();
            _connString = connString;
            _conn = conn;
            _commandExecutor = new CommandExecutor(_conn);
            _dataTableHandler = new DataTableHandler(_conn);
            _comboBoxHandler = new ComboBoxHandler(columnsComboBox, comboBox);

            FormInitialization();
        }

        private void FormInitialization()
        {
            UpdateUI("client", clientFields);
        }

        private void UpdateUI(string tableName, string[] fields)
        {
            _dataTableHandler.UpdateTableView(tableName, this);
            _comboBoxHandler.UpdateComboBox(fields);
            _comboBoxHandler.PopulateColumnsComboBox(tableName, _connString);
        }

        private void searchBox_Click(object sender, EventArgs e)
        {
            var field = comboBox.SelectedItem?.ToString();
            var value = valueTextBox.Text;
            var table = GetSelectedTableName();

            if (string.IsNullOrEmpty(value))
            {
                _dataTableHandler.UpdateTableView(table, this);
                return;
            }

            var command = _commandExecutor.CreateSearchCommand(table, field, value);
            _commandExecutor.ExecuteCommand(command, out DataTable dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void addRecordButton_Click(object sender, EventArgs e)
        {
            var addForm = FormFactory.CreateForm(GetSelectedTableName(), _connString, this);
            addForm?.ShowDialog();
            UpdateUI(GetSelectedTableName(), GetFieldsForTable());
        }

        private void deleteRecordButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                var confirmation = MessageBox.Show("Are you sure you want to delete this record?", "Delete record?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmation == DialogResult.No) return;

                var selectedRow = dataGridView1.SelectedCells[0].OwningRow;
                var id = selectedRow.Cells[0].Value;
                var table = GetSelectedTableName();

                _commandExecutor.DeleteRecord(table, id);
            }
            else
            {
                MessageBox.Show("No cell is selected.");
            }
        }

        private void updateRecordButton_Click(object sender, EventArgs e)
        {
            var table = GetSelectedTableName();
            var column = columnsComboBox.SelectedItem?.ToString();
            var id = idTextBox.Text;
            var newValue = newValueTextBox.Text;

            if (StringChecker.isNullOrEmpty(table, column, id, newValue))
            {
                MessageBox.Show("Please select table, column and enter ID and new value.");
                return;
            }

            _commandExecutor.UpdateRecord(table, column, id, newValue);
        }

        private ToolStripMenuItem GetCheckedMenuItem()
        {
            foreach (ToolStripMenuItem item in menuStrip1.Items)
            {
                if (item.Checked) return item;
            }
            return null;
        }

        private string GetSelectedTableName()
        {
            var checkedMenuItem = GetCheckedMenuItem();
            return checkedMenuItem?.Text.ToLower() switch
            {
                "�볺���" => "client",
                "��������" => "vehicle",
                "���������" => "accessory",
                "����-�����" => "detailed_test_drive_record",
                "������" => "detailed_vehicle_fee",
                _ => null
            };
        }

        private string[] GetFieldsForTable()
        {
            return GetSelectedTableName() switch
            {
                "�볺���" => clientFields,
                "��������" => vehicleFields,
                "���������" => accessoryFields,
                "��������� ����" => vehicleFeeFields,
                "��������� ���������" => accessoryFeeFields,
                "����� ���������" => leasingRecordFields,
                "����-�����" => testDriveRecordFields,
                _ => Array.Empty<string>()
            };
        }

        private void UncheckMenus()
        {
            foreach (ToolStripMenuItem item in menuStrip1.Items)
            {
                item.Checked = false;
            }
        }

        private void �볺���ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateUI("client", clientFields);
            UncheckMenus();
            clientToolStripMenu.Checked = true;
        }

        private void ��������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateUI("vehicle", vehicleFields);
            UncheckMenus();
            vehicleToolStripMenu.Checked = true;
        }

        private void ���������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateUI("accessory", accessoryFields);
            UncheckMenus();
            accessoryToolStripMenuItem.Checked = true;
        }

        private void �������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateUI("detailed_vehicle_fee", vehicleFeeFields);
            UncheckMenus();
            vehicleFeeToolStripMenuItem.Checked = true;
        }

        private void ������������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateUI("detailed_accessory_fee", accessoryFeeFields);
            UncheckMenus();
            accessoryToolStripMenuItem.Checked= true;
        }

        private void ��������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateUI("detailed_leasing_record", leasingRecordFields);
            UncheckMenus();
            leasingRecordToolStripMenuItem.Checked = true;
        }

        private void ���������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateUI("detailed_test_drive_record", testDriveRecordFields);
            UncheckMenus();
            ���������ToolStripMenuItem.Checked = true;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            _conn.Close();
        }

        private void �����ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
