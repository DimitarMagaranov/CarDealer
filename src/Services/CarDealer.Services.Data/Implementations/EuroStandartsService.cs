namespace CarDealer.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    public class EuroStandartsService : IEuroStandartsService
    {
        private readonly IGenericsService genericsService;

        public EuroStandartsService(IGenericsService genericsService)
        {
            this.genericsService = genericsService;
        }

        public async Task<IEnumerable<SelectListItem>> GetAllAsSelectListItemsAsync()
        {
            return await this.genericsService.GetAllAsSelectListItemsAsync("EuroStandarts");
        }
    }
}
