using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarDealer.Web.Controllers
{
    public class AboutUsController : BaseController
    {
        public async Task<IActionResult> Index()
        {
            return this.View();
        }
    }
}
