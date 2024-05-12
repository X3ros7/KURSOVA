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

            if (brand == null)
            {
                MessageBox.Show("Enter the brand");
                return;
            }
            if (name == null)
            {
                MessageBox.Show("Enter a name");
                return;
            }
            if (bodyType == null)
            {
                MessageBox.Show("Enter a body type");
                return; 
            }
            if (bodyColor == null)
            {
                MessageBox.Show("Enter a body color");
                return;
            }
            if (transmission == null)
            {
                MessageBox.Show("Enter a transmission");
                return;
            }
            if (fuelType == null)
            {
                MessageBox.Show("Enter a fuel type");
                return;
            }
            if (hp == null) 
            {
                MessageBox.Show("Enter a HP");
                return;
            }
            if (productYear == null)
            {
                MessageBox.Show("Enter a product year");
                return;
            }
            if (productCountry == null)
            {
                MessageBox.Show("Enter a product country");
                return;
            }
            if (price == null)
            {
                MessageBox.Show("Enter a price");
                return;
            }

            NpgsqlConnection conn = new(connString);
            NpgsqlCommand cmd = new($"INSERT INTO vehicle (brand, name, body_type, body_color, transmission, fuel_type, hp, product_year, product_country, price)\n" +
                $"VALUES ('{brand}', '{name}', '{bodyType}', '{bodyColor}', '{transmission}', '{fuelType}', '{int.Parse(hp)}', '{int.Parse(productYear)}', '{productCountry}', '{double.Parse(price)}')", conn);

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
                MessageBox.Show("Автомобіль було додано до системи");
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
