namespace CarDealer.Web.ViewModels.Sales
{
    using System;

    using AutoMapper;

    using CarDealer.Data.Models;
    using CarDealer.Services.Mapping;
    using CarDealer.Web.ViewModels.Cars;

    public class SaleViewModel : IMapFrom<Sale>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CarId { get; set; }

        public decimal Price { get; set; }

        public string CountryName { get; set; }

        public string CityName { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public string UserPhoneNumber { get; set; }

        public string UserEmail { get; set; }

        public string[] OriginalImageUrls { get; set; }

        public string[] ResizedImageUrls { get; set; }

        public string Description { get; set; }

        public int OpensSaleCounter { get; set; }

        public CarViewModel Car { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Sale, SaleViewModel>()
                .ForMember(x => x.UserName, options =>
                options.MapFrom(x => x.User.UserName));
        }
    }
}
