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
    public partial class AddLeasingForm : Form
    {
        private string connString;
        private MainForm mainForm;

        public AddLeasingForm(string connString, MainForm mainForm)
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
            string endDate = endDateBox.Text;

            if (StringChecker.isNullOrEmpty(clientId, vehicleId, date, endDate))
            {
                MessageBox.Show("Not all values was entered.");
                return;
            }

            NpgsqlConnection conn = new NpgsqlConnection(connString);
            NpgsqlCommand cmd = new($"INSERT INTO leasing_record (client_id, vehicle_id, record_date, end_date) VALUES ($1, $2, $3, $4)", conn) 
            {
                Parameters =
                {
                    new() { Value = int.Parse(clientId) },
                    new() { Value = int.Parse(vehicleId) },
                    new() { Value = DateTime.Parse(date) },
                    new() { Value = DateTime.Parse(endDate) }
                }
            };
            
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
                MessageBox.Show("Запис про лізинг авто було додано до системи");
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
