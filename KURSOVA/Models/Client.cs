using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursova.Models
{
    internal record Client (
        int Id,
        string Name,
        string Email,
        string PhoneNumber
        );
}
