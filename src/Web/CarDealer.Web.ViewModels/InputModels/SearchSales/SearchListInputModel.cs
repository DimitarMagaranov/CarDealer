namespace CarDealer.Web.ViewModels.InputModels.SearchSales
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Web.Mvc;

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

        [DisplayName("Make:")]
        public int? MakeId { get; set; }

        [DisplayName("Model")]
        public int? ModelId { get; set; }

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

        public IEnumerable<SelectListItem> CategoriesItems { get; set; }

        public IEnumerable<SelectListItem> MakesItems { get; set; }

        public IEnumerable<SelectListItem> ModelstItems { get; set; }

        public IEnumerable<SelectListItem> FuelTypeItems { get; set; }

        public IEnumerable<SelectListItem> EuroStandartItems { get; set; }

        public IEnumerable<SelectListItem> GearboxesItems { get; set; }

        public IEnumerable<SelectListItem> ColorstItems { get; set; }

        public IEnumerable<SelectListItem> CitiesItems { get; set; }
    }
}
