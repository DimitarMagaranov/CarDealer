namespace CarDealer.Web.Controllers
{
    using CarDealer.Web.ViewModels.InputModels.SearchSales;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class SearchSalesController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult List(SearchListInputModel input)
        {
            return this.View();
        }
    }
}
