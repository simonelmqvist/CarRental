using System;
using Umbraco.Core.Persistence;
using Umbraco.Core.Persistence.DatabaseAnnotations;

namespace CarRental.Core.Models
{
    public class ReceivesDbModel
    {
        [TableName("CrRents")]
        [PrimaryKey("Id", autoIncrement = true)]
        public class BookingDbModel
        {
            [Column("Id")]
            [PrimaryKeyColumn(AutoIncrement = true)]
            public string Id { get; set; }

            public string BookingId { get; set; }

            public int Mileage { get; set; }

            public DateTime Date { get; set; }
        }
    }
}
