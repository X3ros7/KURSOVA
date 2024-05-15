using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursova.Models
{
    internal class TestDriveRecord
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int VehicleId { get; set; }
        public DateTime TestDriveDate {  get; set; }
        public TimeSpan Duration { get; set; }

        public TestDriveRecord(int id, int clientId, int vehicleId, DateTime testDriveDate, TimeSpan duration)
        {
            Id = id;
            ClientId = clientId;
            VehicleId = vehicleId;
            TestDriveDate = testDriveDate;
            Duration = duration;
        }
    }
}
