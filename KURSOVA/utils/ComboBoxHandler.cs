using Npgsql;

namespace Kursova.utils
{
    internal class ComboBoxHandler
    {
        private readonly ComboBox _columnsComboBox;

        public ComboBoxHandler(ComboBox columnsComboBox)
        {
            _columnsComboBox = columnsComboBox;
        }

        public void PopulateColumnsComboBox(string tableName, string connectionString)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string query = $"SELECT column_name FROM information_schema.columns WHERE table_name = '{tableName}'";
                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    _columnsComboBox.Items.Clear();
                    while (reader.Read())
                    {
                        _columnsComboBox.Items.Add(reader.GetString(0));
                    }
                }
            }
        }
    }
}
