namespace CarDealer.Services.Data
{
    using System.Collections.Generic;

    using CarDealer.Web.ViewModels.Images;

    public interface IImagesService
    {
        IEnumerable<ImageViewModel> GetAllImagesBySaleId(int id);

        ImageViewModel GetImageViewModelById(string id);
    }
}
