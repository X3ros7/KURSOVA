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

namespace Kursova
{
    public partial class AddAccessoryFeeForm : Form
    {
        private string connString;
        private MainForm mainForm;

        public AddAccessoryFeeForm(string connString, MainForm mainForm)
        {
            InitializeComponent();
            this.connString = connString;
            this.mainForm = mainForm;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string clientId = clientIdBox.Text;
            string accessoryId = accessoryIdBox.Text;
            string date = dateBox.Text;
            string quantity = quantityBox.Text;

            if (StringChecker.isNullOrEmpty(clientId, accessoryId, date, quantity)) 
            {
                MessageBox.Show("Not all values was entered.");
                return;
            }

            var conn = new NpgsqlConnection(connString);
            var cmd = new NpgsqlCommand("INSERT INTO accessory_fee (client_id, accessory_id, payment_date, quantity) VALUES ($1, $2, $3, $4)", conn)
            {
                Parameters =
                {
                    new() { Value = int.Parse(clientId) },
                    new() { Value = int.Parse(accessoryId) },
                    new() { Value = DateTime.Parse(date) },
                    new() { Value = int.Parse(quantity) }
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
                MessageBox.Show("Запис про придбання аксесуару було додано до системи");
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
