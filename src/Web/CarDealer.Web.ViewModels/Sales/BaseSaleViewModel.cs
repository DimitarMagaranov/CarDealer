namespace CarDealer.Web.ViewModels.Sales
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public abstract class BaseSaleViewModel
    {
        [DisplayName("Duration in days (minimum 10) *")]
        [Range(10, 60, ErrorMessage = "The days of duration must be atleast 10.")]
        public int DaysValid { get; set; }

        [DisplayName("Price *")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [DisplayName("Country *")]
        public int CountryId { get; set; }

        [DisplayName("City *")]
        public int CityId { get; set; }

        public string UserId { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public IEnumerable<KeyValuePair<string, string>> CountriesItems { get; set; }

        public IEnumerable<KeyValuePair<string, string>> CitiesItems { get; set; }
    }
}
