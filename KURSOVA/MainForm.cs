using Kursova.utils;
using Npgsql;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Kursova
{
    public partial class MainForm : Form
    {
        private string connString;
        private NpgsqlConnection conn;
        private readonly DataTableHandler _dataTableHandler;
        private readonly ComboBoxHandler _comboBoxHandler;
        private readonly CommandExecutor _commandExecutor;

        #region Table's columns region
        private string[] clientFields = { "id", "name", "email", "phone_number" };
        private string[] vehicleFields = { "id", "brand", "name", "body_type", "body_color", "transmission", "fuel_type", "hp", "product_year", "product_country", "price" };
        private string[] accessoryFields = { "id", "type", "brand", "name", "price", "quantity" };
        private string[] testDriveRecordFields = { "id", "client_id", "vehicle_id", "testdrive_date", "duration" };
        private string[] vehicleFeeFields = { "id", "client_id", "vehicle_id", "payment_date", "price" };
        private string[] accessoryFeeFields = { "id", "client_id", "accessory_id", "payment_date", "quantity" };
        private string[] leasingRecordFields = { "id", "client_id", "vehicle_id", "record_date", "end_date" };
        #endregion

        public MainForm(NpgsqlConnection conn, string connString)
        {
            InitializeComponent();
            this.connString = connString;
            this.conn = conn;
            _dataTableHandler = new DataTableHandler(this.conn, dataGridView1);
            _comboBoxHandler = new ComboBoxHandler(columnsComboBox, comboBox);
            _commandExecutor = new CommandExecutor(this.conn);

            SqlConnectionReader();
        }

        private void SqlConnectionReader()
        {
            _dataTableHandler.UpdateTableView("client");
            _comboBoxHandler.UpdateComboBox(clientFields);
            _comboBoxHandler.PopulateColumnsComboBox("client", connString);
        }

        private void ToolStripMenuItem_Click(ToolStripMenuItem checkedTable, string tableName, string[] fields)
        {
            foreach (ToolStripMenuItem checkbox in tableToolStripMenuItem.DropDownItems)
            {
                checkbox.Checked = false;
            }
            checkedTable.Checked = true;
            _dataTableHandler.UpdateTableView(tableName);
            _comboBoxHandler.UpdateComboBox(fields);
            _comboBoxHandler.PopulateColumnsComboBox(tableName, connString);
        }

        private void clientToolStripMenuItem_Click(object sender, EventArgs e) => ToolStripMenuItem_Click(clientTable, "client", clientFields);
        private void vehicleToolStripMenuItem_Click(object sender, EventArgs e) => ToolStripMenuItem_Click(vehicleTable, "vehicle", vehicleFields);
        private void testdriverecordToolStripMenuItem_Click(object sender, EventArgs e) => ToolStripMenuItem_Click(testdriverrecordTable, "test_drive_record", testDriveRecordFields);
        private void accessoryToolStripMenuItem_Click(object sender, EventArgs e) => ToolStripMenuItem_Click(accessoryTable, "accessory", accessoryFields);
        private void vehiclefeeTable_Click(object sender, EventArgs e) => ToolStripMenuItem_Click(vehiclefeeTable, "vehicle_fee", vehicleFeeFields);
        private void accessoryfeeTable_Click(object sender, EventArgs e) => ToolStripMenuItem_Click(accessoryfeeTable, "accessory_fee", accessoryFeeFields);
        private void leasingRecordToolStripMenuItem_Click(object sender, EventArgs e) => ToolStripMenuItem_Click(leasingrecordTable, "leasing_record", leasingRecordFields);

        private void searchBox_Click(object sender, EventArgs e)
        {
            var field = comboBox.SelectedItem.ToString();
            var value = valueTextBox.Text;
            var table = GetSelectedTableName();

            if (string.IsNullOrEmpty(value))
            {
                _dataTableHandler.UpdateTableView(table);
                return;
            }

            var command = _commandExecutor.CreateSearchCommand(table, field, value);
            _commandExecutor.ExecuteCommand(command, dataGridView1);
        }

        private void addRecordButton_Click(object sender, EventArgs e)
        {
            var checkedMenuItem = GetCheckedMenuItem();
            if (checkedMenuItem == null) return;

            var addForm = FormFactory.CreateForm(checkedMenuItem, connString, this);
            addForm?.ShowDialog();
            _dataTableHandler.UpdateTableView(checkedMenuItem.Text.ToLower());
            _comboBoxHandler.UpdateComboBox(GetFieldsForTable(checkedMenuItem));
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
                _dataTableHandler.UpdateTableView(table);
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

            if (string.IsNullOrEmpty(table) || string.IsNullOrEmpty(column) || string.IsNullOrEmpty(id) || string.IsNullOrEmpty(newValue))
            {
                MessageBox.Show("Please select table, column and enter ID and new value.");
                return;
            }

            _commandExecutor.UpdateRecord(table, column, id, newValue);
            _dataTableHandler.UpdateTableView(table);
        }

        private ToolStripMenuItem GetCheckedMenuItem()
        {
            foreach (ToolStripMenuItem item in tableToolStripMenuItem.DropDownItems)
            {
                if (item.Checked) return item;
            }
            return null;
        }

        private string GetSelectedTableName()
        {
            var checkedMenuItem = GetCheckedMenuItem();
            return checkedMenuItem?.Text.ToLower();
        }

        private string[] GetFieldsForTable(ToolStripMenuItem menuItem)
        {
            return menuItem.Name switch
            {
                "clientTable" => clientFields,
                "vehicleTable" => vehicleFields,
                "testdriverecordTable" => testDriveRecordFields,
                "accessoryTable" => accessoryFields,
                "vehiclefeeTable" => vehicleFeeFields,
                "accessoryfeeTable" => accessoryFeeFields,
                "leasingrecordTable" => leasingRecordFields,
                _ => Array.Empty<string>()
            };
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            conn.Close();
        }
    }
}