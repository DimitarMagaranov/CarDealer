namespace CarDealer.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CarDealer.Web.ViewModels.InputModels.Cars.CarMakes;

    public interface IMakesService
    {
        Task<IEnumerable<KeyValuePair<string, string>>> GetAllAsSelectListItemsAsync();

        Task<IEnumerable<MakeViewModel>> GetMakeWithModelsAsync(int id);
    }
}
