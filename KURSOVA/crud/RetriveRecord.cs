using Kursova.Models;
using Npgsql;

namespace Kursova.crud
{
    internal class RetrieveRecord
    {
        private static readonly string _regularSelect = "SELECT * FROM {0} ORDER BY 1";
        private static readonly string _specificSelect = "SELECT * FROM {0} WHERE {1} = {2}";

        public static NpgsqlCommand GenerateCommand(Type modelType)
        {
            string commandString = "";

            if (modelType == typeof(Client))
                commandString = String.Format(_regularSelect, "client");
            else if (modelType == typeof(Vehicle))
                commandString = String.Format(_regularSelect, "vehicle");
            else if (modelType == typeof(Accessory))
                commandString = String.Format(_regularSelect, "accessory");
            else if (modelType == typeof(AccessoryFee))
                commandString = String.Format(_regularSelect, "accessory_fee");
            else if (modelType == typeof(LeasingRecord))
                commandString = String.Format(_regularSelect, "leasing_record");
            else if (modelType == typeof(TestDriveRecord))
                commandString = String.Format(_regularSelect, "test_drive_record");
            else if (modelType == typeof(VehicleFee))
                commandString = String.Format(_regularSelect, "vehicle_fee");
            else
                throw new ArgumentException("Invalid model type");

            return new NpgsqlCommand(commandString);
        }

        public static NpgsqlCommand GenerateCommand(object model) 
        {
            throw new NotImplementedException();
        }
            

        /*public static NpgsqlCommand GenerateCommand(Type modelType, object column, object value)
        {
            string commandString = "";

            if (modelType == typeof(Client))
                commandString = String.Format(_specificSelect, "client", column, value);
            else if (modelType == typeof(Vehicle))
                commandString = _selectVehicle;
            else if (modelType == typeof(Accessory))
                commandString = _selectAccessory;
            else if (modelType == typeof(AccessoryFee))
                commandString = _selectAccessoryFee;
            else if (modelType == typeof(LeasingRecord))
                commandString = _selectLeasingRecord;
            else if (modelType == typeof(TestDriveRecord))
                commandString = _selectTestDriveRecord;
            else if (modelType == typeof(VehicleFee))
                commandString = _selectVehicleFee;
            else
                throw new ArgumentException("Invalid model type");

            return new NpgsqlCommand(commandString + $"WHERE id = {id}");
        }*/
    }
}
