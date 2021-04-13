﻿namespace CarDealer.Services.Data
{
    using System.Threading.Tasks;
    using CarDealer.Data.Models;
    using CarDealer.Web.ViewModels.InputModels.Users;
    using CarDealer.Web.ViewModels.Users;

    public interface IUsersService
    {
        UserViewModel GetUserById(string id);

        Task UpdateUserInfo(string userId, UserInputModel input);

        Task DeleteUser(ApplicationUser user);
    }
}
