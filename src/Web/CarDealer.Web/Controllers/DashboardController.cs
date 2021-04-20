namespace CarDealer.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using CarDealer.Data.Models;
    using CarDealer.Services.Data;
    using CarDealer.Web.ViewModels.Dashboard;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class DashboardController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ISalesService salesService;

        public DashboardController(
            UserManager<ApplicationUser> userManager,
            ISalesService salesService)
        {
            this.userManager = userManager;
            this.salesService = salesService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var userSales = this.salesService.GetUserDashboardSalesByUserId(user.Id);

            var viewModel = new DashboardViewModel();
            viewModel.UserFirstName = user.FirstName;
            viewModel.UserLastName = user.LastName;
            viewModel.UserCreatedOn = user.CreatedOn;
            viewModel.Sales = userSales.ToList();

            return this.View(viewModel);
        }
    }
}
