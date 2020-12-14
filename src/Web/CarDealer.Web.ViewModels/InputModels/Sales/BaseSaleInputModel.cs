﻿namespace CarDealer.Web.ViewModels.InputModels.Sales
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public abstract class BaseSaleInputModel
    {
        [DisplayName("Duration in days")]
        [Range(10, 60, ErrorMessage = "The days of duration must be atleast 10.")]
        public int DaysValid { get; set; }

        [DisplayName("Price")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [DisplayName("Country")]
        public int CountryId { get; set; }

        [DisplayName("City")]
        public int CityId { get; set; }

        public string UserId { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public IEnumerable<SelectListItem> CountriesItems { get; set; }

        public IEnumerable<SelectListItem> CitiesItems { get; set; }
    }
}
