using Npgsql;
using System.Data;
using System.Windows.Forms;

namespace Kursova.utils
{
    public class CommandExecutor
    {
        private readonly NpgsqlConnection _conn;

        public CommandExecutor(NpgsqlConnection conn)
        {
            _conn = conn;
        }

        public void ExecuteCommand(NpgsqlCommand command, DataGridView dataGridView)
        {
            try
            {
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    var dataTable = new DataTable();
                    dataTable.Load(reader);
                    dataGridView.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                command.Dispose();
                _conn.Close();
            }
        }

        public NpgsqlCommand CreateSearchCommand(string table, string field, string value)
        {
            _conn.Open();
            return !int.TryParse(value, out _) && !double.TryParse(value, out _) && !DateTime.TryParse(value, out _)
                ? new NpgsqlCommand($"SELECT * FROM {table} WHERE {field} = '{value}' ORDER BY 1;", _conn)
                : new NpgsqlCommand($"SELECT * FROM {table} WHERE {field} = {value} ORDER BY 1;", _conn);
        }

        public void DeleteRecord(string table, object id)
        {
            _conn.Open();
            var command = new NpgsqlCommand($"DELETE FROM {table} WHERE id = @id", _conn);
            command.Parameters.AddWithValue("id", id);
            ExecuteCommand(command, null);
        }

        public void UpdateRecord(string table, string column, string id, string newValue)
        {
            _conn.Open();
            var command = !int.TryParse(newValue, out _) && !double.TryParse(newValue, out _) && !DateTime.TryParse(newValue, out _)
                ? new NpgsqlCommand($"UPDATE {table} SET {column} = '{newValue}' WHERE id = @id", _conn)
                : new NpgsqlCommand($"UPDATE {table} SET {column} = {newValue} WHERE id = @id", _conn);
            command.Parameters.AddWithValue("id", int.Parse(id));
            ExecuteCommand(command, null);
        }
    }
}