namespace CarDealer.Web.ViewModels.InputModels.Sales
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using CarDealer.Web.ViewModels.InputModels.Cars;
    using Microsoft.AspNetCore.Http;

    public class AddSaleInputModel : BaseSaleInputModel
    {
        public AddCarInputModel Car { get; set; }

        [DisplayName("Images *")]
        [Required(ErrorMessage = "The images must be atleast 1.")]
        public IEnumerable<IFormFile> Images { get; set; }

        [Required(ErrorMessage = "The brand field is required.")]
        public int MakeId { get; set; }

        [Required(ErrorMessage = "The model field is required.")]
        public int ModelId { get; set; }

        public IEnumerable<int> CarExtras { get; set; }
    }
}
