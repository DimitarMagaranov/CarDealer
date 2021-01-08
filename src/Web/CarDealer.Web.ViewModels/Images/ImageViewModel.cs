namespace CarDealer.Web.ViewModels.Images
{
    public class ImageViewModel
    {
        public string Id { get; set; }

        public string AddedByUserId { get; set; }

        public int SaleId { get; set; }

        public string OriginalImageUrl { get; set; }

        public string ResizedlImageUrl { get; set; }

        public string Extension { get; set; }
    }
}
