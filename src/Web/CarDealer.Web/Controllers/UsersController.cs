namespace CarDealer.Web.Controllers
{
    using System.Threading.Tasks;
    using CarDealer.Common;
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

        public async Task<IActionResult> All(int id = 1)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            const int ItemsPerPage = 12;

            var viewModel = this.salesService.GetSalesListViewModelByUserId(id, ItemsPerPage, user.Id);

            return this.View(viewModel);
        }

        public IActionResult SaleInfo(int id)
        {
            var nameOfSalesController = nameof(SalesController).Replace(GlobalConstants.ControllerAsString, string.Empty);
            var nameOfSaleInfoActionInSalesController = nameof(SalesController.SaleInfo);

            return this.RedirectToAction(nameOfSaleInfoActionInSalesController, nameOfSalesController, new { id });
        }
    }
}
