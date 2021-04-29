namespace CarDealer.Services.Data.Implementations
{
    using System.Linq;
    using System.Threading.Tasks;

    using CarDealer.Data;
    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models;
    using CarDealer.Web.ViewModels.InputModels.Users;
    using CarDealer.Web.ViewModels.Users;
    using CarDealer.Services.Mapping;
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

        public UserViewModel GetUserById(string id)
        {
            return this.usersRepository.AllAsNoTracking().Where(x => x.Id == id).To<UserViewModel>().FirstOrDefault();
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
