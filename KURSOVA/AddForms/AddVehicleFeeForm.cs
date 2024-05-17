using Npgsql;
using System.Data;
using Kursova.utils;
using Kursova.Models;
using Kursova.crud;

namespace Kursova
{
    public partial class AddVehicleFeeForm : Form
    {
        private string connString;
        private MainForm mainForm;

        public AddVehicleFeeForm(string connString, MainForm mainForm)
        {
            InitializeComponent();
            this.connString = connString;
            this.mainForm = mainForm;
            FillClientsComboBox();
            FillVehiclesComboBox();

        }

        private void FillClientsComboBox()
        {
            clientsComboBox.Items.Clear();
            string query = "SELECT * FROM client";
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                var cmd = new NpgsqlCommand(query, conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int clientId = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    string email = reader.GetString(2);
                    string phoneNumber = reader.GetString(3);

                    string client = $"{clientId}, {name}; Email: {email}; Phone number: {phoneNumber}";
                    clientsComboBox.Items.Add(client);
                }
                reader.Close();
                conn.Close();
            }
        }

        private void FillVehiclesComboBox()
        {
            vehiclesComboBox.Items.Clear();
            string query = "SELECT v.*\r\nFROM vehicle v\r\nLEFT JOIN vehicle_fee vf ON v.id = vf.vehicle_id\r\nWHERE vf.vehicle_id IS NULL;";
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                var cmd = new NpgsqlCommand(query, conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int vehicleId = reader.GetInt32(0);
                    string brand = reader.GetString(1);
                    string name = reader.GetString(2);
                    string bodyType = reader.GetString(3);
                    string bodyColor = reader.GetString(4);
                    string transmission = reader.GetString(5);
                    string fuelType = reader.GetString(6);
                    int hp = reader.GetInt32(7);
                    int year = reader.GetInt32(8);
                    string productCountry = reader.GetString(9);
                    double price = reader.GetDouble(10);

                    string vehicle = $"{vehicleId}, {brand} {name}; Color: {bodyColor}";
                    vehiclesComboBox.Items.Add(vehicle);
                }
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var clientId = clientsComboBox.SelectedItem.ToString().Split(",")[0].Trim();
            string vehicleId = vehiclesComboBox.SelectedItem.ToString().Split(",")[0].Trim();
            string date = dateBox.Text;
            string price = priceBox.Text;

            if (StringChecker.isNullOrEmpty(clientId, vehicleId, date, price))
            {
                MessageBox.Show("Not all values was entered.");
                return;
            }

            var vehicleFee = new VehicleFee(0, int.Parse(clientId), int.Parse(vehicleId), DateTime.Parse(date), double.Parse(price));

            NpgsqlConnection conn = new NpgsqlConnection(connString);
            NpgsqlCommand cmd = CreateRecord.GenerateCommand(vehicleFee);

            conn.Open();
            cmd.Connection = conn;
            var executor = new CommandExecutor(conn);
            var dataTable = new DataTable();
            executor.ExecuteCommand(cmd, out dataTable);
            {
                MessageBox.Show("Договір про придбання авто був доданий до системи");
                mainForm.dataGridView1.DataSource = dataTable;
                this.Close();
            }
        }
    }
}
