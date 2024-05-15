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

            NpgsqlConnection conn = new NpgsqlConnection(connString);
            NpgsqlCommand cmd = new($"INSERT INTO \r\n\taccessory(type, brand, name, price, quantity)\r\nVALUES\r\n\t('{type}', '{brand}', '{name}', '{double.Parse(price)}', '{int.Parse(quantity)}');", conn);
            
            conn.Open();
            var executor = new CommandExecutor(conn);
            if (executor.ExecuteCommand(cmd, MainForm.dataGridView1))
            {
                MessageBox.Show("Запис про придбання аксесуару було додано до системи");
                this.Close();
            }
        }
    }
}
