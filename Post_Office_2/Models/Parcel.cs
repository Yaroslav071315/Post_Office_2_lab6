using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post_Office_2
{
    //Repository interface for Parcel Інтерфейс репозиторію для посилок
    public interface IParcelRepository
    {
        void Add(Parcel parcel);
        void Remove(Parcel parcel);
        void Update(Parcel parcel);
        IEnumerable<Parcel> GetAll();
        Parcel GetById(int id);
    }

    // Class repository for Parcel
    public class ParcelRepository : IParcelRepository
    {
        private readonly List<Parcel> _parcels = new List<Parcel>();

        public void Add(Parcel parcel)
        {
            _parcels.Add(parcel);
        }

        public void Remove(Parcel parcel)
        {
            _parcels.Remove(parcel);
        }

        public void Update(Parcel parcel)
        {
            //Realization logic updating parcel in General repository Реалізація логіки оновлення посилки в репозиторії
        }

        public IEnumerable<Parcel> GetAll()
        {
            return _parcels;
        }

        public Parcel GetById(int id)
        {
            //Realization logic geting  parcel in General repository Реалізація логіки отримання посилки за її ідентифікатором
            return null;
        }
    }

    // Клас посилки
    //public class Parcel
    //{
    //    public int Weight { get; set; }
    //    public DateTime DateSend { get; set; }
    //    public DateTime DateCome { get; set; }
    //    public decimal Price { get; set; }

    //    public Parcel(int weight, DateTime dateSend, DateTime dateCome, decimal price)
    //    {
    //        Weight = weight;
    //        DateSend = dateSend;
    //        DateCome = dateCome;
    //        Price = price;
    //    }

    //    public void Send()
    //    {
    //        // Логіка відправлення посилки
    //    }
    //}






    public class Parcel : ServiceObject
    {
        public int Weight { get; set; }
        public DateTime DateSend { get; set; }
        public DateTime DateCome { get; set; }
        public decimal Price { get; set; }
        // parcel constructor

        public Parcel(int weight, DateTime dateSend, DateTime dateCome, decimal price)
        {
            Weight = weight;
            DateSend = dateSend;
            DateCome = dateCome;
            Price = price;

        }
        // method for sending parcel
        public void Send()
        {

        }


    }
}
