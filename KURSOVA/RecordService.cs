using Kursova.utils;
using System.Data;

namespace Kursova.services
{
    internal class RecordService
    {
        private readonly CommandExecutor _commandExecutor;
        private readonly DataTableHandler _dataTableHandler;

        public RecordService(CommandExecutor commandExecutor, DataTableHandler dataTableHandler)
        {
            _commandExecutor = commandExecutor;
            _dataTableHandler = dataTableHandler;
        }

        public void SearchRecords(string table, string field, string value, MainForm form)
        {
            var command = _commandExecutor.CreateSearchCommand(table, value);
            _commandExecutor.ExecuteCommand(command, out DataTable dataTable);
            form.dataGridView1.DataSource = dataTable;
        }

        public void DeleteRecord(string table, object id, MainForm form)
        {
            _commandExecutor.DeleteRecord(table, id);
            _dataTableHandler.UpdateTableView(table);
        }

        public void UpdateRecord(string table, string column, string id, string newValue, MainForm form)
        {
            _commandExecutor.UpdateRecord(table, column, id, newValue);
            _dataTableHandler.UpdateTableView(table);
        }
    }
}
