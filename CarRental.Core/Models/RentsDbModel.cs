using System;
using Umbraco.Core.Persistence;
using Umbraco.Core.Persistence.DatabaseAnnotations;

namespace CarRental.Core.Models
{
    public class RentsDbModel
    {
        [TableName("CrRents")]
        [PrimaryKey("Id", autoIncrement = true)]
        public class BookingDbModel
        {
            [Column("Id")]
            [PrimaryKeyColumn(AutoIncrement = true)]
            public string BookingId { get; set; }

            public string RegistrationNumber { get; set; }

            public string PersonalNumber { get; set; }

            public string CarCategory { get; set; }

            public int Mileage { get; set; }

            public DateTime Date { get; set; }
        }
    }
}
