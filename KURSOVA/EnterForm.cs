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
    public partial class EnterForm : Form
    {
        public EnterForm()
        {
            InitializeComponent();
        }

        public void EnterButton_Click(object sender, EventArgs e)
        {
            string connectionString = $"Server=localhost;Port=5432;Database=carshop; User Id = {textBox1.Text}; Password = {textBox2.Text}";
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);

            try
            {
                conn.Open();
                MainForm mainForm = new MainForm(conn, connectionString);
                this.Hide();
                mainForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
