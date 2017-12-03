using System;

namespace CarRental.Core.Classes.Abstract
{
    public interface IReceiveDbModel
    {
        int Id { get; set; }

        int BookingId { get; set; }

        int Mileage { get; set; }

        DateTime Date { get; set; }
    }
}