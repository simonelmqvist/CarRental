using System.Collections.Generic;

namespace CarRental.Core.Classes.Abstract
{
    public interface IDbReceives<T>
    {
        void Insert(T entity);

        void Delete(T entity);

        IReceiveDbModel GetByBookingId(int id);
    }
}