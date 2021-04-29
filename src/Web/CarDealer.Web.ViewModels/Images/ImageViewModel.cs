namespace CarDealer.Web.ViewModels.Images
{
    using CarDealer.Data.Models.SaleModels;
    using CarDealer.Services.Mapping;

    public class ImageViewModel : IMapFrom<Image>
    {
        public string Id { get; set; }

        public string AddedByUserId { get; set; }

        public int SaleId { get; set; }

        public string ImageUrl { get; set; }

        public string ResizedImageUrl { get; set; }

        public string Extension { get; set; }
    }
}
