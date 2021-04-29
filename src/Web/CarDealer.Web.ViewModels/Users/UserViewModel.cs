namespace CarDealer.Web.ViewModels.Users
{
    using CarDealer.Data.Models;
    using CarDealer.Services.Mapping;

    public class UserViewModel : IMapFrom<ApplicationUser>
    {
        public string UserName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
