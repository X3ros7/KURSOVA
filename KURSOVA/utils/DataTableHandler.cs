using Npgsql;
using System.Data;
using System.Windows.Forms;

namespace Kursova.utils
{
    internal class DataTableHandler
    {
        private MainForm _mainForm;

        public DataTableHandler(MainForm mainForm)
        {
            this._mainForm = mainForm;
        }

        public void UpdateTableView(string tableName)
        {
            string query = "";
            switch (tableName)
            {
                case "client":
                    query = "SELECT name, email, phone_number FROM client";
                    break;
                case "vehicle":
                    query = "SELECT brand, name, body_type, body_color, hp, product_year, product_country, price FROM vehicle";
                    break;
                case "accessory":
                    query = "SELECT type, name, brand, price, quantity FROM accessory";
                    break;
                case "test_drive_record":
                    query = $"SELECT client.name AS client_name, vehicle.brand, vehicle.name AS vehicle_name, test_drive_record.testdrive_date, test_drive_record.duration FROM test_drive_record INNER JOIN client ON test_drive_record.client_id = client.id INNER JOIN vehicle ON test_drive_record.vehicle_id = vehicle.id";
                    break;
                case "leasing_record":
                    query = $"SELECT client.name, vehicle.brand, vehicle.name AS vehicle_name, leasing_record.record_date, leasing_record.end_date FROM leasing_record INNER JOIN client ON leasing_record.client_id = client.id INNER JOIN vehicle ON leasing_record.vehicle_id = vehicle.id";
                    break;
                case "vehicle_fee":
                    query = $"SELECT client.name AS client_name, vehicle.brand, vehicle.name AS vehicle_name, vehicle_fee.payment_date, vehicle_fee.price FROM vehicle_fee INNER JOIN client ON vehicle_fee.client_id = client.id INNER JOIN vehicle ON vehicle_fee.vehicle_id = vehicle.id";
                    break;
                case "accessory_fee":
                    query = $"SELECT client.name AS client_name, accessory.name AS accessory_name, accessory_fee.payment_date, accessory_fee.quantity FROM accessory_fee INNER JOIN client ON accessory_fee.client_id = client.id INNER JOIN accessory ON accessory_fee.accessory_id = accessory.id";
                    break;
            }
            var command = new NpgsqlCommand(query, _mainForm.conn);
            var executor = new CommandExecutor(_mainForm.conn);
            executor.ExecuteCommand(command, out DataTable dataTable);
            _mainForm.dataGridView1.DataSource = dataTable;
        }
    }
}
