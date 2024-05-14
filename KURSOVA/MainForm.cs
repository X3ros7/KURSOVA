using Npgsql;
using System.Collections;
using System.Data;

namespace Kursova
{
    public partial class MainForm : Form
    {
        private string connString;
        private NpgsqlConnection conn;

        #region Table's columns region
        private string[] clientFields = ["id", "name", "email", "phone_number"];
        private string[] vehicleFields = ["id", "brand", "name", "body_type", "body_color", "transmission", "fuel_type", "hp", "product_year", "product_country", "price"];
        private string[] accessoryFields = ["id", "type", "brand", "name", "price", "quantity"];
        private string[] testDriveRecordFields = ["id", "client_id", "vehicle_id", "testdrive_date", "duration"];
        private string[] vehicleFeeFields = ["id", "client_id", "vehicle_id", "payment_date", "price"];
        private string[] accessoryFeeFields = ["id", "client_id", "accessory_id", "payment_date", "quantity"];
        private string[] leasingRecordFields = ["id", "client_id", "vehicle_id", "record_date", "end_date"];
        #endregion

        public MainForm(NpgsqlConnection conn, string connString)
        {
            InitializeComponent();
            this.connString = connString;
            this.conn = conn;
            SqlConnectionReader();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void PopulateColumnsComboBox(string tableName)
        {
            columnsComboBox.Items.Clear();
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                var columns = conn.GetSchema("Columns", new[] { null, null, tableName });
                foreach (DataRow row in columns.Rows)
                {
                    columnsComboBox.Items.Add(row["column_name"]);
                }
            }
        }


        private void SqlConnectionReader()
        {
            UpdateTableView("client");
            comboBox.Items.AddRange(clientFields);
            comboBox.SelectedIndex = 0;
            PopulateColumnsComboBox("client");
        }

        private void UpdateTableView(string table)
        {
            if (conn.State != ConnectionState.Open) conn.Open();
            NpgsqlCommand command = new($"SELECT * FROM {table} ORDER BY 1", conn);
            ExecuteCommand(command);
        }

        private void ExecuteCommand(NpgsqlCommand command)
        {
            try
            {
                command.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    DataTable dataTable = new DataTable();

                    dataTable.Load(reader);
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                command.Dispose();
                conn.Close();
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            conn.Close();
        }

        private void ToolStripMenuItem_Click(ToolStripMenuItem checkedTable, string tableName, string[] fields)
        {
            foreach (ToolStripMenuItem checkbox in tableToolStripMenuItem.DropDownItems)
            {
                checkbox.Checked = false;
            }
            checkedTable.Checked = true;
            UpdateTableView(tableName);
            UpdateComboBox(fields);
        }

        private void clientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem_Click(clientTable, "client", clientFields);
            PopulateColumnsComboBox("client");
        }

        private void vehicleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem_Click(vehicleTable, "vehicle", vehicleFields);
            PopulateColumnsComboBox("vehicle");
        }

        private void testdriverecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem_Click(testdriverrecordTable, "test_drive_record", testDriveRecordFields);
            PopulateColumnsComboBox("test_drive_record");
        }

        private void accessoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem_Click(accessoryTable, "accessory", accessoryFields);
            PopulateColumnsComboBox("accessory");
        }

        private void vehiclefeeTable_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem_Click(vehiclefeeTable, "vehicle_fee", vehicleFeeFields);
            PopulateColumnsComboBox("vehicle_fee");
        }

        private void accessoryfeeTable_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem_Click(accessoryfeeTable, "accessory_fee", accessoryFeeFields);
            PopulateColumnsComboBox("accessory_fee");
        }

        private void leasingRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem_Click(leasingrecordTable, "leasing_record", leasingRecordFields);
            PopulateColumnsComboBox("leasing_record");
        }

        private void UpdateComboBox(string[] fields)
        {
            comboBox.Items.Clear();
            comboBox.Items.AddRange(fields);
            comboBox.SelectedIndex = 0;
        }

        private void searchBox_Click(object sender, EventArgs e)
        {
            var field = comboBox.SelectedItem.ToString();
            var value = valueBox.Text;
            string? table = "";
            NpgsqlCommand command;

            foreach (ToolStripMenuItem item in tableToolStripMenuItem.DropDownItems)
            {
                if (item.Checked)
                {
                    table = item.Text?.ToLower();
                }
            }

            if (string.IsNullOrEmpty(value))
            {
                UpdateTableView(table);
                return;
            }

            if (conn.State != ConnectionState.Open) conn.Open();
            if (!int.TryParse(value, out _) 
                || !double.TryParse(value, out _) 
                || !DateTime.TryParse(value, out _))
            {
                command = new($"SELECT * FROM {table} WHERE {field} = '{value}' ORDER BY 1;", conn);
            }
            else
            {
                command = new($"SELECT * FROM {table} WHERE {field} = {value} ORDER BY 1;", conn);
            }
            ExecuteCommand(command);
        }

        private void addRecordButton_Click(object sender, EventArgs e)
        {
            Dictionary<ToolStripMenuItem, (Type FormType, string TableName, string[] fields)> checkedMenuForms = new()
            {
                { clientTable, (typeof(AddClientForm), "client", clientFields) },
                { vehicleTable, (typeof(AddVehicleForm), "vehicle", vehicleFields) },
                { testdriverrecordTable, (typeof(AddTestDriveForm), "test_drive_record", testDriveRecordFields) },
                { accessoryTable, (typeof(AddAccessoryForm), "accessory", accessoryFields) },
                { vehiclefeeTable, (typeof(AddVehicleFeeForm), "vehicle_fee", vehicleFeeFields) },
                { accessoryfeeTable, (typeof(AddAccessoryFeeForm), "accessory_fee", accessoryFeeFields) },
                { leasingrecordTable, (typeof(AddLeasingForm), "leasing_record", leasingRecordFields) }
            };

            Form addForm;
            ToolStripMenuItem checkedMenuItem = checkedMenuForms.FirstOrDefault(kv => kv.Key.Checked).Key;
            if (checkedMenuItem != null)
            {
                (Type formType, string tableName, string[] fields) = checkedMenuForms[checkedMenuItem];
                addForm = (Form)Activator.CreateInstance(formType, connString, this);
                addForm.ShowDialog();
                UpdateTableView(tableName);
                if (comboBox != null)
                {
                    UpdateComboBox(fields);
                }
            }
        }

        private void deleteRecordButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                var messageBox = MessageBox.Show("Are you sure you want to delete this record?", "Delete record?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (messageBox == DialogResult.No)
                {
                    return;
                }

                DataGridViewCell selectedCell = dataGridView1.SelectedCells[0];
                int rowIndex = selectedCell.RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[rowIndex];
                string? table = "";
                NpgsqlCommand cmd;

                foreach (ToolStripMenuItem item in tableToolStripMenuItem.DropDownItems)
                {
                    if (item.Checked)
                    {
                        table = item.Text?.ToLower();
                        break;
                    }
                }
                var id = selectedRow.Cells[0].Value;

                conn.Open();
                cmd = new($"DELETE FROM {table} WHERE id = $1", conn)
                {
                    Parameters =
                    {
                        new() { Value = id }
                    }
                };
                ExecuteCommand(cmd);
                UpdateTableView(table);
            }
            else
            {
                MessageBox.Show("No cell is selected.");
            }
        }

        private void updateRecordButton_Click(object sender, EventArgs e)
        {
            string tableName = "";
            string columnName = columnsComboBox.SelectedItem?.ToString();
            string id = idTextBox.Text;
            string newValue = newValueTextBox.Text;

            foreach (ToolStripMenuItem item in tableToolStripMenuItem.DropDownItems)
            {
                if (item.Checked)
                {
                    tableName = item.Text?.ToLower();
                    break;
                }
            }

            if (string.IsNullOrEmpty(tableName) || string.IsNullOrEmpty(columnName) ||
                string.IsNullOrEmpty(id) || string.IsNullOrEmpty(newValue))
            {
                MessageBox.Show("Please select table, column and enter ID and new value.");
                return;
            }

            int.TryParse(newValue, out _);
            double.TryParse(newValue, out _);
            DateTime.TryParse(newValue, out _);

            conn.Open();
            NpgsqlCommand cmd = new($"UPDATE {tableName} SET {columnName} = @newValue WHERE id = @id", conn)
            {
                Parameters =
                {
                    new("newValue", newValue),
                    new("id", int.Parse(id))
                }
            };

            ExecuteCommand(cmd);
            UpdateTableView(tableName);
        }
    }
}