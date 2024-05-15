using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursova.Models
{
    internal class AccessoryFee
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int AccessoryId { get; set; }
        public DateTime PaymentDate { get; set; }
        public int Quantity { get; set; }

        public AccessoryFee(int id, int clientId, int accessoryId, DateTime paymentDate, int quantity)
        {
            Id = id;
            ClientId = clientId;
            AccessoryId = accessoryId;
            PaymentDate = paymentDate;
            Quantity = quantity;
        }
    }
}
