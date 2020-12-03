﻿namespace CarDealer.Web.Controllers
{
    using CarDealer.Services.Data;
    using CarDealer.Web.ViewModels;
    using CarDealer.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;

    public class HomeController : BaseController
    {
        private readonly IGetCountsService getCountsService;

        public HomeController(IGetCountsService getCountsService)
        {
            this.getCountsService = getCountsService;
        }

        public IActionResult Index()
        {
            var counts = this.getCountsService.GetCounts();

            var viewModel = new IndexViewModel
            {
                SalesCount = counts.SalesCount,
                CarsCount = counts.CarsCount,
                MakesCount = counts.MakesCount,
                CategoriesCount = counts.CategoriesCount,
            };

            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}