using System;

namespace CarRental.Core.Classes.Abstract
{
    public interface IRentFormModel
    {
        string RegistrationNumber { get; set; }

        string PersonalNumber { get; set; }

        Enums.CarCategory CarCategory { get; set; }

        int Mileage { get; set; }

        DateTime Date { get; set; }
    }
}
