namespace CarDealer.Web.ViewModels.InputModels.Countries
{
    using System.Collections.Generic;
    using System.ComponentModel;

    public class SelectCountryInputModel
    {
        [DisplayName("Country")]
        public int CountryId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> CountriesItems { get; set; }
    }
}
