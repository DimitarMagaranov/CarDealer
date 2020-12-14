namespace CarDealer.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Linq;

    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models.SaleModels;
    using CarDealer.Web.ViewModels.Images;

    public class ImagesService : IImagesService
    {
        private readonly IDeletableEntityRepository<Image> imagesRepository;

        public ImagesService(IDeletableEntityRepository<Image> imagesRepository)
        {
            this.imagesRepository = imagesRepository;
        }

        public IEnumerable<ImageViewModel> GetAllImagesBySaleId(int id)
        {
            var data = new List<ImageViewModel>();

            var imagesDb = this.imagesRepository.AllAsNoTracking().Where(x => x.SaleId == id);

            foreach (var image in imagesDb)
            {
                data.Add(new ImageViewModel
                {
                    Id = image.Id,
                    SaleId = image.SaleId,
                    AddedByUserId = image.AddedByUserId,
                    Extension = image.Extension,
                    ImageUrl = image.ImageUrl,
                });
            }

            return data;
        }
    }
}
