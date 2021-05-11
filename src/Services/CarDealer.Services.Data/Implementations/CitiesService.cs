namespace CarDealer.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models;
    using CarDealer.Data.Models.SaleModels;

    using Microsoft.EntityFrameworkCore;

    public class CitiesService : ICitiesService
    {
        private readonly IRepository<City> citiesRepository;
        private readonly IDeletableEntityRepository<Sale> salesRepository;

        public CitiesService(
            IRepository<City> citiesRepository,
            IDeletableEntityRepository<Sale> salesRepository)
        {
            this.citiesRepository = citiesRepository;
            this.salesRepository = salesRepository;
        }

        public async Task<string> GetCityNameBySaleId(int id)
        {
            var sale = await this.salesRepository.AllAsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            var city = await this.citiesRepository.AllAsNoTracking().FirstOrDefaultAsync(x => x.Id == sale.CityId);

            return city.Name;
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
