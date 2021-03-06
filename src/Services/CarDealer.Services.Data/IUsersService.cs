﻿namespace CarDealer.Services.Data
{
    using System.Threading.Tasks;

    using CarDealer.Web.ViewModels.InputModels.Users;
    using CarDealer.Web.ViewModels.Users;

    public interface IUsersService
    {
        Task<UserViewModel> GetUserById(string id);

        Task<UserViewModel> UpdateUserInfo(string userId, UserInputModel input);
    }
}
