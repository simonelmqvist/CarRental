using System;
using System.ComponentModel.DataAnnotations;
using CarRental.Core.Classes.Abstract;
using Umbraco.Core.Persistence;
using Umbraco.Core.Persistence.DatabaseAnnotations;

namespace CarRental.Core.Classes.Concrete
{
    [TableName("CrRents")]
    [PrimaryKey("Id", autoIncrement = true)]
    public class RentDbModel : IRentDbModel
    {
        [Column("Id")]
        [PrimaryKeyColumn(AutoIncrement = true)]
        public int BookingId { get; set; }

        //regex?
        [Display(Name = "Registreringsnummer *")]
        public string RegistrationNumber { get; set; }

        [Display(Name = "Personnummer *")]
        [RegularExpression(@"^(?<date>\d{6}|\d{8})[-\s]?\d{4}$", ErrorMessage = "Ogiltigt personnummer")]
        public string PersonalNumber { get; set; }

        [Display(Name = "Typ av bil *")]
        public string CarCategory { get; set; }

        [Display(Name = "Mätarställning (km) *")]
        public int Mileage { get; set; }

        public DateTime Date { get; set; }
    }
}