namespace CarDealer.Web.ViewModels.InputModels.Sales
{
    using System.Collections.Generic;
    using CarDealer.Web.ViewModels.InputModels.Cars;
    using Microsoft.AspNetCore.Http;

    public class AddSaleInputModel : BaseSaleInputModel
    {
        public AddCarInputModel Car { get; set; }

        public IEnumerable<IFormFile> Images { get; set; }
    }
}
