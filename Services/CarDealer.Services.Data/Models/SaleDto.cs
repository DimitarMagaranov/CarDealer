namespace CarDealer.Services.Data.Models
{
    using System;
    using System.Globalization;

    public class SaleDto
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedOnAsString => this.CreatedOn.ToString(CultureInfo.InvariantCulture);

        public int CarId { get; set; }

        public decimal Price { get; set; }

        public string Country { get; set; }

        public string UserName { get; set; }

        public string UserPhoneNumber { get; set; }

        public string Description { get; set; }

        public CarDto Car { get; set; }
    }
}
