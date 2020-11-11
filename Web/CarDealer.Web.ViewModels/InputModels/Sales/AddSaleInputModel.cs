namespace CarDealer.Web.ViewModels.InputModels.Sales
{
    using System.Collections.Generic;

    using CarDealer.Web.ViewModels.InputModels.Cars;

    public class AddSaleInputModel
    {
        public string DaysValid { get; set; }

        public AddCarInputModel Car { get; set; }

        public decimal Price { get; set; }

        public int RegionId { get; set; }

        public string UserId { get; set; }

        public string Description { get; set; }

        public IEnumerable<KeyValuePair<string, string>> RegionsItems { get; set; }
    }
}
