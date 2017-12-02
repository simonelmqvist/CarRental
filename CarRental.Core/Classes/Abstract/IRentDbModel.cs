using System;

namespace CarRental.Core.Classes.Abstract
{
    public interface IRentDbModel
    {
        int BookingId { get; set; }

        string RegistrationNumber { get; set; }

        string PersonalNumber { get; set; }

        string CarCategory { get; set; }

        int Mileage { get; set; }

        DateTime Date { get; set; }
    }
}