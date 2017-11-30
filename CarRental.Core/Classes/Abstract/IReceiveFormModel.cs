using System;

namespace CarRental.Core.Classes.Abstract
{
    public interface IReceiveFormModel
    {
        string BookingId { get; set; }

        int Mileage { get; set; }

        DateTime Date { get; set; }
    }
}
