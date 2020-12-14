namespace CarDealer.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    public class ColorsService : IColorsService
    {
        private readonly IGenericsService genericsService;

        public ColorsService(IGenericsService genericsService)
        {
            this.genericsService = genericsService;
        }

        public async Task<IEnumerable<SelectListItem>> GetAllAsSelectListItemsAsync()
        {
            return await this.genericsService.GetAllAsSelectListItemsAsync("Colors");
        }
    }
}
