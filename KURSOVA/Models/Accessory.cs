using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursova.Models
{
    internal record Accessory (
        int Id,
        string Name,
        string Type,
        string Brand,
        int Quantity,
        double Price
        );
    
}
