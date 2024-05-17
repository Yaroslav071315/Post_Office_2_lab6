using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2.Data
{
    public class Parcel : ServiceObject
    {
        public int Weight { get; set; }
        public DateTime DateSend { get; set; }
        public DateTime DateCome { get; set; }
        public decimal Price { get; set; }

        // Зовнішній ключ для зв'язку з PostOffice
        public int PostOfficeId { get; set; } // Foreign key
        public PostOffice PostOffice { get; set; } // Navigation property

        public Parcel(int weight, DateTime dateSend, DateTime dateCome, decimal price)
        {
            Weight = weight;
            DateSend = dateSend;
            DateCome = dateCome;
            Price = price;
        }
    }
}
