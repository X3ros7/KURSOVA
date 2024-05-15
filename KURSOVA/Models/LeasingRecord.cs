using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursova.Models
{
    internal class LeasingRecord
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int VehicleId { get; set; }
        public DateTime RecordDate { get; set; }
        public DateTime EndDate { get; set; }

        public LeasingRecord(int id, int clientId, int vehicleId, DateTime recordDate, DateTime endDate)
        {
            Id = id;
            ClientId = clientId;
            VehicleId = vehicleId;
            RecordDate = recordDate;
            EndDate = endDate;
        }
    }
}
