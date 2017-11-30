using System;
using System.ComponentModel.DataAnnotations;
using CarRental.Core.Classes.Abstract;

namespace CarRental.Core.Classes.Concrete
{
    public class ReceiveFormModel : IReceiveFormModel
    {
        public string BookingId { get; set; }

        [Display(Name = "Mätarställning (km) *")]
        public int Mileage { get; set; }

        public DateTime Date { get; set; }
    }
}