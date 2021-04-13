namespace CarDealer.Services.Data.Implementations
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using CarDealer.Data;
    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models;
    using CarDealer.Web.ViewModels.InputModels.Users;
    using CarDealer.Web.ViewModels.Users;
    using Microsoft.AspNetCore.Identity;

    public class UsersService : IUsersService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext context;

        public UsersService(
            IDeletableEntityRepository<ApplicationUser> usersRepository,
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext context)
        {
            this.usersRepository = usersRepository;
            this.userManager = userManager;
            this.context = context;
        }

        public async Task DeleteUser(ApplicationUser user)
        {
            //var logins = user.Logins;

            ////Gets list of Roles associated with current user
            //var rolesForUser = await this.userManager.GetRolesAsync(user);

            //using (var transaction = this.context.Database.BeginTransaction())
            //{
            //    foreach (var login in logins.ToList())
            //    {
            //        await this.userManager.RemoveLoginAsync(user, login.LoginProvider, login.ProviderKey);
            //    }

            //    if (rolesForUser.Count() > 0)
            //    {
            //        foreach (var item in rolesForUser.ToList())
            //        {
            //            // item should be the name of the role
            //            var result = await this.userManager.RemoveFromRoleAsync(user, "User");
            //        }
            //    }

            //    //Delete User
            //    await this.userManager.DeleteAsync(user);
            //}

            this.usersRepository.Delete(user);
        }

        public UserViewModel GetUserById(string id)
        {
            var user = this.usersRepository.AllAsNoTracking().First(x => x.Id == id);

            return new UserViewModel
            {
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
            };
        }

        public async Task UpdateUserInfo(string userId, UserInputModel input)
        {
            var user = this.usersRepository.All().FirstOrDefault(x => x.Id == userId);
            user.UserName = input.UserName;
            user.NormalizedUserName = input.UserName.ToUpper();
            user.FirstName = input.FirstName;
            user.LastName = input.LastName;
            user.PhoneNumber = input.PhoneNumber;
            user.Email = input.Email;

            await this.usersRepository.SaveChangesAsync();
        }
    }
}
