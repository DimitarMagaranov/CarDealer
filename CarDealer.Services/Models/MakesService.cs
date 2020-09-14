using CarDealer.Data;
using CarDealer.Models.CarModels;
using CarDealer.Services.Models.Contracts;
using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace CarDealer.Services.Models
{
    public class MakesService : IMakesService
    {
        private CarDealerDbContext db;

        public MakesService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public void Create(string name)
        {
            var makeEntity = new Make { Name = name };

            this.db.Makes.Add(makeEntity);

            this.db.SaveChanges();
        }
    }
}
