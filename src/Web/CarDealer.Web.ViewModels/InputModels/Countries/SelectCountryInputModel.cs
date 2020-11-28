namespace CarDealer.Web.ViewModels.InputModels.Countries
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Web.Mvc;

    public class SelectCountryInputModel
    {
        [DisplayName("Country")]
        public int CountryId { get; set; }

        public IEnumerable<SelectListItem> CountriesItems { get; set; }
    }
}
