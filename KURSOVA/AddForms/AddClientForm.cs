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

namespace Kursova
{
    public partial class AddClientForm : Form
    {
        private string connString;
        private MainForm MainForm;

        public AddClientForm(string connString, MainForm mainForm)
        {
            InitializeComponent();
            this.connString = connString;
            this.MainForm = mainForm;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string name = nameBox.Text;
            string email = emailBox.Text;
            string phone = phoneBox.Text;

            if (StringChecker.isNullOrEmpty(name, email, phone)) 
            {
                MessageBox.Show("Not all values was entered.");
                return;
            }

            Client client = new Client(0, name, email, phone);
            NpgsqlConnection conn = new NpgsqlConnection(connString);
            NpgsqlCommand cmd = InsertData.GenerateCommand(client);
            
            conn.Open();
            cmd.Connection = conn;
            var executor = new CommandExecutor(conn);
            var dataTable = new DataTable();
            if (executor.ExecuteCommand(cmd, out dataTable))
            {
                MessageBox.Show("Запис про нового клієнта було додано до системи");
                MainForm.dataGridView1.DataSource = dataTable;
                this.Close();
            }
        }
    }
}
