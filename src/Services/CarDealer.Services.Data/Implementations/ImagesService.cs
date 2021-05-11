namespace CarDealer.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models.SaleModels;
    using CarDealer.Services.Mapping;
    using CarDealer.Web.ViewModels.Images;
    using Microsoft.EntityFrameworkCore;

    public class ImagesService : IImagesService
    {
        private readonly IDeletableEntityRepository<Image> imagesRepository;

        public ImagesService(IDeletableEntityRepository<Image> imagesRepository)
        {
            this.imagesRepository = imagesRepository;
        }

        public async Task<IEnumerable<ImageViewModel>> GetAllImagesBySaleId(int id)
        {
            var data = new List<ImageViewModel>();

            var imagesDb = await this.imagesRepository.All().Where(x => x.SaleId == id)
                .ToListAsync();

            foreach (var image in imagesDb)
            {
                var model = await this.GetImageViewModelById(image.Id);
                data.Add(model);
            }

            return data;
        }

        public async Task<ImageViewModel> GetImageViewModelById(string id)
        {
            return await this.imagesRepository.All().Where(x => x.Id == id).To<ImageViewModel>().FirstOrDefaultAsync();
        }
    }
}
