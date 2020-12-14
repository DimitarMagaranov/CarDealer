namespace CarDealer.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models.SaleModels;

    public class CountriesService : ICountriesService
    {
        private readonly IGenericsService genericsService;

        public CountriesService(
            IGenericsService genericsService)
        {
            this.genericsService = genericsService;
        }

        public async Task<IEnumerable<SelectListItem>> GetAllAsSelectListItemsAsync()
        {
            return await this.genericsService.GetAllAsSelectListItemsAsync("Countries");
        }
    }
}
