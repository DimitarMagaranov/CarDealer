namespace CarDealer.Web.Controllers
{
    using System.Threading.Tasks;

    using CarDealer.Data.Models;
    using CarDealer.Services.Data;
    using CarDealer.Web.ViewModels.InputModels.Users;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class UsersController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUsersService usersService;

        public UsersController(
            UserManager<ApplicationUser> userManager,
            IUsersService usersService)
        {
            this.userManager = userManager;
            this.usersService = usersService;
        }

        public async Task<IActionResult> UserInfo()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var userViewModel = await this.usersService.GetUserById(user.Id);

            return this.View(userViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UserInfo(UserInputModel input)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            await this.usersService.UpdateUserInfo(user.Id, input);

            var viewModel = await this.usersService.GetUserById(user.Id);

            return this.View(viewModel);
        }
    }
}
