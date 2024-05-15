using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursova.Models
{
    internal class VehicleFee
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int VehicleId { get; set; }
        public DateTime PaymentDate { get; set; }
        public double Price { get; set; }

        public VehicleFee(int id, int clientId, int vehicleId, DateTime paymentDate, double price)
        {
            Id = id;
            ClientId = clientId;
            VehicleId = vehicleId;
            PaymentDate = paymentDate;
            Price = price;
        }
    }
}
