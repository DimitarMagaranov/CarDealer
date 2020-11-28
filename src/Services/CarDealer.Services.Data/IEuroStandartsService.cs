using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CarDealer.Services.Data
{
    public interface IEuroStandartsService
    {
        Task<IEnumerable<SelectListItem>> GetAllAsSelectListItemsAsync();
    }
}
