namespace CarDealer.Web.ViewModels.InputModels.Sales
{
    using System;

    using CarDealer.Web.ViewModels.InputModels.Cars;

    public class AddSaleInputModel
    {
        public DateTime CreatedOn => DateTime.UtcNow;

        public string DaysValid { get; set; }

        public AddCarInputModel Car { get; set; }

        public decimal Price { get; set; }

        public int RegionId { get; set; }

        public string UserId { get; set; }

        public string Description { get; set; }
    }
}
