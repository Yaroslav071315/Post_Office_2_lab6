using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2.Data
{
    public class PostOffice : ServiceObject
    {
        public List<Parcel> Parcels { get; set; } = new List<Parcel>();

        // Зовнішній ключ для зв'язку з City
        public int CityId { get; set; }
        public City City { get; set; }
    }

}
