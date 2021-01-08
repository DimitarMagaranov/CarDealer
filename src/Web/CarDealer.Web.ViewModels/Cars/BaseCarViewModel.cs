namespace CarDealer.Web.ViewModels.Cars
{
    using CarDealer.Data.Models.CarModels;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public abstract class BaseCarViewModel
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

        public IEnumerable<KeyValuePair<string, string>> CategoriesItems { get; set; }

        public IEnumerable<KeyValuePair<string, string>> MakesItems { get; set; }

        public IEnumerable<KeyValuePair<string, string>> ModelstItems { get; set; }

        public IEnumerable<KeyValuePair<string, string>> FuelTypeItems { get; set; }

        public IEnumerable<KeyValuePair<string, string>> EuroStandartItems { get; set; }

        public IEnumerable<KeyValuePair<string, string>> GearboxesItems { get; set; }

        public IEnumerable<KeyValuePair<string, string>> ColorstItems { get; set; }
    }
}
