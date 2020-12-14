namespace CarDealer.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    public class GearboxesService : IGearboxesService
    {
        private readonly IGenericsService genericsService;

        public GearboxesService(IGenericsService genericsService)
        {
            this.genericsService = genericsService;
        }

        public async Task<IEnumerable<SelectListItem>> GetAllAsSelectListItemsAsync()
        {
            return await this.genericsService.GetAllAsSelectListItemsAsync("Gearboxes");
        }
    }
}
