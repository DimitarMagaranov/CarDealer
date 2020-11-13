namespace CarDealer.Web.ViewModels.Sales
{
    using System;
    using System.Globalization;

    using CarDealer.Web.ViewModels.Cars;

    public class SaleViewModel
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedOnAsString => this.CreatedOn.ToString(CultureInfo.GetCultureInfo("bg-BG"));

        public int CarId { get; set; }

        public decimal Price { get; set; }

        public string Country { get; set; }

        public string UserName { get; set; }

        public string UserPhoneNumber { get; set; }

        public string Description { get; set; }

        public CarViewModel Car { get; set; }
    }
}
