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
        private MainForm mainForm;

        public AddClientForm(string connString, MainForm mainForm)
        {
            InitializeComponent();
            this.connString = connString;
            this.mainForm = mainForm;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string name = nameBox.Text;
            string email = emailBox.Text;
            string phone = phoneBox.Text;

            /*if (name == null)
            {
                MessageBox.Show("Введіть ім'я");
                return;
            }
            if (email == null)
            {
                MessageBox.Show("Введіть електрону адресу");
                return;
            }
            if (phone == null)
            {
                MessageBox.Show("Введіть номер телефону");
                return;
            }*/
            if (StringChecker.isNullOrEmpty(name, email, phone)) 
            {
                MessageBox.Show("Not all values was entered.");
                return;
            }

            NpgsqlConnection conn = new NpgsqlConnection(connString);
            NpgsqlCommand cmd = new($"INSERT INTO client (name, email, phone_number) VALUES ('{name}', '{email}', '{phone}')", conn);
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
                MessageBox.Show("Клієнта був додано до системи");
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
