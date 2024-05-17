using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2


    // General repository interface
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);
        IEnumerable<T> GetAll();
        T GetById(int id);
    }


    // Realization General repository interface
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly List<T> _entities = new List<T>();

        public void Add(T entity)
        {
            _entities.Add(entity);
        }

        public void Remove(T entity)
        {
            _entities.Remove(entity);
        }

        public void Update(T entity)
        {
            // Realization logic updating instance in General repository  Реалізація логіки оновлення об'єкта в репозиторії
        }

        public IEnumerable<T> GetAll()
        {
            return _entities;
        }

        public T GetById(int id)
        {
            // Realization logic geting  instance by his ID Реалізація логіки отримання об'єкта за його ідентифікатором
            return null;
        }
    }
}
