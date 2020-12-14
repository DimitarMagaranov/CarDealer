namespace CarDealer.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models.SaleModels;
    using CarDealer.Web.ViewModels.Cities;
    using Microsoft.EntityFrameworkCore;

    public class CitiesService : ICitiesService
    {
        private readonly IRepository<City> citiesRepository;

        public CitiesService(IRepository<City> citiesRepository)
        {
            this.citiesRepository = citiesRepository;
        }

        public CityViewModel GetById(int id)
        {
            var city = this.citiesRepository.AllAsNoTracking().First(x => x.Id == id);

            return new CityViewModel { Id = city.Id, Name = city.Name };
        }

        public async Task<IEnumerable<SelectListItem>> GetAllAsSelectListItemsAsync(int countryId)
        {
            List<SelectListItem> cities = new List<SelectListItem>();

            cities = await this.citiesRepository.AllAsNoTracking()
                .Where(x => x.CountryId == countryId)
                .Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() })
                .OrderBy(x => x.Text)
                .ToListAsync();

            cities.Insert(0, new SelectListItem() { Text = "Select city", Value = null });

            return cities;
        }
    }
}
