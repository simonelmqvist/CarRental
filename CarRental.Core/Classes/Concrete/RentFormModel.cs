using System;
using System.ComponentModel.DataAnnotations;
using CarRental.Core.Classes.Abstract;

namespace CarRental.Core.Classes.Concrete
{
    public class RentForm : IRentFormModel
    {
        public string BookingId { get; set; }

        //regex?
        [Display(Name = "Registreringsnummer *")]
        public string RegistrationNumber { get; set; }

        [Display(Name = "Personnummer *")]
        [RegularExpression(@"^(?<date>\d{6}|\d{8})[-\s]?\d{4}$", ErrorMessage = "Ogiltigt personnummer")]
        public string PersonalNumber { get; set; }

        [Display(Name = "Typ av bil *")]
        public Enums.CarCategory CarCategory { get; set; }

        [Display(Name = "Mätarställning (km) *")]
        public int Mileage { get; set; }

        public DateTime Date { get; set; }
    }
}