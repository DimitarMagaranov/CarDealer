namespace CarDealer.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CarDealer.Data.Models;
    using CarDealer.Services.Data;
    using CarDealer.Web.ViewModels.InputModels.Cars;
    using CarDealer.Web.ViewModels.InputModels.Sales;
    using CarDealer.Web.ViewModels.Sales;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.Data.SqlClient;

    [Authorize]
    public class SalesController : BaseController
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly ISalesService salesService;
        private readonly ICategoriesService categoriesService;
        private readonly IMakesService makesService;
        private readonly IModelsService modelsService;
        private readonly IFuelTypesService fuelTypesService;
        private readonly IEuroStandartsService euroStandartsService;
        private readonly IGearboxesService gearboxesService;
        private readonly IColorsService colorsService;
        private readonly ICountriesService countriesService;
        private readonly ICitiesService citiesService;
        private readonly UserManager<ApplicationUser> userManager;

        public SalesController(
            IWebHostEnvironment webHostEnvironment,
            ISalesService salesService,
            ICategoriesService categoriesService,
            IMakesService makesService,
            IModelsService modelsService,
            IFuelTypesService fuelTypesService,
            IEuroStandartsService euroStandartsService,
            IGearboxesService gearboxesService,
            IColorsService colorsService,
            ICountriesService countriessService,
            ICitiesService citiesService,
            UserManager<ApplicationUser> userManager)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.salesService = salesService;
            this.categoriesService = categoriesService;
            this.makesService = makesService;
            this.modelsService = modelsService;
            this.fuelTypesService = fuelTypesService;
            this.euroStandartsService = euroStandartsService;
            this.gearboxesService = gearboxesService;
            this.colorsService = colorsService;
            this.countriesService = countriessService;
            this.citiesService = citiesService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Create(int countryId)
        {
            if (countryId == 0)
            {
                return this.RedirectToAction("SelectCountryForCreateSale", "Countries");
            }

            var viewModel = new AddSaleInputModel
            {
                CountryId = countryId,
            };

            viewModel.CitiesItems = await this.citiesService.GetAllAsSelectListItemsAsync(viewModel.CountryId);
            viewModel.Car = await this.GetCarInputModelWithFilledProperties();

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddSaleInputModel input)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            //Other way to take the userId:
            //var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var userId = user.Id;

            if (!this.ModelState.IsValid)
            {
                input.CitiesItems = await this.citiesService.GetAllAsSelectListItemsAsync(input.CountryId);
                input.Car = await this.GetCarInputModelWithFilledProperties();

                return this.View(input);
            }

            int id = 0;

            try
            {
                id = await this.salesService.CreateSaleAsync(input, userId, $"{this.webHostEnvironment.WebRootPath}/images");
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                input.CitiesItems = await this.citiesService.GetAllAsSelectListItemsAsync(input.CountryId);
                input.Car = await this.GetCarInputModelWithFilledProperties();
                return this.View(input);
            }

            this.TempData["Message"] = "Sale added successfully.";

            return this.RedirectToAction(nameof(this.SaleInfo), new { id });
        }

        public async Task<IActionResult> Edit(int id)
        {
            var viewModel = this.salesService.GetEditSaleInputModel(id);

            viewModel.CitiesItems = await this.citiesService.GetAllAsSelectListItemsAsync(viewModel.CountryId);

            var carItemsModel = await this.GetCarInputModelWithFilledProperties();

            viewModel.Car.ManufactureDate = carItemsModel.ManufactureDate;
            viewModel.Car.CategoriesItems = carItemsModel.CategoriesItems;
            viewModel.Car.MakesItems = carItemsModel.MakesItems;
            viewModel.Car.ModelstItems = carItemsModel.ModelstItems;
            viewModel.Car.FuelTypeItems = carItemsModel.FuelTypeItems;
            viewModel.Car.EuroStandartItems = carItemsModel.EuroStandartItems;
            viewModel.Car.GearboxesItems = carItemsModel.GearboxesItems;
            viewModel.Car.ColorstItems = carItemsModel.ColorstItems;

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditSaleInputModel input)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            input.CountryId = user.CountryId;

            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await this.salesService.UpdateAsync(id, input);

            return this.RedirectToAction(nameof(this.SaleInfo), new { id });
        }

        public async Task<IActionResult> All(int id)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            const int ItemsPerPage = 2;

            if (id == 0)
            {
                id++;
            }

            var salesListViewModel = new SalesListViewModel();

            salesListViewModel.PageNumber = id;

            salesListViewModel.ItemsPerPage = ItemsPerPage;

            salesListViewModel.Sales = this.salesService.GetAllByCountryId(id, ItemsPerPage, user.CountryId);
            salesListViewModel.SalesCount = this.salesService.GetSalesCountByCountryId(user.CountryId);

            return this.View(salesListViewModel);
        }

        public IActionResult SaleInfo(int id)
        {
            var viewModel = this.salesService.GetSaleInfo(id);

            return this.View(viewModel);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult AdminControlPanel()
        {
            return null;
        }

        public async Task<AddCarInputModel> GetCarInputModelWithFilledProperties()
        {
            var carViewModel = new AddCarInputModel();

            carViewModel.ManufactureDate = DateTime.UtcNow;
            carViewModel.CategoriesItems = await this.categoriesService.GetAllAsSelectListItemsAsync();
            carViewModel.MakesItems = await this.makesService.GetAllAsSelectListItemsAsync();
            carViewModel.ModelstItems = await this.modelsService.GetAllAsSelectListItemsAsync();
            carViewModel.FuelTypeItems = await this.fuelTypesService.GetAllAsSelectListItemsAsync();
            carViewModel.EuroStandartItems = await this.euroStandartsService.GetAllAsSelectListItemsAsync();
            carViewModel.GearboxesItems = await this.gearboxesService.GetAllAsSelectListItemsAsync();
            carViewModel.ColorstItems = await this.colorsService.GetAllAsSelectListItemsAsync();

            return carViewModel;
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSale(int id)
        {
            await this.salesService.DeleteAsync(id);

            return this.RedirectToAction("All", "Users");
        }





        public class CascadingModel
        {
            public CascadingModel()
            {
                this.Countries = new List<SelectListItem>();
                this.Cities = new List<SelectListItem>();
            }

            public List<SelectListItem> Countries { get; set; }
            public List<SelectListItem> Cities { get; set; }

            public int CountryId { get; set; }
            public int CityId { get; set; }
        }

        // GET: Home
        public ActionResult Index()
        {
            CascadingModel model = new CascadingModel();
            model.Countries = PopulateDropDown("SELECT Id, Name FROM Countries", "Name", "Id");
            return this.View(model);
        }

        [HttpPost]
        public ActionResult Index(int countryId, int stateId, int cityId)
        {
            CascadingModel model = new CascadingModel();
            model.Countries = PopulateDropDown("SELECT Id, Name FROM Countries", "Name", "Id");
            model.Cities = PopulateDropDown("SELECT Id, Name FROM Cities WHERE CountryId = " + countryId, "Name", "ID");
            return this.View(model);
        }

        [HttpPost]
        public JsonResult AjaxMethod(string type, int value)
        {
            CascadingModel model = new CascadingModel();

            model.Cities = PopulateDropDown("SELECT Id, Name FROM Cities WHERE Id = " + value, "Name", "Id");

            return this.Json(model);
        }

        private static List<SelectListItem> PopulateDropDown(string query, string textColumn, string valueColumn)
        {
            List<SelectListItem> items = new List<SelectListItem>();

            string constr = "Server=DESKTOP-C92LTDN\\SQLEXPRESS;Database=CarDealer;Trusted_Connection=True;MultipleActiveResultSets=true";

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            items.Add(new SelectListItem
                            {
                                Text = sdr[textColumn].ToString(),
                                Value = sdr[valueColumn].ToString(),
                            });
                        }
                    }

                    con.Close();
                }
            }

            return items;
        }
    }
}
