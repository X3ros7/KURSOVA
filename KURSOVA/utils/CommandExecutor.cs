using Npgsql;
using System.Data;

namespace Kursova.utils
{
    internal class CommandExecutor
    {
        private readonly NpgsqlConnection _connection;

        public CommandExecutor(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public void ExecuteCommand(NpgsqlCommand command, out DataTable dataTable)
        {
            using (var adapter = new NpgsqlDataAdapter(command))
            {
                dataTable = new DataTable();
                adapter.Fill(dataTable);
            }
        }

        public NpgsqlCommand CreateSearchCommand(string table, string value)
        {
            string query = "";
            switch(table)
            {
                case "test_drive_record":
                    query = $"SELECT \r\n\ttdr.id,\r\n\tc.name,\r\n\tv.brand,\r\n\tv.name,\r\n\ttdr.testdrive_date,\r\n\ttdr.duration\r\nFROM \r\n\ttest_drive_record tdr\r\nJOIN\r\n\tclient c ON tdr.client_id = c.id\r\nJOIN \r\n\tvehicle v ON tdr.vehicle_id = v.id\r\nWHERE\r\n\tCONCAT(tdr.*)LIKE '%{value}%' OR CONCAT(c.*) LIKE '%{value}%' OR CONCAT(v.*) LIKE '%{value}%';";
                    break;
                case "vehicle_fee":
                    query = $"SELECT \r\n    vf.id,\r\n    c.name AS client_name,\r\n    v.brand,\r\n    v.name AS vehicle_name,\r\n    vf.payment_date,\r\n    vf.price\r\nFROM \r\n    vehicle_fee vf\r\nJOIN\r\n    client c ON vf.client_id = c.id\r\nJOIN \r\n    vehicle v ON vf.vehicle_id = v.id\r\nWHERE\r\n    CONCAT(vf.*) LIKE '%{value}%' OR CONCAT(c.*) LIKE '%{value}%' OR CONCAT(v.*) LIKE '%{value}%';\r\n";
                    break;
                default:
                    query = $"SELECT * FROM {table} WHERE CONCAT({table}.*) LIKE '%{value}%'";
                    break;
            }
            var command = new NpgsqlCommand(query, _connection);
            return command;
        }

        public void DeleteRecord(string table, object id)
        {
            string query = $"DELETE FROM {table} WHERE id = @id";
            var command = new NpgsqlCommand(query, _connection);
            command.Parameters.AddWithValue("id", id);
            command.ExecuteNonQuery();
        }

        public void UpdateRecord(string table, string column, string id, string newValue)
        {
            string query = $"UPDATE {table} SET {column} = @newValue WHERE id = @id";
            var command = new NpgsqlCommand(query, _connection);
            command.Parameters.AddWithValue("newValue", newValue);
            command.Parameters.AddWithValue("id", id);
            command.ExecuteNonQuery();
        }
    }
}