using Npgsql;
using Kursova.Models;

namespace Kursova
{
    internal class CreateRecord
    {
        private static readonly string _insertClient = "INSERT INTO client (name, email, phone_number) VALUES ";
        private static readonly string _insertVehicle = "INSERT INTO vehicle (brand, name, body_type, body_color, transmission, fuel_type, hp, product_year, product_country, price) VALUES ";
        private static readonly string _insertAccessory = "INSERT INTO accessory(type, brand, name, price, quantity) VALUES ";
        private static readonly string _insertAccessoryFee = "INSERT INTO accessory_fee (client_id, accessory_id, payment_date, quantity) VALUES ";
        private static readonly string _insertLeasingRecord = "INSERT INTO leasing_record (client_id, vehicle_id, record_date, end_date) VALUES ";
        private static readonly string _insertTestDriveRecord = "INSERT INTO test_drive_record (client_id, vehicle_id, testdrive_date, duration) VALUES ";
        private static readonly string _insertVehicleFee = "INSERT INTO vehicle_fee(client_id, vehicle_id, payment_date, price) VALUES ";

        public static NpgsqlCommand GenerateCommand(object model)
        {
            string commandString = "";
            switch (model)
            {
                case Client client:
                    commandString = _insertClient + $"('{client.Name}', '{client.Email}', '{client.PhoneNumber}')";
                    break;
                case Vehicle vehicle:
                    commandString = _insertVehicle + $"('{vehicle.Brand}', '{vehicle.Name}', '{vehicle.BodyType}', '{vehicle.BodyColor}', '{vehicle.Transmission}', '{vehicle.FuelType}', {vehicle.Hp}, {vehicle.ProductYear}, '{vehicle.ProductCountry}', {vehicle.Price})";
                    break;
                case Accessory accessory:
                    commandString = _insertAccessory + $"('{accessory.Type}', '{accessory.Brand}', '{accessory.Name}', {accessory.Price}, {accessory.Quantity})";
                    break;
                case AccessoryFee accessoryFee:
                    commandString = _insertAccessoryFee + $"({accessoryFee.ClientId}, {accessoryFee.AccessoryId}, '{accessoryFee.PaymentDate}', {accessoryFee.Quantity})";
                    break;
                case LeasingRecord leasingRecord:
                    commandString = _insertLeasingRecord + $"({leasingRecord.ClientId}, {leasingRecord.VehicleId}, '{leasingRecord.RecordDate}', '{leasingRecord.EndDate}')";
                    break;
                case TestDriveRecord testDriveRecord:
                    commandString = _insertTestDriveRecord + $"({testDriveRecord.ClientId}, {testDriveRecord.VehicleId}, '{testDriveRecord.TestDriveDate}', {testDriveRecord.Duration})";
                    break;
                case VehicleFee vehicleFee:
                    commandString = _insertVehicleFee + $"({vehicleFee.ClientId}, {vehicleFee.VehicleId}, '{vehicleFee.PaymentDate}', {vehicleFee.Price})";
                    break;
                default:
                    throw new Exception("Invalid argument");
            }

            return new NpgsqlCommand(commandString);
        }
    }
}
