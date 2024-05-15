using Kursova.crud;
using Kursova.Models;
using Kursova.utils;
using Npgsql;
using System.Data;

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

            var accessoryFee = new AccessoryFee(0, int.Parse(clientId), int.Parse(accessoryId), DateTime.Parse(date), int.Parse(quantity));

            var conn = new NpgsqlConnection(connString);
            var cmd = CreateRecord.GenerateCommand(accessoryFee); 

            conn.Open();
            cmd.Connection = conn;
            var executor = new CommandExecutor(conn);
            var dataTable = new DataTable();
            if (executor.ExecuteCommand(cmd, out dataTable))
            {
                MessageBox.Show("Запис про аксесуар було додано до системи");
                mainForm.dataGridView1.DataSource = dataTable;
                this.Close();
            }
        }
    }
}
