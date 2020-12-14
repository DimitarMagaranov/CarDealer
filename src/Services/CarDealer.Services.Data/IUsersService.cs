namespace CarDealer.Services.Data
{
    using CarDealer.Web.ViewModels.Users;

    public interface IUsersService
    {
        UserViewModel GetUserById(string id);
    }
}
