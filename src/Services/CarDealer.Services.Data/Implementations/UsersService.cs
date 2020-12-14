namespace CarDealer.Services.Data.Implementations
{
    using System.Linq;

    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models;
    using CarDealer.Web.ViewModels.Users;

    public class UsersService : IUsersService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;

        public UsersService(IDeletableEntityRepository<ApplicationUser> usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public UserViewModel GetUserById(string id)
        {
            var user = this.usersRepository.AllAsNoTracking().First(x => x.Id == id);

            return new UserViewModel
            {
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
            };
        }
    }
}
