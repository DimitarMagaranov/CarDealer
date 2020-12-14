namespace CarDealer.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    public class FuelTypesService : IFuelTypesService
    {
        private readonly IGenericsService genericsService;

        public FuelTypesService(IGenericsService genericsService)
        {
            this.genericsService = genericsService;
        }

        public async Task<IEnumerable<SelectListItem>> GetAllAsSelectListItemsAsync()
        {
            return await this.genericsService.GetAllAsSelectListItemsAsync("FuelTypes");
        }
    }
}
