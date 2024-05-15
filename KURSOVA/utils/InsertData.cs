using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace Kursova.utils
{
    internal class InsertData
    {
        public readonly string insertClient = $"INSERT INTO client (name, email, phone_number) VALUES ($1, $2, $3)";
        public readonly string insertVehicle = $"INSERT INTO ";
    }
}
