using Npgsql;
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
            comboBox.Items.Add("hello");
            comboBox.SelectedValue = "hello";
        }

        private void SqlConnectionReader()
        {
            UpdateTableView("client");
            comboBox.Items.AddRange(clientFields);
            comboBox.SelectedIndex = 0;
        }

        private void UpdateTableView(string table)
        {
            if (conn.State != ConnectionState.Open) conn.Open();
            NpgsqlCommand command = new($"SELECT * FROM {table}", conn);
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

        private void ToolStripMenuItem_Click(object sender, EventArgs e, ToolStripMenuItem checkedTable, string tableName, string[] fields)
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
            ToolStripMenuItem_Click(sender, e, clientTable, "client", clientFields);
        }

        private void vehicleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem_Click(sender, e, vehicleTable, "vehicle", vehicleFields);
        }

        private void testdriverecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem_Click(sender, e, testdriverrecordTable, "test_drive_record", testDriveRecordFields);
        }

        private void accessoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem_Click(sender, e, accessoryTable, "accessory", accessoryFields);
        }

        private void vehiclefeeTable_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem_Click(sender, e, vehiclefeeTable, "vehicle_fee", vehicleFeeFields);
        }

        private void accessoryfeeTable_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem_Click(sender, e, accessoryfeeTable, "accessory_fee", accessoryFeeFields);
        }

        private void leasingRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem_Click(sender, e, leasingrecordTable, "leasing_record", leasingRecordFields);
        }

        private void UpdateComboBox(string[] fields)
        {
            comboBox.Items.Clear();
            comboBox.Items.AddRange(fields);
            comboBox.SelectedIndex = 0;
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form addForm;
            if (clientTable.Checked)
            {
                addForm = new AddClientForm(connString, this);
                addForm.ShowDialog();
                UpdateTableView("client");
            }
            else if (vehicleTable.Checked)
            {
                addForm = new AddVehicleForm(connString, this);
                addForm.ShowDialog();
                UpdateTableView("vehicle");
            }
            else if (accessoryTable.Checked)
            {
                addForm = new AddAccessoryForm(connString, this);
                addForm.ShowDialog();
                UpdateTableView("accessory");
            }
            else if (testdriverrecordTable.Checked)
            {
                addForm = new AddTestDriveForm(connString, this);
                addForm.ShowDialog();
                UpdateTableView("test_drive_record");
            }
            else if (vehiclefeeTable.Checked)
            {
                addForm = new AddVehicleFeeForm(connString, this);
                addForm.ShowDialog();
                UpdateTableView("vehicle_fee");
            }
            else if (accessoryfeeTable.Checked)
            {
                addForm = new AddAccessoryFeeForm(connString, this);
                addForm.ShowDialog();
                UpdateTableView("accessory_fee");
            }
            else if (leasingrecordTable.Checked)
            {
                addForm = new AddLeasingForm(connString, this);
                addForm.ShowDialog();
                UpdateTableView("leasing_record");
            }
        }

        private void searchBox_Click(object sender, EventArgs e)
        {
            var field = comboBox.SelectedItem.ToString();
            var value = valueBox.Text;
            var tables = tableToolStripMenuItem.DropDownItems;
            string? table = "";
            NpgsqlCommand command;

            foreach (ToolStripMenuItem item in tables)
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
            if (!int.TryParse(value, out _) || !double.TryParse(value, out _) || !DateTime.TryParse(value, out _))
            {
                command = new($"SELECT * FROM {table} WHERE {field} = '{value}';", conn);
            }
            else command = new($"SELECT * FROM {table} WHERE {field} = {value};", conn);

            ExecuteCommand(command);
        }
    }
}
