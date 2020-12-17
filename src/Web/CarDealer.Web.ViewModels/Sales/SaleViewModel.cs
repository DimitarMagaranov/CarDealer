namespace CarDealer.Web.ViewModels.Sales
{
    using System;

    using CarDealer.Web.ViewModels.Cars;

    public class SaleViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedOnAsString => $"{this.CreatedOn.Day}/{this.CreatedOn.Month}/{this.CreatedOn.Year}";

        public int CarId { get; set; }

        public decimal Price { get; set; }

        public string CountryName { get; set; }

        public string CityName { get; set; }

        public string UserName { get; set; }

        public string UserPhoneNumber { get; set; }

        public string UserEmailAddress { get; set; }

        public string[] ImageUrls { get; set; }

        public string Description { get; set; }

        public int OpensSaleCount { get; set; }

        public double AverageVote { get; set; }

        public CarViewModel Car { get; set; }
    }
}
