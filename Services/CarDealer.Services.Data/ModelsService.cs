namespace CarDealer.Services.Data
{
    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models.CarModels;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ModelsService : IModelsService
    {
        private readonly IRepository<Model> modelsRepository;

        public ModelsService(IRepository<Model> modelsRepository)
        {
            this.modelsRepository = modelsRepository;
        }

        public async Task<IEnumerable<KeyValuePair<string, string>>> GetAllAsKeyValuePairsAsync()
        {
            var models = await this.modelsRepository.AllAsNoTracking()
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                }).ToListAsync();

            var data = models.Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name)).ToList();

            data.Insert(0, new KeyValuePair<string, string>(null, "Select model"));

            return data;
        }
    }
}
