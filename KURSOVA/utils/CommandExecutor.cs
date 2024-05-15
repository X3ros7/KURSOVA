﻿using Npgsql;
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

        public bool ExecuteCommand(NpgsqlCommand command, out DataTable dataTable)
        {
            dataTable = new DataTable();
            try
            {
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dataTable.Load(reader);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
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
            return !int.TryParse(value, out _) || !double.TryParse(value, out _) || !DateTime.TryParse(value, out _)
                ? new NpgsqlCommand($"SELECT * FROM {table} WHERE {field} = '{value}' ORDER BY 1;", _conn)
                : new NpgsqlCommand($"SELECT * FROM {table} WHERE {field} = {value} ORDER BY 1;", _conn);
        }

        public void DeleteRecord(string table, object id)
        {
            _conn.Open();
            var command = new NpgsqlCommand($"DELETE FROM {table} WHERE id = @id", _conn);
            command.Parameters.AddWithValue("id", id);
            ExecuteCommand(command, out _);
        }

        public void UpdateRecord(string table, string column, string id, string newValue)
        {
            _conn.Open();
            var command = !int.TryParse(newValue, out _) || !double.TryParse(newValue, out _) || !DateTime.TryParse(newValue, out _)
                ? new NpgsqlCommand($"UPDATE {table} SET {column} = '{newValue}' WHERE id = @id", _conn)
                : new NpgsqlCommand($"UPDATE {table} SET {column} = {newValue} WHERE id = @id", _conn);
            command.Parameters.AddWithValue("id", int.Parse(id));
            ExecuteCommand(command, out _);
        }
    }
}