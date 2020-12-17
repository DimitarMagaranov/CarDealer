namespace CarDealer.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models.SaleModels;
    using Microsoft.EntityFrameworkCore;

    public class CountriesService : ICountriesService
    {
        private readonly IRepository<Country> countriesRepository;

        public CountriesService(
            IRepository<Country> countriesRepository)
        {
            this.countriesRepository = countriesRepository;
        }

        public async Task<IEnumerable<KeyValuePair<string, string>>> GetAllAsSelectListItemsAsync()
        {
            var countries = new List<KeyValuePair<string, string>>();

            countries = await this.countriesRepository.AllAsNoTracking()
                .OrderBy(x => x.Name)
                .Select(x => new KeyValuePair<string, string>(x.Name, x.Id.ToString()))
                .ToListAsync();

            countries.Insert(0, new KeyValuePair<string, string>("Select country", null));

            return countries;
        }
    }
}
