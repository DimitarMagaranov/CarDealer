namespace CarDealer.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    using CarDealer.Web.ViewModels.Cities;

    public interface ICitiesService
    {
        Task<IEnumerable<SelectListItem>> GetAllAsSelectListItemsAsync(int countryId);

        CityViewModel GetById(int id);
    }
}
