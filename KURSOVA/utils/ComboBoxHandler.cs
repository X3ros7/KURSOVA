using Npgsql;
using System.Data;
using System.Windows.Forms;

namespace Kursova.utils
{
    public class ComboBoxHandler
    {
        private readonly ComboBox _columnsComboBox;
        private readonly ComboBox _fieldsComboBox;

        public ComboBoxHandler(ComboBox columnsComboBox, ComboBox fieldsComboBox)
        {
            _columnsComboBox = columnsComboBox;
            _fieldsComboBox = fieldsComboBox;
        }

        public void PopulateColumnsComboBox(string tableName, string connString)
        {
            _columnsComboBox.Items.Clear();
            using var conn = new NpgsqlConnection(connString);
            conn.Open();
            var columns = conn.GetSchema("Columns", new[] { null, null, tableName });
            foreach (DataRow row in columns.Rows)
            {
                _columnsComboBox.Items.Add(row["column_name"]);
            }
            _columnsComboBox.SelectedIndex = 0;
        }

        public void UpdateComboBox(string[] fields)
        {
            _fieldsComboBox.Items.Clear();
            _fieldsComboBox.Items.AddRange(fields);
            _fieldsComboBox.SelectedIndex = 0;
        }
    }
}
