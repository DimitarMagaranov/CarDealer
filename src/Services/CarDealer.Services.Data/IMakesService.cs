namespace CarDealer.Services.Data
{
    using CarDealer.Data.Models.CarModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    public interface IMakesService
    {
        Task<IEnumerable<SelectListItem>> GetAllAsSelectListItemsAsync();

        Task<IEnumerable<Make>> GetMakeWithModelsAsync(int id);
    }
}
