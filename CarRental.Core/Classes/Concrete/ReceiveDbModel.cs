using System;
using System.ComponentModel.DataAnnotations;
using CarRental.Core.Classes.Abstract;
using Umbraco.Core.Persistence;
using Umbraco.Core.Persistence.DatabaseAnnotations;

namespace CarRental.Core.Classes.Concrete
{
    [TableName("CrReceives")]
    [PrimaryKey("Id", autoIncrement = true)]
    public class ReceiveDbModel : IReceiveDbModel
    {
        [Column("Id")]
        [PrimaryKeyColumn(AutoIncrement = true)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Obligatorisk")]
        [Column("BookingId")]
        [Display(Name = "Bokningsnummer *")]
        public int BookingId { get; set; }

        [Required(ErrorMessage = "Obligatorisk")]
        [Display(Name = "Mätarställning (km) *")]
        public int Mileage { get; set; }

        [Required(ErrorMessage = "Obligatorisk")]
        [Display(Name = "Tid")]
        public DateTime Date { get; set; }
    }
}