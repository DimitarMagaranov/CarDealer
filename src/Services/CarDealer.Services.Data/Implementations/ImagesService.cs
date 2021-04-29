namespace CarDealer.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Linq;

    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models.SaleModels;
    using CarDealer.Services.Mapping;
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

            this.imagesRepository.AllAsNoTracking().Where(x => x.SaleId == id)
                .ToList()
                .ForEach(x => data.Add(this.GetImageViewModelById(x.Id)));

            return data;
        }

        public ImageViewModel GetImageViewModelById(string id)
        {
            return this.imagesRepository.All().Where(x => x.Id == id).To<ImageViewModel>().FirstOrDefault();
        }
    }
}
