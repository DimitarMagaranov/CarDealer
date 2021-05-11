namespace CarDealer.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CarDealer.Web.ViewModels.Images;

    public interface IImagesService
    {
        Task<IEnumerable<ImageViewModel>> GetAllImagesBySaleId(int id);

        Task<ImageViewModel> GetImageViewModelById(string id);
    }
}
