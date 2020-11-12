namespace CarDealer.Web.ViewModels.InputModels.Sales
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using CarDealer.Data.Models.SaleModels;
    using CarDealer.Web.ViewModels.InputModels.Cars;

    public class AddSaleInputModel
    {
        [DisplayName("Duration in days")]
        public DaysValid DaysValid { get; set; }

        public AddCarInputModel Car { get; set; }

        public decimal Price { get; set; }

        [DisplayName("Region")]
        public int RegionId { get; set; }

        public string UserId { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public IEnumerable<KeyValuePair<string, string>> RegionsItems { get; set; }
    }
}
