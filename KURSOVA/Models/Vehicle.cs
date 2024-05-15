using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursova.Models
{
    internal class Vehicle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string BodyType { get; set; }
        public string BodyColor { get; set; }
        public string Transmission {  get; set; }
        public string FuelType { get; set; }
        public int Hp { get; set; }
        public int ProductYear { get; set; }
        public string ProductCountry { get; set; }
        public double Price { get; set; }

        public Vehicle(int id, string name, string brand, string bodyType, string bodyColor, string transmission, string fuelType, int hp, int productYear, string productCountry, double price)
        {
            Id = id;
            Name = name;
            Brand = brand;
            BodyType = bodyType;
            BodyColor = bodyColor;
            Transmission = transmission;
            FuelType = fuelType;
            Hp = hp;
            ProductYear = productYear;
            ProductCountry = productCountry;
            Price = price;
        }
    }
}
