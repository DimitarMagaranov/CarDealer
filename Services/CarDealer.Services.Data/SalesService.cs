namespace CarDealer.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models;
    using CarDealer.Data.Models.SaleModels;
    using CarDealer.Services.Data.Models;
    using CarDealer.Web.ViewModels.InputModels.Sales;

    public class SalesService : ISalesService
    {
        private readonly IDeletableEntityRepository<Sale> salesRepository;
        private readonly ICarsService carsService;

        public SalesService(IDeletableEntityRepository<Sale> salesRepository, ICarsService carsService)
        {
            this.salesRepository = salesRepository;
            this.carsService = carsService;
        }

        public void CreateSale(AddSaleInputModel input)
        {
            var saleToAdd = new Sale
            {
                DaysValid = (DaysValid)Enum.Parse(typeof(DaysValid), input.DaysValid),
                Price = input.Price,
                RegionId = input.RegionId,
                UserId = input.UserId,
                Car = this.carsService.CreateCar(input.Car),
            };

            this.salesRepository.AddAsync(saleToAdd);

            this.salesRepository.SaveChangesAsync();
        }

        public void RemoveSale(int saleId)
        {
            var saleToRemove = this.salesRepository.All().FirstOrDefault(x => x.Id == saleId);

            this.salesRepository.Delete(saleToRemove);

            this.salesRepository.SaveChangesAsync();
        }

        public SaleDto GetSaleById(int id)
        {
            var sale = this.salesRepository.All().Where(x => x.Id == id)
                .Select(x => new SaleDto
                {
                    Id = x.Id,
                    CreatedOn = x.CreatedOn,
                    Price = x.Price,
                    Region = x.Region.Name,
                    UserName = x.User.UserName,
                    UserPhoneNumber = x.User.PhoneNumber,
                    Description = x.Description,
                    CarId = x.Car.Id,
                    Car = this.carsService.GetCarById(x.Car.Id),
                });

            return (SaleDto)sale;
        }

        public IEnumerable<SaleDto> GetAll()
        {
            var sales = new List<SaleDto>();

            foreach (var sale in this.salesRepository.All())
            {
                sales.Add(this.GetSaleById(sale.Id));
            }

            return sales;
        }

        public IEnumerable<SaleDto> GetAllByCategory(string categoryName)
        {
            var sales = new List<SaleDto>();

            foreach (var sale in this.salesRepository.All().Where(x => x.Car.Category.Name == categoryName))
            {
                sales.Add(this.GetSaleById(sale.Id));
            }

            return sales;
        }

        public IEnumerable<SaleDto> GetAllBySearchForm(SearchSaleFormInputModel input)
        {
            var sales = this.salesRepository.All().Where(x => x.Car.Category.Name == input.Category);

            if (input.Make != null)
            {
                sales = sales.Where(x => x.Car.Make.Name == input.Make);

                if (input.Model != null)
                {
                    sales = sales.Where(x => x.Car.Make.Name == input.Make && x.Car.Make.Models.All(m => m.Name == input.Model));
                }
            }

            if (input.State != null)
            {
                sales = sales.Where(x => x.Car.State == input.State);
            }

            if (input.ManufactureYearFrom != null)
            {
                sales = sales.Where(x => x.Car.ManufactureDate.Year >= input.ManufactureYearFrom);
            }

            if (input.ManufactureYearTo != null)
            {
                sales = sales.Where(x => x.Car.ManufactureDate.Year <= input.ManufactureYearTo);
            }

            if (input.PriceFrom != null)
            {
                sales = sales.Where(x => x.Price >= input.PriceFrom);
            }

            if (input.PriceTo != null)
            {
                sales = sales.Where(x => x.Price <= input.PriceTo);
            }

            if (input.FuelType != null)
            {
                sales = sales.Where(x => x.Car.FuelType.Name == input.FuelType);
            }

            if (input.Gearbox != null)
            {
                sales = sales.Where(x => x.Car.Gearbox.Name == input.Gearbox);
            }

            if (input.EngineSizeFrom != null)
            {
                sales = sales.Where(x => x.Car.EngineSize >= input.EngineSizeFrom);
            }

            if (input.EngineSizeTo != null)
            {
                sales = sales.Where(x => x.Car.EngineSize <= input.EngineSizeTo);
            }

            if (input.MileageTo != null)
            {
                sales = sales.Where(x => x.Car.Mileage <= input.MileageTo);
            }

            if (input.Color != null)
            {
                sales = sales.Where(x => x.Car.Color.Name == input.Color);
            }

            if (input.EuroStandart != null)
            {
                sales = sales.Where(x => x.Car.EuroStandart.Name == input.EuroStandart);
            }

            if (input.Region != null)
            {
                sales = sales.Where(x => x.Region.Name == input.Region);
            }

            if (input.SortCommand != null)
            {
                switch (input.SortCommand)
                {
                    case "Price (Low - High)":
                        sales = sales.OrderBy(x => x.Price);
                        break;
                    case "Manufacture date":
                        sales = sales.OrderBy(x => x.Car.ManufactureDate);
                        break;
                    case "Miliage":
                        sales = sales.OrderBy(x => x.Car.Mileage);
                        break;
                    case "Newest sales":
                        sales = sales.OrderByDescending(x => x.CreatedOn);
                        break;
                    default:
                        break;
                }
            }

            var salesToShow = new List<SaleDto>();

            foreach (var sale in sales)
            {
                salesToShow.Add(this.GetSaleById(sale.Id));
            }

            return salesToShow;
        }
    }
}
