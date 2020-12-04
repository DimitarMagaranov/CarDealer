namespace CarDealer.Web.Controllers
{
    using System.Threading.Tasks;

    using CarDealer.Data.Models;
    using CarDealer.Services.Data;
    using CarDealer.Web.ViewModels.Sales;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class UsersController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ISalesService salesService;

        public UsersController(UserManager<ApplicationUser> userManager, ISalesService salesService)
        {
            this.userManager = userManager;
            this.salesService = salesService;
        }

        public async Task<IActionResult> All(int id)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            const int ItemsPerPage = 2;

            if (id == 0)
            {
                id++;
            }

            var salesListViewModel = new SalesListViewModel();

            salesListViewModel.PageNumber = id;

            salesListViewModel.ItemsPerPage = ItemsPerPage;

            salesListViewModel.Sales = this.salesService.GetAllByUserId(id, ItemsPerPage, user.Id);
            salesListViewModel.SalesCount = this.salesService.GetSalesCountByUserId(user.Id);

            return this.View(salesListViewModel);
        }

        public IActionResult SaleInfo(int id)
        {
            return this.RedirectToAction("SaleInfo", "Sales", new { id });
        }
    }
}
