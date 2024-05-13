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

            comboBox.Items.Clear();
            comboBox.Items.AddRange(clientFields);
            comboBox.SelectedIndex = 0;
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

            comboBox.Items.Clear();
            comboBox.Items.AddRange(vehicleFields);
            comboBox.SelectedIndex = 0;
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
            if (!int.TryParse(value, out _) || !double.TryParse(value, out _))
            {
                command = new($"SELECT * FROM {table} WHERE {field} = '{value}';", conn);
            }
            else command = new($"SELECT * FROM {table} WHERE {field} = {value};", conn);

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
    }
}
