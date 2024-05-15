using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursova.Models
{
    internal class Accessory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public Accessory(int id, string name, string type, string brand, int quantity, double price)
        {
            Id = id;
            Name = name;
            Type = type;
            Brand = brand;
            Quantity = quantity;
            Price = price;
        }
    }
}
