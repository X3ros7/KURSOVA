using Kursova.utils;
using Kursova.Models;
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

namespace Kursova
{
    public partial class AddAccessoryForm : Form
    {
        private string connString;
        private MainForm MainForm;

        public AddAccessoryForm(string connString, MainForm mainForm)
        {
            InitializeComponent();
            this.connString = connString;
            MainForm = mainForm;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string type = typeBox.Text;
            string brand = brandBox.Text;
            string name = nameBox.Text;
            string price = priceBox.Text;
            string quantity = quantityBox.Text;

            if (StringChecker.isNullOrEmpty(type, brand, name, price, quantity)) 
            {
                MessageBox.Show("Not all values was entered.");
                return;
            }

            var accessory = new Accessory(0, name, type, brand, int.Parse(price), double.Parse(price));

            NpgsqlConnection conn = new NpgsqlConnection(connString);
            NpgsqlCommand cmd = InsertData.GenerateCommand(accessory);
            
            conn.Open();
            cmd.Connection = conn;
            var executor = new CommandExecutor(conn);
            var dataTable = new DataTable();
            if (executor.ExecuteCommand(cmd, out dataTable))
            {
                MessageBox.Show("Запис про придбання аксесуару було додано до системи");
                MainForm.dataGridView1.DataSource = dataTable;
                this.Close();
            }
        }
    }
}
