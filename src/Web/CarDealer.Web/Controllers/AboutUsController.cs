namespace CarDealer.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class AboutUsController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
