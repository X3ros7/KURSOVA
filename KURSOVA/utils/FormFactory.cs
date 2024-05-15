using System;
using System.Windows.Forms;

namespace Kursova.utils
{
    public static class FormFactory
    {
        public static Form CreateForm(ToolStripMenuItem checkedMenuItem, string connString, MainForm mainForm)
        {
            return checkedMenuItem.Name switch
            {
                "clientTable" => new AddClientForm(connString, mainForm),
                "vehicleTable" => new AddVehicleForm(connString, mainForm),
                "testdriverecordTable" => new AddTestDriveForm(connString, mainForm),
                "accessoryTable" => new AddAccessoryForm(connString, mainForm),
                "vehiclefeeTable" => new AddVehicleFeeForm(connString, mainForm),
                "accessoryfeeTable" => new AddAccessoryFeeForm(connString, mainForm),
                "leasingrecordTable" => new AddLeasingForm(connString, mainForm),
                _ => throw new Exception("Invalid form argument!")
            }; ;
        }
    }
}
