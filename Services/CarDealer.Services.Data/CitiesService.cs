namespace CarDealer.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models.SaleModels;
    using Microsoft.EntityFrameworkCore;

    public class CitiesService : ICitiesService
    {
        private readonly IRepository<City> citiesRepository;

        public CitiesService(IRepository<City> citiesRepository)
        {
            this.citiesRepository = citiesRepository;
        }

        public async Task<IEnumerable<KeyValuePair<string, string>>> GetAllAsKeyValuePairs(int countryId)
        {
            var cities = await this.citiesRepository.AllAsNoTracking()
                .Where(x => x.CountryId == countryId)
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                }).ToListAsync();

            var data = cities.Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name)).ToList();

            data.Insert(0, new KeyValuePair<string, string>(null, "Select city"));

            return data;
        }
    }
}
