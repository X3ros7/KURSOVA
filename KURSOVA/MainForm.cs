using Kursova.utils;
using Npgsql;
using System.Data;

namespace Kursova
{
    public partial class MainForm : Form
    {
        public readonly string connString;
        public readonly NpgsqlConnection conn;
        private readonly DataTableHandler _dataTableHandler;
        private readonly ComboBoxHandler _comboBoxHandler;
        private readonly CommandExecutor _commandExecutor;
        private string selectedTable = "client";

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
            this.connString = connString;
            this.conn = conn;
            _commandExecutor = new CommandExecutor(this.conn);
            _dataTableHandler = new DataTableHandler(this);
            _comboBoxHandler = new ComboBoxHandler(columnsComboBox);

            FormInitialization();
        }

        private void FormInitialization()
        {
            UpdateUI("client", clientFields);
        }

        private void UpdateUI(string tableName, string[] fields)
        {
            _dataTableHandler.UpdateTableView(tableName);
            _comboBoxHandler.PopulateColumnsComboBox(tableName, connString);
        }

        private void searchBox_Click(object sender, EventArgs e)
        {
            var value = valueTextBox.Text;
            var table = selectedTable;

            if (string.IsNullOrEmpty(value))
            {
                _dataTableHandler.UpdateTableView(table);
                return;
            }

            var command = _commandExecutor.CreateSearchCommand(table, value);
            _commandExecutor.ExecuteCommand(command, out DataTable dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void addRecordButton_Click(object sender, EventArgs e)
        {
            var addForm = FormFactory.CreateForm(GetSelectedTableName(), connString, this);
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
                var table = selectedTable;

                _commandExecutor.DeleteRecord(table, id);
                UpdateUI(selectedTable, GetFieldsForTable());
            }
            else
            {
                MessageBox.Show("No cell is selected.");
            }
        }

        private void updateRecordButton_Click(object sender, EventArgs e)
        {
            var table = selectedTable;
            var column = columnsComboBox.SelectedItem?.ToString();
            var id = idTextBox.Text;
            var newValue = newValueTextBox.Text;

            if (StringChecker.isNullOrEmpty(table, column, id, newValue))
            {
                MessageBox.Show("Please select table, column and enter ID and new value.");
                return;
            }

            _commandExecutor.UpdateRecord(table, column, int.Parse(id), newValue);
            UpdateUI(table, GetFieldsForTable());
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
                "êë³ºíòè" => "client",
                "àâòîìîá³ë³" => "vehicle",
                "àêñåñóàðè" => "accessory",
                "òåñò-äðàéâ" => "test_drive_record",
                "äîãîâ³ð" => "vehicle_fee",
                _ => null
            };
        }

        private string[] GetFieldsForTable()
        {
            return GetSelectedTableName() switch
            {
                "êë³ºíòè" => clientFields,
                "àâòîìîá³ë³" => vehicleFields,
                "àêñåñóàðè" => accessoryFields,
                "ïðèäáàííÿ àâòî" => vehicleFeeFields,
                "ïðèäáàííÿ àêñåñóàðó" => accessoryFeeFields,
                "ë³çèíã àâòîìîá³ëÿ" => leasingRecordFields,
                "òåñò-äðàéâ" => testDriveRecordFields,
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

        private void êë³ºíòèToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateUI("client", clientFields);
            UncheckMenus();
            selectedTable = "client";
            clientToolStripMenu.Checked = true;
            valueTextBox.Text = "";
        }

        private void àâòîìîá³ë³ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateUI("vehicle", vehicleFields);
            UncheckMenus();
            selectedTable = "vehicle";
            vehicleToolStripMenu.Checked = true;
            valueTextBox.Text = "";
        }

        private void àêñåñóàðèToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateUI("accessory", accessoryFields);
            UncheckMenus();
            selectedTable = "accessory";
            accessoryToolStripMenuItem.Checked = true;
            valueTextBox.Text = "";
        }

        private void ïðèäáàííÿÀâòîToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateUI("vehicle_fee", vehicleFeeFields);
            UncheckMenus();
            selectedTable = "vehicle_fee";
            vehicleFeeToolStripMenuItem.Checked = true;
            valueTextBox.Text = "";
        }

        private void ïðèäáàííÿÀêñåñóàðóToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateUI("accessory_fee", accessoryFeeFields);
            UncheckMenus();
            selectedTable = "accessory_fee";
            accessoryToolStripMenuItem.Checked = true;
            valueTextBox.Text = "";
        }

        private void ë³çèíãÀâòîìîá³ëÿToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateUI("leasing_record", leasingRecordFields);
            UncheckMenus();
            selectedTable = "leasing_record";
            leasingRecordToolStripMenuItem.Checked = true;
            valueTextBox.Text = "";
        }

        private void òåñòäðàéâToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateUI("test_drive_record", testDriveRecordFields);
            UncheckMenus();
            selectedTable = "test_drive_record";
            òåñòäðàéâToolStripMenuItem.Checked = true;
            valueTextBox.Text = "";
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            conn.Close();
        }

        private void êë³ºíòàToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnAddButtonClick("client", clientFields);
        }

        private void àâòîìîá³ëüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnAddButtonClick("vehicle", vehicleFields);
        }

        private void OnAddButtonClick(string tableName, string[] fields)
        {
            var createForm = FormFactory.CreateForm(tableName, connString, this);
            createForm.ShowDialog();
            UpdateUI(tableName, fields);
        }

        private void àêñåñóàðToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnAddButtonClick("accessory", accessoryFields);
        }

        private void çàïèñÍàÒåñòäðàéâToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnAddButtonClick("test_drive_record", testDriveRecordFields);
        }

        private void ïðèäáàííÿÀâòîToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            OnAddButtonClick("vehicle_fee", vehicleFeeFields);
        }

        private void ïðèäáàííÿÀêñåñóàðóToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            OnAddButtonClick("accessory_fee", accessoryFeeFields);
        }

        private void ë³çèíãÀâòîToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnAddButtonClick("leasing_record", leasingRecordFields);
        }

        private void âèäàëèòèToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                var confirmation = MessageBox.Show("Are you sure you want to delete this record?", "Delete record?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmation == DialogResult.No) return;

                var selectedRow = dataGridView1.SelectedCells[0].OwningRow;
                var id = selectedRow.Cells[0].Value;
                var table = selectedTable;

                _commandExecutor.DeleteRecord(table, id);
                UpdateUI(selectedTable, GetFieldsForTable());
            }
            else
            {
                MessageBox.Show("No cell is selected.");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                object idValue = selectedRow.Cells[0].Value;
                idTextBox.Text = idValue?.ToString();
            }
        }
    }
}