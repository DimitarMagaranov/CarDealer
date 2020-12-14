namespace CarDealer.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    using CarDealer.Web.ViewModels.InputModels.Cars.CarMakes;

    public interface IMakesService
    {
        Task<IEnumerable<SelectListItem>> GetAllAsSelectListItemsAsync();

        Task<IEnumerable<MakeViewModel>> GetMakeWithModelsAsync(int id);
    }
}
