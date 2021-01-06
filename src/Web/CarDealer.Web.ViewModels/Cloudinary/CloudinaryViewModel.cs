namespace CarDealer.Web.ViewModels.Cloudinary
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Http;

    public class CloudinaryViewModel
    {
        public ICollection<IFormFile> Images { get; set; }
    }
}
