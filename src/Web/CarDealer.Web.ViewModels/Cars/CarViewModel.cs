namespace CarDealer.Web.ViewModels.Cars
{
    using CarDealer.Web.ViewModels.Cars.CarExtras;
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    public class CarViewModel
    {
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string CategoryName { get; set; }

        public string FuelType { get; set; }

        public int EngineSize { get; set; }

        public int HorsePower { get; set; }

        public string EuroStandart { get; set; }

        public string Gearbox { get; set; }

        public string Color { get; set; }

        public string Seats { get; set; }

        public string Doors { get; set; }

        public string State { get; set; }

        public int Mileage { get; set; }

        public DateTime ManufactureDate { get; set; }

        public string ManufactureDateAsString => this.ManufactureDate.ToString(CultureInfo.InvariantCulture);

        public IEnumerable<string> Extras { get; set; }
    }
}
