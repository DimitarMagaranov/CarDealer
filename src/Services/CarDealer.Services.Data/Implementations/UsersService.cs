﻿namespace CarDealer.Services.Data.Implementations
{
    using System.Linq;
    using System.Threading.Tasks;

    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models;
    using CarDealer.Services.Mapping;
    using CarDealer.Web.ViewModels.InputModels.Users;
    using CarDealer.Web.ViewModels.Users;

    public class UsersService : IUsersService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;

        public UsersService(
            IDeletableEntityRepository<ApplicationUser> usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public UserViewModel GetUserById(string id)
        {
            return this.usersRepository.All().Where(x => x.Id == id).To<UserViewModel>().FirstOrDefault();
        }

        public async Task<UserViewModel> UpdateUserInfo(string userId, UserInputModel input)
        {
            var user = this.usersRepository.All().FirstOrDefault(x => x.Id == userId);
            user.UserName = input.UserName;
            user.NormalizedUserName = input.UserName.ToUpper();
            user.FirstName = input.FirstName;
            user.LastName = input.LastName;
            user.PhoneNumber = input.PhoneNumber;
            user.Email = input.Email;

            await this.usersRepository.SaveChangesAsync();

            return this.GetUserById(userId);
        }
    }
}
