namespace CarDealer.Web.ViewModels.InputModels.Cars
{
    using System;
    using System.Collections.Generic;

    public class AddCarInputModel
    {
        public int MakeId { get; set; }

        public int CategoryId { get; set; }

        public int FuelTypeId { get; set; }

        public int EngineSize { get; set; }

        public int EuroStandartId { get; set; }

        public int GearboxId { get; set; }

        public int ColorId { get; set; }

        public string Doors { get; set; }

        public string State { get; set; }

        public int Mileage { get; set; }

        public DateTime ManufactureDate { get; set; }

        public IEnumerable<KeyValuePair<string, string>> CategoriesItems { get; set; }

        public IEnumerable<KeyValuePair<string, string>> MakesItems { get; set; }

        public IEnumerable<KeyValuePair<string, string>> FuelTypeItems { get; set; }

        public IEnumerable<KeyValuePair<string, string>> EuroStandartItems { get; set; }

        public IEnumerable<KeyValuePair<string, string>> GearboxesItems { get; set; }

        public IEnumerable<KeyValuePair<string, string>> ColorstItems { get; set; }
    }
}
