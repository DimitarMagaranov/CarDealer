namespace CarDealer.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models.CarModels;
    using Microsoft.EntityFrameworkCore;

    public class EuroStandartsService : IEuroStandartsService
    {
        private readonly IRepository<EuroStandart> euroStandartsRepository;

        public EuroStandartsService(IRepository<EuroStandart> euroStandartsRepository)
        {
            this.euroStandartsRepository = euroStandartsRepository;
        }

        public async Task<IEnumerable<SelectListItem>> GetAllAsSelectListItemsAsync()
        {
            List<SelectListItem> euroStandarts = new List<SelectListItem>();

            euroStandarts = await this.euroStandartsRepository.AllAsNoTracking()
                .Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToListAsync();

            euroStandarts.Insert(0, new SelectListItem() { Text = "Select euro standart", Value = null });

            return euroStandarts;
        }
    }
}
