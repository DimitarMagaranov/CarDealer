namespace CarDealer.Services.Data
{
    using CarDealer.Data.Models.SaleModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    public interface ICountriesService
    {
        Task<IEnumerable<SelectListItem>> GetAllAsSelectListItemsAsync();

        List<Country> GetAll();
    }
}
