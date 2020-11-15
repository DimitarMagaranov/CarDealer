namespace CarDealer.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models.CarModels;

    public class ModelsService : IModelsService
    {
        private readonly IRepository<Model> modelsRepository;

        public ModelsService(IRepository<Model> modelsRepository)
        {
            this.modelsRepository = modelsRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            var data = this.modelsRepository.AllAsNoTracking()
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name)).ToList();

            data.Insert(0, new KeyValuePair<string, string>(null, "Select model"));

            return data;
        }
    }
}
