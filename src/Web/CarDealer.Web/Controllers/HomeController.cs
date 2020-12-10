namespace CarDealer.Web.Controllers
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;

    using CarDealer.Data.Models;
    using CarDealer.Services.Data;
    using CarDealer.Web.ViewModels;
    using CarDealer.Web.ViewModels.Sales;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly ISalesService salesService;
        private readonly UserManager<ApplicationUser> userManager;

        public HomeController(
            ISalesService salesService,
            UserManager<ApplicationUser> userManager)
        {
            this.salesService = salesService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<SaleViewModel> salesViewModel;

            if (this.User.Identity.IsAuthenticated)
            {
                var user = await this.userManager.GetUserAsync(this.User);

                salesViewModel = this.salesService.GetTopNineCarsInUsersCountry(user.CountryId);

                return this.View(salesViewModel);
            }

            salesViewModel = this.salesService.GetTopNineCarsFromEnywhere();

            return this.View(salesViewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
