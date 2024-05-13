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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

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
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string clientId = clientIdBox.Text;
            string vehicleId = vehicleIdBox.Text;
            string date = dateBox.Text;
            string price = priceBox.Text;

            if (StringChecker.isNullOrEmpty(clientId, vehicleId, date, price))
            {
                MessageBox.Show("Not all values was entered.");
                return;
            }

            NpgsqlConnection conn = new NpgsqlConnection(connString);
            NpgsqlCommand cmd = new($"INSERT INTO\r\n\tvehicle_fee(client_id, vehicle_id, payment_date, price)\r\nVALUES\r\n\t({int.Parse(clientId)}, {int.Parse(vehicleId)}, '{DateTime.Parse(date)}', {double.Parse(price)});", conn);
            try
            {
                conn.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    mainForm.dataGridView1.DataSource = dataTable;
                }
                MessageBox.Show("Інформація про придбання авто була додана до системи");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
        }
    }
}
