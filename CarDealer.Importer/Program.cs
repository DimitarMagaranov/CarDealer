using CarDealer.Data;
using CarDealer.Importer.JsonDtos;
using CarDealer.Services.Models;
using CarDealer.Services.Models.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace CarDealer.Importer
{
    class Program
    {
        static void Main(string[] args)
        {
            var json = File.ReadAllText("CarMakesJsonImporterFile.json");

            var properties = JsonSerializer.Deserialize<IEnumerable<MakeDto>>(json);

            var db = new CarDealerDbContext();

            IMakesService makesService = new MakesService(db);

            foreach (var property in properties)
            {
                try
                {
                    makesService.Create(property.Name);
                }
                catch
                {
                }
            }
        }
    }
}
