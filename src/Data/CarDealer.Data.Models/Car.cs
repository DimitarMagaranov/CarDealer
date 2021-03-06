﻿namespace CarDealer.Data.Models
{
    using System;
    using System.Collections.Generic;

    using CarDealer.Data.Common.Models;
    using CarDealer.Data.Models.CarModels;

    public class Car : BaseDeletableModel<int>
    {
        public Car()
        {
            this.Sales = new HashSet<Sale>();
            this.CarExtras = new HashSet<CarExtra>();
        }

        public int MakeId { get; set; }

        public virtual Make Make { get; set; }

        public int ModelId { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int FuelTypeId { get; set; }

        public virtual FuelType FuelType { get; set; }

        public int? HorsePower { get; set; }

        public int EngineSize { get; set; }

        public Seats Seats { get; set; }

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

        public ICollection<Sale> Sales { get; set; }

        public ICollection<CarExtra> CarExtras { get; set; }
    }
}
