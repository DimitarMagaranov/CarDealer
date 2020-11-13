﻿namespace CarDealer.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models.CarModels;

    public class GearboxesService : IGearboxesService
    {
        private readonly IRepository<Gearbox> gearboxesRepository;

        public GearboxesService(IRepository<Gearbox> gearboxesRepository)
        {
            this.gearboxesRepository = gearboxesRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            var data = this.gearboxesRepository.AllAsNoTracking()
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name)).ToList();

            data[0] = new KeyValuePair<string, string>(null, "Select gearbox");

            return data;
        }
    }
}