namespace CarDealer.Web.ViewModels.InputModels.Sales
{
    using CarDealer.Data.Models.CarModels;

    public class SearchSaleFormInputModel
    {
        public string Category { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public State? State { get; set; }

        public int? ManufactureYearFrom { get; set; }

        public int? ManufactureYearTo { get; set; }

        public decimal? PriceFrom { get; set; }

        public decimal? PriceTo { get; set; }

        public string FuelType { get; set; }

        public string Gearbox { get; set; }

        public int? EngineSizeFrom { get; set; }

        public int? EngineSizeTo { get; set; }

        public int? MileageTo { get; set; }

        public string Color { get; set; }

        public string EuroStandart { get; set; }

        public string Region { get; set; }

        public string SortCommand { get; set; }
    }
}
