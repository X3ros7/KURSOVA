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
        private string SelectedTable = "";

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
            var addForm = FormFactory.CreateForm(SelectedTable, _connString, this);
            addForm?.ShowDialog();
            UpdateUI(SelectedTable, GetFieldsForTable());
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

        private string GetSelectedTableName()
        {
            return SelectedTable.ToLower();
        }

        private string[] GetFieldsForTable()
        {
            return SelectedTable switch
            {
                "клієнти" => clientFields,
                "автомобілі" => vehicleFields,
                "аксесуари" => accessoryFields,
                "придбання авто" => vehicleFeeFields,
                "придбання аксесуару" => accessoryFeeFields,
                "лізинг автомобіля" => leasingRecordFields,
                "тест-драйв" => testDriveRecordFields,
                _ => Array.Empty<string>()
            };
        }

        private void клієнтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectedTable = "client";
            UpdateUI("client", clientFields);
        }

        private void автомобіліToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectedTable = "vehicle";
            UpdateUI("vehicle", vehicleFields);
        }

        private void аксесуариToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectedTable = "accessory";
            UpdateUI("accessory", accessoryFields);
        }

        private void придбанняАвтоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectedTable = "vehicle_fee";
            UpdateUI("vehicle_fee", vehicleFeeFields);
        }

        private void придбанняАксесуаруToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectedTable = "accessory_fee";
            UpdateUI("accessory_fee", accessoryFeeFields);
        }

        private void лізингАвтомобіляToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectedTable = "leasing_record";
            UpdateUI("leasing_record", leasingRecordFields);
        }

        private void тестдрайвToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectedTable = "test_drive_record";
            UpdateUI("test_drive_record", testDriveRecordFields);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            _conn.Close();
        }
    }
}
