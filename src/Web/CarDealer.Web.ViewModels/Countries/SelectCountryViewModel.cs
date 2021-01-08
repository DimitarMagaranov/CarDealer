namespace CarDealer.Web.ViewModels.Countries
{
    using System.Collections.Generic;
    using System.ComponentModel;

    public class SelectCountryViewModel
    {
        [DisplayName("Country")]
        public int CountryId { get; set; }

        public string CallerMethodAsString { get; set; }

        public string CallerCotrollerName { get; set; }

        public IEnumerable<KeyValuePair<string, string>> CountriesItems { get; set; }
    }
}
