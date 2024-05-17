using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Post_Office_2

{
    // Repository interface for clients Інтерфейс репозиторію для клієнтів
    public interface IClientRepository
    {
        void Add(Client client);
        void Remove(Client client);
        void Update(Client client);
        IEnumerable<Client> GetAll();
        Client GetById(int id);
    }

    // Class repository for clients  Клас репозиторію для клієнтів
    public class ClientRepository : IClientRepository
    {
        private readonly List<Client> _clients = new List<Client>();

        public void Add(Client client)
        {
            _clients.Add(client);
        }

        public void Remove(Client client)
        {
            _clients.Remove(client);
        }

        public void Update(Client client)
        {
            //  Realization logic updating client in General repository Реалізація логіки оновлення клієнта в репозиторії
        }

        public IEnumerable<Client> GetAll()
        {
            return _clients;
        }

        public Client GetById(int id)
        {
            // Realization logic geting client in General repository   Реалізація логіки отримання клієнта за його ідентифікатором
            return null;
        }
    }

    // Клас клієнта
    //public class Client
    //{
    //    public string Name { get; set; }
    //    public string Surname { get; set; }

    //    public Client(string name, string surname)
    //    {
    //        Name = name;
    //        Surname = surname;
    //    }

    //    public void SendParcel(Parcel parcel, PostOffice postOffice)
    //    {
    //        postOffice.Parcels.Add(parcel);
    //        parcel.Send();
    //    }
    //}







    public class Client : ServiceObject
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        //constructor
        public Client(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public void SendParcel(Parcel parcel, PostOffice postOfifce)
        {
            postOfifce.Parcels.Add(parcel);
            parcel.Send();

        }



    }

}
   
    
