using System;
using System.Collections;
using System.Collections.Generic;
using CarDealer.Models.CarModels;

namespace CarDealer.Models
{
    public class Car
    {
        public Car()
        {
            this.CarSales = new HashSet<CarSales>();
        }

        public int Id { get; set; }

        public int MakeId { get; set; }
        public virtual Make Make { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int FuelTypeId { get; set; }

        public virtual FuelType FuelType { get; set; }

        public int EngineSize { get; set; }

        public int EuroStandartId { get; set; }

        public virtual EuroStandart EuroStandart { get; set; }

        public int GearboxId { get; set; }

        public virtual Gearbox Gearbox { get; set; }

        public int ColorId { get; set; }

        public virtual Color Color { get; set; }

        public Doors Doors { get; set; }

        public State State { get; set; }

        public int Mileage { get; set; }

        public DateTime ManufactureDate { get; set; }

        public virtual ICollection<CarSales> CarSales { get; set; }
    }
}
