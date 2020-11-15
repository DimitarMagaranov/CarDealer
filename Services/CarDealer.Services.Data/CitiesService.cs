namespace CarDealer.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models.SaleModels;

    public class CitiesService : ICitiesService
    {
        private readonly IRepository<City> citiesRepository;

        public CitiesService(IRepository<City> citiesRepository)
        {
            this.citiesRepository = citiesRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs(int countryId)
        {
            var data = this.citiesRepository.AllAsNoTracking().Where(x => x.CountryId == countryId)
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name)).ToList();

            data.Insert(0, new KeyValuePair<string, string>(null, "Select city"));

            return data;
        }
    }
}
