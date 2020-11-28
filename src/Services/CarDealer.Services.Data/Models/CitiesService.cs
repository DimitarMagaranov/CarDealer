namespace CarDealer.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;

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
