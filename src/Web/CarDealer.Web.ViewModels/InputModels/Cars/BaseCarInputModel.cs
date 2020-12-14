﻿namespace CarDealer.Web.ViewModels.InputModels.Cars
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using CarDealer.Data.Models.CarModels;

    public abstract class BaseCarInputModel
    {
        [DisplayName("Brand")]
        public int MakeId { get; set; }

        [DisplayName("Model")]
        public int ModelId { get; set; }

        [DisplayName("Category")]
        public int CategoryId { get; set; }

        [DisplayName("Fuel type")]
        public int FuelTypeId { get; set; }

        [DisplayName("Engine size")]
        public int EngineSize { get; set; }

        [DisplayName("Horse power")]
        public int HorsePower { get; set; }

        [DisplayName("Euro standart")]
        public int EuroStandartId { get; set; }

        [DisplayName("Gearbox type")]
        public int GearboxId { get; set; }

        [DisplayName("Color")]
        public int ColorId { get; set; }

        [DisplayName("Doors count")]
        public Doors Doors { get; set; }

        [DisplayName("Seats count")]
        public Seats Seats { get; set; }

        public State State { get; set; }

        public int Mileage { get; set; }

        [DisplayName("Manufacture date")]
        [DataType(DataType.Date)]
        public DateTime ManufactureDate { get; set; }

        public IEnumerable<SelectListItem> CategoriesItems { get; set; }

        public IEnumerable<SelectListItem> MakesItems { get; set; }

        public IEnumerable<SelectListItem> ModelstItems { get; set; }

        public IEnumerable<SelectListItem> FuelTypeItems { get; set; }

        public IEnumerable<SelectListItem> EuroStandartItems { get; set; }

        public IEnumerable<SelectListItem> GearboxesItems { get; set; }

        public IEnumerable<SelectListItem> ColorstItems { get; set; }
    }
}
