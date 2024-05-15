using Npgsql;
using System.Data;
using System.Windows.Forms;

namespace Kursova.utils
{
    public class DataTableHandler
    {
        private readonly NpgsqlConnection _conn;
        private readonly DataGridView _dataGridView;

        public DataTableHandler(NpgsqlConnection conn, DataGridView dataGridView)
        {
            _conn = conn;
            _dataGridView = dataGridView;
        }

        public void UpdateTableView(string table)
        {
            if (_conn.State != ConnectionState.Open) _conn.Open();
            var command = new NpgsqlCommand($"SELECT * FROM {table} ORDER BY 1", _conn);
            ExecuteCommand(command);
        }

        private void ExecuteCommand(NpgsqlCommand command)
        {
            try
            {
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    var dataTable = new DataTable();
                    dataTable.Load(reader);
                    _dataGridView.DataSource = dataTable;
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
    }
}
