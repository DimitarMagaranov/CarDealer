namespace CarDealer.Web.ViewModels.InputModels.Sales
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using CarDealer.Data.Models.SaleModels;
    using CarDealer.Web.ViewModels.InputModels.Cars;

    public class AddSaleInputModel
    {
        [Range(10, 60)]
        [DisplayName("Duration in days")]
        public int DaysValid { get; set; }

        public AddCarInputModel Car { get; set; }

        public decimal Price { get; set; }

        [DisplayName("Country")]
        public int CountryId { get; set; }

        public string UserId { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public IEnumerable<KeyValuePair<string, string>> CountriesItems { get; set; }
    }
}
