using Kursova.crud;
using Kursova.Models;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Kursova
{
    public partial class AddVehicleForm : Form
    {
        private string connString;
        private MainForm mainForm;
        
        public AddVehicleForm(string connString, MainForm mainForm)
        {
            InitializeComponent();
            this.connString = connString;
            this.mainForm = mainForm;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string brand = brandBox.Text;
            string name = nameBox.Text;
            string bodyType = bodytypeBox.Text;
            string bodyColor = bodycolorBox.Text;
            string transmission = transmissionBox.Text;
            string fuelType = fueltypeBox.Text;
            string hp = hpBox.Text;
            string productYear = prodyearBox.Text;
            string productCountry = prodcountryBox.Text;
            string price = priceBox.Text;

            if (StringChecker.isNullOrEmpty(brand, name, bodyType, bodyColor, transmission, fuelType, hp, productYear, productCountry, price))
            { 
                MessageBox.Show("Not all values was entered.");   
                return;
             }
            var vehicle = new Vehicle(0, name, brand, bodyType, bodyColor, transmission, fuelType, int.Parse(hp), int.Parse(productYear), productCountry, double.Parse(price));

            NpgsqlConnection conn = new(connString);
            NpgsqlCommand cmd = CreateRecord.GenerateCommand(vehicle);

            conn.Open();
            cmd.Connection = conn;
            var executor = new CommandExecutor(conn);
            var dataTable = new DataTable();
            if (executor.ExecuteCommand(cmd, out dataTable))
            {
                MessageBox.Show("Запис про авто був доданий до системи");
                mainForm.dataGridView1.DataSource = dataTable;
                this.Close();
            }
        }
    }
}
