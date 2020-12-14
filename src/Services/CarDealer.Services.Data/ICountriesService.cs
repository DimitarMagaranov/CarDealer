namespace CarDealer.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    public interface ICountriesService
    {
        Task<IEnumerable<SelectListItem>> GetAllAsSelectListItemsAsync();
    }
}
