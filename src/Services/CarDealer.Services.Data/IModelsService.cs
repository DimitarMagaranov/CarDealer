namespace CarDealer.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    using CarDealer.Web.ViewModels.InputModels.Cars.CarModels;

    public interface IModelsService
    {
        ModelViewModel GetById(int id);

        Task<IEnumerable<SelectListItem>> GetAllAsSelectListItemsAsync();
    }
}
