namespace CarDealer.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models.CarModels;
    using Microsoft.EntityFrameworkCore;

    public class ModelsService : IModelsService
    {
        private readonly IRepository<Model> modelsRepository;

        public ModelsService(IRepository<Model> modelsRepository)
        {
            this.modelsRepository = modelsRepository;
        }

        public async Task<IEnumerable<SelectListItem>> GetAllAsSelectListItemsAsync()
        {
            List<SelectListItem> models = new List<SelectListItem>();

            models = await this.modelsRepository.AllAsNoTracking()
                .Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToListAsync();

            models.Insert(0, new SelectListItem() { Text = "Select model", Value = null });

            return models;
        }
    }
}
