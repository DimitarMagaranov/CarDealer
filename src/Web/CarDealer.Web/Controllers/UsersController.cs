namespace CarDealer.Web.Controllers
{
    using System.Threading.Tasks;
    using CarDealer.Common;
    using CarDealer.Data.Models;
    using CarDealer.Services.Data;
    using CarDealer.Web.ViewModels.InputModels.Users;
    using CarDealer.Web.ViewModels.Sales;
    using CarDealer.Web.ViewModels.Users;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class UsersController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ISalesService salesService;
        private readonly IUsersService usersService;

        public UsersController(
            UserManager<ApplicationUser> userManager,
            ISalesService salesService,
            IUsersService usersService)
        {
            this.userManager = userManager;
            this.salesService = salesService;
            this.usersService = usersService;
        }

        public async Task<IActionResult> UserInfo()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var userViewModel = this.usersService.GetUserById(user.Id);

            return this.View(userViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UserInfo(UserInputModel input)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            await this.usersService.UpdateUserInfo(user.Id, input);

            var viewModel = this.usersService.GetUserById(user.Id);

            return this.View(viewModel);
        }

        public async Task<ActionResult> DeleteUser()
        {
            var user = await this.userManager.GetUserAsync(this.User);

            await this.usersService.DeleteUser(user);

            return this.RedirectToAction("Index", "Home");
        }
    }
}
