using Npgsql;
using System.Data;
using System.Windows.Forms;

namespace Kursova.utils
{
    public class DataTableHandler
    {
        private readonly NpgsqlConnection _conn;
        private readonly DataGridView _dataGridView;
        private CommandExecutor _executor;

        public DataTableHandler(NpgsqlConnection conn, DataGridView dataGridView)
        {
            _conn = conn;
            _dataGridView = dataGridView;
            _executor = new CommandExecutor(conn);
        }

        public void UpdateTableView(string table)
        {
            if (_conn.State != ConnectionState.Open) _conn.Open();
            var command = new NpgsqlCommand($"SELECT * FROM {table} ORDER BY 1", _conn);
            _executor.ExecuteCommand(command, _dataGridView);
        }
    }
}
