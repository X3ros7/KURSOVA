using Kursova.crud;
using Kursova.Models;
using Kursova.utils;
using Npgsql;
using System.Data;

namespace Kursova
{
    public partial class AddTestDriveForm : Form
    {
        private string connString;
        private MainForm mainForm;

        public AddTestDriveForm(string connString, MainForm mainForm)
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
            string query = "SELECT * FROM vehicle";
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
            string testdriveDate = dateBox.Text;
            string duration = durationBox.Text;

            if (StringChecker.isNullOrEmpty(clientId, vehicleId, testdriveDate, duration)) 
            {
                MessageBox.Show("Not all values was entered.");
                return;
            }

            if (!TryParseDuration(duration, out TimeSpan parsedDuration))
            {
                MessageBox.Show("Invalid duration entered");
                return;
            }

            var testDriveRecord = new TestDriveRecord(0, int.Parse(clientId), int.Parse(vehicleId), DateTime.Parse(testdriveDate), parsedDuration);

            NpgsqlConnection conn = new NpgsqlConnection(connString);
            NpgsqlCommand cmd = CreateRecord.GenerateCommand(testDriveRecord);
            
            conn.Open();
            cmd.Connection = conn;
            var executor = new CommandExecutor(conn);
            var dataTable = new DataTable();
            executor.ExecuteCommand(cmd, out dataTable);
            {
                MessageBox.Show("Запис на тест-драйв був доданий до системи");
                mainForm.dataGridView1.DataSource = dataTable;
                this.Close();
            }
        }

        static bool TryParseDuration(string durationString, out TimeSpan duration)
        {
            string[] components = durationString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            duration = TimeSpan.Zero;

            try
            {
                for (int i = 0; i < components.Length; i += 2)
                {
                    int value = int.Parse(components[i]);
                    string unit = components[i + 1].ToLower();

                    switch (unit)
                    {
                        case "day":
                        case "days":
                            duration = duration.Add(TimeSpan.FromDays(value));
                            break;
                        case "hour":
                        case "hours":
                            duration = duration.Add(TimeSpan.FromHours(value));
                            break;
                        case "minute":
                        case "minutes":
                            duration = duration.Add(TimeSpan.FromMinutes(value));
                            break;
                        case "second":
                        case "seconds":
                            duration = duration.Add(TimeSpan.FromSeconds(value));
                            break;
                        default:
                            throw new FormatException("Invalid time unit.");
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
