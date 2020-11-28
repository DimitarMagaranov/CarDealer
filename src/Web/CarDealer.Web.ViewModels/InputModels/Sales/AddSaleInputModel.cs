namespace CarDealer.Web.ViewModels.InputModels.Sales
{
    using CarDealer.Web.ViewModels.InputModels.Cars;
    using Microsoft.AspNetCore.Http;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class AddSaleInputModel
    {
        [Range(10, 60)]
        [DisplayName("Duration in days")]
        public int DaysValid { get; set; }

        public AddCarInputModel Car { get; set; }

        public decimal Price { get; set; }

        [DisplayName("Country")]
        public int CountryId { get; set; }

        [DisplayName("City")]
        public int CityId { get; set; }

        public string UserId { get; set; }

        public IEnumerable<IFormFile> Images { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public IEnumerable<SelectListItem> CountriesItems { get; set; }

        public IEnumerable<SelectListItem> CitiesItems { get; set; }
    }
}
