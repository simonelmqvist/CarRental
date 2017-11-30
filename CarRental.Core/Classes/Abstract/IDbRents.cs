using System.Collections.Generic;

namespace CarRental.Core.Classes.Abstract
{
    public interface IDbRents<T>
    {
        void Insert(T entity);

        void Delete(T entity);

        IEnumerable<T> GetAll();

        T GetById(int id);

        void CreateTabelIfNone();
    }
}