namespace CarDealer.Web.InputModels.Countries
{
    using System.Collections.Generic;
    using System.ComponentModel;

    public class SelectCountryInputModel
    {
        [DisplayName("Country")]
        public int CountryId { get; set; }

        public string CallerMethodAsString { get; set; }

        public string CallerCotrollerName { get; set; }

        public IEnumerable<KeyValuePair<string, string>> CountriesItems { get; set; }
    }
}
