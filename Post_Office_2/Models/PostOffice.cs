using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Post_Office_2
{
    // Repository interface for PostOffice Інтерфейс репозиторію для поштових відділень
    public interface IPostOfficeRepository
    {
        void Add(PostOffice postOffice);
        void Remove(PostOffice postOffice);
        void Update(PostOffice postOffice);
        IEnumerable<PostOffice> GetAll();
        PostOffice GetById(int id);
    }

    //Class repository for PostOffice  Клас репозиторію для поштових відділень
    public class PostOfficeRepository : IPostOfficeRepository
    {
        private readonly List<PostOffice> _postOffices = new List<PostOffice>();

        public void Add(PostOffice postOffice)
        {
            _postOffices.Add(postOffice);
        }

        public void Remove(PostOffice postOffice)
        {
            _postOffices.Remove(postOffice);
        }

        public void Update(PostOffice postOffice)
        {
            // Realization logic updating post office in General repository Реалізація логіки оновлення поштового відділення в репозиторії
        }

        public IEnumerable<PostOffice> GetAll()
        {
            return _postOffices;
        }

        public PostOffice GetById(int id)
        {
            //Realization logic geting  post office in General repository Реалізація логіки отримання поштового відділення за його ідентифікатором
            return null;
        }
    }

    // Клас поштового відділення
    //public class PostOffice
    //{
    //    public List<Parcel> Parcels { get; set; }

    //    public PostOffice()
    //    {
    //        Parcels = new List<Parcel>();
    //    }

    //    public void AddParcel(Parcel parcel)
    //    {
    //        Parcels.Add(parcel);
    //    }
    //}

    public class PostOffice : ServiceObject
    {
        public List<Parcel> Parcels { get; set; }
        // constructor
        public PostOffice()
        {
            Parcels = new List<Parcel>();
        }
        // add parcel to office
        public void AddParcel(Parcel parcel)
        {
            Parcels.Add(parcel);
        }



        // Indecsator for acess to parcel by index Індексатор для доступу до посилок за індексом
        public Parcel this[int index]
        {
            get { return Parcels[index]; }
            set { Parcels[index] = value; }
        }

        //Indecsator for acess to parcel by weight  Індексатор для доступу до посилок за вагою
        public Parcel this[int weight, DateTime dateSend]
        {
            get { return Parcels.FirstOrDefault(p => p.Weight == weight && p.DateSend == dateSend); }

        }



        // Lambda expression
        public void TestMethod(int weight, DateTime dateSend)
        {
            Action lambda1 = () => { };
            Action lambda2 = () => { };
            Action lambda3 = () => { };
            Action lambda4 = () => { };
            Action lambda5 = () => { };
            Action lambda6 = () => { };

        }

    }

}
