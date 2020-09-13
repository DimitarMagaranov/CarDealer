namespace CarDealer.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using CarDealer.Models.CarModels;

    public class Car
    {
        public int Id { get; set; }

        public int MakeId { get; set; }
        public virtual Make Make { get; set; }

        public Category Category { get; set; }

        public FuelType FuelType { get; set; }

        public int EngineSize { get; set; }

        public EuroStandart EuroStandart { get; set; }

        public Gearbox Gearbox { get; set; }

        public Color Color { get; set; }

        public Doors Doors { get; set; }

        public State State { get; set; }

        public decimal Price { get; set; }

        public int Mileage { get; set; }

        public DateTime ManufactureDate { get; set; }
    }
}
