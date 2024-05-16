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

        public NpgsqlCommand CreateSearchCommand(string table, string field, string value)
        {
            string query = $"SELECT * FROM {table} WHERE {field} = @value";
            var command = new NpgsqlCommand(query, _connection);
            command.Parameters.AddWithValue("value", value);
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