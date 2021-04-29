namespace CarDealer.Web.ViewModels.Cars
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    using AutoMapper;

    using CarDealer.Data.Models;
    using CarDealer.Services.Mapping;

    public class CarViewModel : IMapFrom<Car>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string MakeName { get; set; }

        public string ModelName { get; set; }

        public string CategoryName { get; set; }

        public string FuelTypeName { get; set; }

        public int EngineSize { get; set; }

        public int HorsePower { get; set; }

        public int EuroStandartId { get; set; }

        public string GearboxName { get; set; }

        public string ColorName { get; set; }

        public string Seats { get; set; }

        public string Doors { get; set; }

        public string State { get; set; }

        public int Mileage { get; set; }

        public DateTime ManufactureDate { get; set; }

        public string ManufactureDateAsString { get; set; }

        public IEnumerable<string> Extras { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Car, CarViewModel>()
                .ForMember(x => x.ManufactureDateAsString, options =>
                options.MapFrom(x => x.ManufactureDate.ToString(CultureInfo.InvariantCulture)));
        }

        ////imposible mappings:
        // -ModelName
        // -Seats
        // -Doors
        // -State
        // -Extras
    }
}
