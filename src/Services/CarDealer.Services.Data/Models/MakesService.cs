namespace CarDealer.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models.CarModels;
    using Microsoft.EntityFrameworkCore;

    public class MakesService : IMakesService
    {
        private readonly IRepository<Make> makesRepository;

        public MakesService(IRepository<Make> makesRepository)
        {
            this.makesRepository = makesRepository;
        }

        public async Task<IEnumerable<Make>> GetMakeWithModelsAsync(int id)
        {
            return await this.makesRepository.All()
                .Where(x => x.Id == id)
                .Include(x => x.Models)
                .ToListAsync();
        }

        public async Task<IEnumerable<SelectListItem>> GetAllAsSelectListItemsAsync()
        {
            List<SelectListItem> makes = new List<SelectListItem>();

            makes = await this.makesRepository.AllAsNoTracking()
                .Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToListAsync();

            makes.Insert(0, new SelectListItem() { Text = "Select brand", Value = null });

            return makes;
        }
    }
}
