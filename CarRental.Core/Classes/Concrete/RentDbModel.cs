﻿using System;
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
        public int Id { get; set; }

        [Required(ErrorMessage = "Obligatorisk")]
        [Column("BookingId")]
        [Display(Name = "Bokningsnummer *")]
        public int BookingId { get; set; }

        [Required(ErrorMessage = "Obligatorisk")]
        [RegularExpression(@"[A-Za-z]{3}[0-9]{3}$", ErrorMessage = "Ogiltigt registreringsnummer")]
        [Display(Name = "Registreringsnummer *")]
        public string RegistrationNumber { get; set; }

        [Required(ErrorMessage = "Obligatorisk")]
        [Display(Name = "Personnummer *")]
        public string PersonalNumber { get; set; }

        [Display(Name = "Typ av bil *")]
        [Required(ErrorMessage = "Obligatorisk")]
        public string CarCategory { get; set; }

        [Required(ErrorMessage = "Obligatorisk")]
        [Display(Name = "Mätarställning (km) *")]
        public int Mileage { get; set; }

        public DateTime Date { get; set; }
    }
}