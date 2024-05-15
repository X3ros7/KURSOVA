using Kursova.utils;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*INSERT INTO 
test_drive_record(client_id, vehicle_id, testdrive_date, duration)
VALUES
    (100, 100, '2023-12-12', '01:00');*/

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
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string clientId = clientIdBox.Text;
            string vehicleId = vehicleIdBox.Text;
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

            NpgsqlConnection conn = new NpgsqlConnection(connString);
            NpgsqlCommand cmd = new NpgsqlCommand($"INSERT INTO \r\n\ttest_drive_record (client_id, vehicle_id, testdrive_date, duration)\r\nVALUES\r\n\t({int.Parse(clientId)}, {int.Parse(vehicleId)}, '{DateTime.Parse(testdriveDate)}', '{parsedDuration}');", conn);
            
            conn.Open();
            var executor = new CommandExecutor(conn);
            if (executor.ExecuteCommand(cmd, mainForm.dataGridView1))
            {
                MessageBox.Show("Запис на тест-драйв був доданий до системи");
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
