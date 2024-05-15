using Kursova.crud;
using Kursova.Models;
using Npgsql;
using System.Data;
using System.Windows.Forms;

namespace Kursova.utils
{
    public class DataTableHandler
    {
        private readonly NpgsqlConnection _conn;
        private CommandExecutor _executor;
        private Dictionary<string, Type> tableModel = new Dictionary<string, Type>
        {
            { "client", typeof(Client) },
            { "vehicle", typeof(Vehicle) },
            { "accessory", typeof(Accessory) },
            { "test_drive_record", typeof(TestDriveRecord) },
            { "leasing_record", typeof(LeasingRecord) },
            { "vehicle_fee", typeof(VehicleFee) },
            { "accessory_fee", typeof(AccessoryFee) }
        };

        public DataTableHandler(NpgsqlConnection conn)
        {
            _conn = conn;
            _executor = new CommandExecutor(conn);
        }

        public void UpdateTableView(string table, MainForm mainForm)
        {
            if (_conn.State != ConnectionState.Open) _conn.Open();
            var model = tableModel[table];
            var command = RetrieveRecord.GenerateCommand(model);
            command.Connection = _conn;
            var dataTable = new DataTable();
            _executor.ExecuteCommand(command, out dataTable);
            mainForm.dataGridView1.DataSource = dataTable;
        }
    }
}
