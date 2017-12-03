using CarRental.Core.Classes.Concrete;

namespace CarRental.Core.Classes
{
    public class CarRentalHelper
    {
        public double CalculatePrice(RentDbModel rent, ReceiveDbModel receive, int baseRent, int baseKmPrice)
        {
            var numberOfKm = receive.Mileage - rent.Mileage;
            var numberOfDays = (receive.Date - rent.Date).TotalDays;

            double price = 0;
            
            switch (rent.CarCategory)
            {
                case "Småbil":
                    price = baseRent * numberOfDays;
                    break;

                case "Kombi":
                    price = baseRent * numberOfDays * 1.3 + baseKmPrice * numberOfKm;
                    break;

                case "Lastbil":
                    price = baseRent * numberOfDays * 1.5 + baseKmPrice * numberOfKm * 1.5;
                    break;
            }

            return price;
        }
    }
}