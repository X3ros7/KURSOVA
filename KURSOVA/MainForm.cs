using Npgsql;
using System.Data;

namespace Kursova
{
    public partial class MainForm : Form
    {
        private string connString;
        private NpgsqlConnection conn;

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

        private void SqlConnectionReader()
        {
            UpdateTableView("client");
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
            if (clientTable.Checked)
            {
                AddClientForm addForm = new(connString, this);
                addForm.ShowDialog();
                UpdateTableView("client");
            }
            else if (vehicleTable.Checked)
            {
                AddVehicleForm addForm = new(connString, this);
                addForm.ShowDialog();
                UpdateTableView("vehicle");
            }
            else if (accessoryTable.Checked)
            {
                AddAccessoryForm addForm = new(connString, this);
                addForm.ShowDialog();
                UpdateTableView("accessory");
            }
            else if (testdriverrecordTable.Checked)
            {
                AddTestDriveForm addForm = new(connString, this);
                addForm.ShowDialog();
                UpdateTableView("test_drive_record");
            }
            else if (vehiclefeeTable.Checked)
            {
                AddVehicleFeeForm addForm = new(connString, this);
                addForm.ShowDialog();
                UpdateTableView("vehicle_fee");
            }
            else if (accessoryfeeTable.Checked)
            {
                AddAccessoryFeeForm addForm = new(connString, this);
                addForm.ShowDialog();
                UpdateTableView("accessory_fee");
            }
            /*else if (leasingrecordTable.Checked)
            {
                AddLeasingRecordForm addForm = new(connString, this);
                addForm.ShowDialog();
                UpdateTableView("leasing_record");
            }*/
        }
    }
}
