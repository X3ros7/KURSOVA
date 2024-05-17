namespace Kursova.utils
{
    public static class FormFactory
    {
        public static Form CreateForm(string formType, string connString, MainForm mainForm)
        {
            return formType switch
            {
                "client" => new AddClientForm(connString, mainForm),
                "vehicle" => new AddVehicleForm(connString, mainForm),
                "test_drive_record" => new AddTestDriveForm(connString, mainForm),
                "accessory" => new AddAccessoryForm(connString, mainForm),
                "accessory_fee" => new AddAccessoryFeeForm(connString, mainForm),
                "vehicle_fee" => new AddVehicleFeeForm(connString, mainForm),
                "leasing_record" => new AddLeasingForm(connString, mainForm),
                _ => throw new Exception("Invalid form argument!")
            }; ;
        }
    }
}