namespace CarDealer.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

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

        public async Task<IEnumerable<KeyValuePair<string, string>>> GetAllAsKeyValuePairsAsync(int countryId)
        {
            var cities = new List<KeyValuePair<string, string>>();

            cities = await this.citiesRepository.AllAsNoTracking()
                .Where(x => x.CountryId == countryId)
                .OrderBy(x => x.Name)
                .Select(x => new KeyValuePair<string, string>(x.Name, x.Id.ToString()))
                .ToListAsync();

            cities.Insert(0, new KeyValuePair<string, string>("Select city", null));

            return cities;
        }
    }
}
