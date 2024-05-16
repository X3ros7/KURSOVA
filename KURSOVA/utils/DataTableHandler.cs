using Npgsql;
using System.Data;
using System.Windows.Forms;

namespace Kursova.utils
{
    internal class DataTableHandler
    {
        private readonly NpgsqlConnection _connection;

        public DataTableHandler(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public void UpdateTableView(string tableName, MainForm form)
        {
            string query = $"SELECT * FROM {tableName}";
            var command = new NpgsqlCommand(query, _connection);
            var executor = new CommandExecutor(_connection);
            executor.ExecuteCommand(command, out DataTable dataTable);
            form.dataGridView1.DataSource = dataTable;
        }
    }
}
