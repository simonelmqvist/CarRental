using System;
using CarRental.Core.Classes;
using CarRental.Core.Classes.Concrete;
using NUnit.Framework;

namespace CarRental.Tests.Classes
{
    class CarRentalHelperTests
    {
        private int _baseRent = 200;
        private int _baseKmPrice = 3;

        [Test]
        public void CalculatePriceSmall()
        {
            var rent = new RentDbModel
            {
                Date = new DateTime(2017, 12, 3, 15, 0, 0),
                Mileage = 600,
                CarCategory = "Småbil"
            };

            var receive = new ReceiveDbModel
            {
                Date = new DateTime(2017, 12, 5, 15, 0, 0),
                Mileage = 680
            };

            var expectedPrice = _baseRent * 2;
            
            var crHelper = new CarRentalHelper();
            var price = crHelper.CalculatePrice(rent, receive, _baseRent, _baseKmPrice);

            Assert.AreEqual(expectedPrice, price);
        }

        [Test]
        public void CalculatePriceEstate()
        {
            var rent = new RentDbModel
            {
                Date = new DateTime(2017, 12, 3, 15, 0, 0),
                Mileage = 600,
                CarCategory = "Kombi"
            };

            var receive = new ReceiveDbModel
            {
                Date = new DateTime(2017, 12, 6, 15, 0, 0),
                Mileage = 680
            };

            var expectedPrice = _baseRent * 3 * 1.3 + _baseKmPrice * 80;

            var crHelper = new CarRentalHelper();
            var price = crHelper.CalculatePrice(rent, receive, _baseRent, _baseKmPrice);

            Assert.AreEqual(expectedPrice, price);
        }

        [Test]
        public void CalculatePriceTruck()
        {
            var rent = new RentDbModel
            {
                Date = new DateTime(2017, 12, 3, 15, 0, 0),
                Mileage = 600,
                CarCategory = "Lastbil"
            };

            var receive = new ReceiveDbModel
            {
                Date = new DateTime(2017, 12, 7, 15, 0, 0),
                Mileage = 680
            };

            var expectedPrice = _baseRent * 4 * 1.5 + _baseKmPrice * 80 * 1.5;

            var crHelper = new CarRentalHelper();
            var price = crHelper.CalculatePrice(rent, receive, _baseRent, _baseKmPrice);

            Assert.AreEqual(expectedPrice, price);
        }
    }
}
