﻿namespace CarDealer.Services.Data.Dtos
{
    using System;
    using System.Globalization;

    public class CarDto
    {
        public int Id { get; set; }

        public string Make { get; set; }

        public string Category { get; set; }

        public string FuelType { get; set; }

        public int EngineSize { get; set; }

        public string EuroStandart { get; set; }

        public string Gearbox { get; set; }

        public string Color { get; set; }

        public string Doors { get; set; }

        public string State { get; set; }

        public int Mileage { get; set; }

        public DateTime ManufactureDate { get; set; }

        public string ManufactureDateAsString => this.ManufactureDate.ToString(CultureInfo.InvariantCulture);
    }
}