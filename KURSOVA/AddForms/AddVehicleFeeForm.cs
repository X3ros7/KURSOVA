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
