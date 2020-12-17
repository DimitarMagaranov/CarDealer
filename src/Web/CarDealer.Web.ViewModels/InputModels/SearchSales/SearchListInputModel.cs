namespace CarDealer.Web.ViewModels.InputModels.SearchSales
{
    using System.Collections.Generic;
    using System.ComponentModel;

    using CarDealer.Data.Models.CarModels;

    public class SearchListInputModel
    {
        // TODO: TEMPDATA
        public int CountryId { get; set; }

        [DisplayName("City:")]
        public int? CityId { get; set; }

        [DisplayName("Used/New:")]
        public State? State { get; set; }

        [DisplayName("Category:")]
        public int? CategoryId { get; set; }

        [DisplayName("Brand:")]
        public int? MakeId { get; set; }

        [DisplayName("Model")]
        public int? ModelId { get; set; }

        [DisplayName("Year from:")]
        public int? ManufacturerYearFrom { get; set; }

        [DisplayName("Year to:")]
        public int? ManufacturerYearTo { get; set; }

        [DisplayName("Price from:")]
        public int? PriceFrom { get; set; }

        [DisplayName("Price to:")]
        public int? PriceTo { get; set; }

        [DisplayName("Milleage from:")]
        public int? MilleageFrom { get; set; }

        [DisplayName("Milleage to:")]
        public int? MilleageTo { get; set; }

        [DisplayName("Engine size from:")]
        public int? EngineSizeFrom { get; set; }

        [DisplayName("Engine size to:")]
        public int? EngineSizeTo { get; set; }

        [DisplayName("Power from:")]
        public int? PowerFrom { get; set; }

        [DisplayName("Power to:")]
        public int? PowerTo { get; set; }

        [DisplayName("Fuel:")]
        public int? FuelTypeId { get; set; }

        [DisplayName("Gearbox:")]
        public int? GearboxId { get; set; }

        [DisplayName("Doors:")]
        public Doors? Doors { get; set; }

        [DisplayName("Number of seats:")]
        public Seats? Seats { get; set; }

        public IEnumerable<KeyValuePair<string, string>> CategoriesItems { get; set; }

        public IEnumerable<KeyValuePair<string, string>> MakesItems { get; set; }

        public IEnumerable<KeyValuePair<string, string>> ModelstItems { get; set; }

        public IEnumerable<KeyValuePair<string, string>> FuelTypeItems { get; set; }

        public IEnumerable<KeyValuePair<string, string>> EuroStandartItems { get; set; }

        public IEnumerable<KeyValuePair<string, string>> GearboxesItems { get; set; }

        public IEnumerable<KeyValuePair<string, string>> ColorstItems { get; set; }

        public IEnumerable<KeyValuePair<string, string>> CitiesItems { get; set; }

        public IEnumerable<KeyValuePair<string, string>> CountriesItems { get; set; }
    }
}
