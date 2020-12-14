using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CarDealer.Services.Data
{
    public interface IGenericsService
    {
        Task<IEnumerable<SelectListItem>> GetAllAsSelectListItemsAsync(string strFullyQualifiedName);
    }
}
