using Npgsql;
using System.Data;

namespace Kursova
{
    public partial class MainForm : Form
    {
        private string connString;
        private NpgsqlConnection conn;
        private string[] clientFields = ["id", "name", "email", "phone_number"];
        private string[] vehicleFields = ["id", "brand", "name", "body_type", "body_color", "transmission", "fuel_type", "hp", "product_year", "product_country", "price"];
        private string[] accessoryFields = ["id", "type", "brand", "name", "price", "quantity"];
        private string[] testDriveRecordFields = ["id", "client_id", "vehicle_id", "testdrive_date", "duration"];
        private string[] vehicleFeeFields = ["id", "client_id", "vehicle_id", "payment_date", "price"];
        private string[] accessoryFeeFields = ["id", "client_id", "accessory_id", "payment_date", "quantity"];
        private string[] leasingRecordFields = ["id", "client_id", "vehicle_id", "record_date", "end_date"];

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

        private void ÍÎ≥∫ÌÚËToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clientTable.Checked = true;
            vehicleTable.Checked = false;
            accessoryTable.Checked = false;
            testdriverrecordTable.Checked = false;
            vehiclefeeTable.Checked = false;
            accessoryfeeTable.Checked = false;
            leasingrecordTable.Checked = false;
            UpdateTableView("client");
            UpdateComboBox(clientFields);
        }

        private void ‡‚ÚÓÏÓ·≥Î≥ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clientTable.Checked = false;
            vehicleTable.Checked = true;
            accessoryTable.Checked = false;
            testdriverrecordTable.Checked = false;
            vehiclefeeTable.Checked = false;
            accessoryfeeTable.Checked = false;
            leasingrecordTable.Checked = false;
            UpdateTableView("vehicle");
            UpdateComboBox(vehicleFields);
        }

        private void Á‡ÔËÒÕ‡“ÂÒÚ‰‡È‚ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clientTable.Checked = false;
            vehicleTable.Checked = false;
            accessoryTable.Checked = false;
            testdriverrecordTable.Checked = true;
            vehiclefeeTable.Checked = false;
            accessoryfeeTable.Checked = false;
            leasingrecordTable.Checked = false;
            UpdateTableView("test_drive_record");
            UpdateComboBox(testDriveRecordFields);
        }

        private void ‡ÍÒÂÒÛ‡ËToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clientTable.Checked = false;
            vehicleTable.Checked = false;
            accessoryTable.Checked = true;
            testdriverrecordTable.Checked = false;
            vehiclefeeTable.Checked = false;
            accessoryfeeTable.Checked = false;
            leasingrecordTable.Checked = false;
            UpdateTableView("accessory");
            UpdateComboBox(accessoryFields);
        }

        private void vehiclefeeTable_Click(object sender, EventArgs e)
        {
            clientTable.Checked = false;
            vehicleTable.Checked = false;
            accessoryTable.Checked = false;
            testdriverrecordTable.Checked = false;
            vehiclefeeTable.Checked = true;
            accessoryfeeTable.Checked = false;
            leasingrecordTable.Checked = false;
            UpdateTableView("vehicle_fee");
            UpdateComboBox(vehicleFeeFields);
        }

        private void accessoryfeeTable_Click(object sender, EventArgs e)
        {
            clientTable.Checked = false;
            vehicleTable.Checked = false;
            accessoryTable.Checked = false;
            testdriverrecordTable.Checked = false;
            vehiclefeeTable.Checked = false;
            accessoryfeeTable.Checked = true;
            leasingrecordTable.Checked = false;
            UpdateTableView("accessory_fee");
            UpdateComboBox(accessoryFeeFields);
        }

        private void leasingRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clientTable.Checked = false;
            vehicleTable.Checked = false;
            accessoryTable.Checked = false;
            testdriverrecordTable.Checked = false;
            vehiclefeeTable.Checked = false;
            accessoryfeeTable.Checked = false;
            leasingrecordTable.Checked = true;
            UpdateTableView("leasing_record");
            UpdateComboBox(leasingRecordFields);
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
                    break;
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
                command = new($"SELECT * FROM {table} WHERE {field} = '{value}';", conn);
            }
            else command = new($"SELECT * FROM {table} WHERE {field} = {value};", conn);

            ExecuteCommand(command);
        }
    }
}
