namespace CarDealer.Web.Areas.Administration.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CarDealer.Data.Common.Repositories;
    using CarDealer.Data.Models;
    using CarDealer.Data.Models.SaleModels;
    using CarDealer.Services.Data;
    using CarDealer.Web.ViewModels.Sales;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    [Area("Administration")]
    public class SalesController : AdministrationController
    {
        private readonly IDeletableEntityRepository<Sale> salesRepository;
        private readonly IDeletableEntityRepository<Car> carsRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;
        private readonly IRepository<Country> countriesRepository;
        private readonly ISalesService salesService;

        public SalesController(
            IDeletableEntityRepository<Sale> salesRepository,
            IDeletableEntityRepository<Car> carsRepository,
            IDeletableEntityRepository<ApplicationUser> usersRepository,
            IRepository<Country> countriesRepository,
            ISalesService salesService)
        {
            this.salesRepository = salesRepository;
            this.carsRepository = carsRepository;
            this.usersRepository = usersRepository;
            this.countriesRepository = countriesRepository;
            this.salesService = salesService;
        }

        // GET: Administration/Sales
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = this.salesRepository.All().Include(s => s.Car).Include(s => s.Country).Include(s => s.User);
            var sales = await applicationDbContext.ToListAsync();

            var viewModel = new List<SaleViewModel>();

            foreach (var sale in sales)
            {
                viewModel.Add(await this.salesService.GetSingleSaleInfo(sale.Id));
            }

            return this.View(viewModel);
        }

        // GET: Administration/Sales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var sale = await this.salesRepository.All()
                .Include(s => s.Car)
                .Include(s => s.Country)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sale == null)
            {
                return this.NotFound();
            }

            return this.View(sale);
        }

        // GET: Administration/Sales/Create
        public IActionResult Create()
        {
            this.ViewData["CarId"] = new SelectList(this.carsRepository.All(), "Id", "Id");
            this.ViewData["CountryId"] = new SelectList(this.countriesRepository.All(), "Id", "Id");
            this.ViewData["UserId"] = new SelectList(this.usersRepository.All(), "Id", "Id");
            return this.View();
        }

        // POST: Administration/Sales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DaysValid,CarId,Price,CountryId,UserId,Description,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Sale sale)
        {
            if (this.ModelState.IsValid)
            {
                await this.salesRepository.AddAsync(sale);
                await this.salesRepository.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            this.ViewData["CarId"] = new SelectList(this.carsRepository.All(), "Id", "Id", sale.CarId);
            this.ViewData["CountryId"] = new SelectList(this.countriesRepository.All(), "Id", "Id", sale.CountryId);
            this.ViewData["UserId"] = new SelectList(this.usersRepository.All(), "Id", "Id", sale.UserId);
            return this.View(sale);
        }

        // GET: Administration/Sales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var sale = await this.salesRepository.All().FirstOrDefaultAsync(x => x.Id == id);
            if (sale == null)
            {
                return this.NotFound();
            }

            this.ViewData["CarId"] = new SelectList(this.carsRepository.All(), "Id", "Id", sale.CarId);
            this.ViewData["CountryId"] = new SelectList(this.countriesRepository.All(), "Id", "Id", sale.CountryId);
            this.ViewData["UserId"] = new SelectList(this.usersRepository.All(), "Id", "Id", sale.UserId);
            return this.View(sale);
        }

        // POST: Administration/Sales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DaysValid,CarId,Price,CountryId,UserId,Description,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Sale sale)
        {
            if (id != sale.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.salesRepository.Update(sale);
                    await this.salesRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.SaleExists(sale.Id))
                    {
                        return this.NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return this.RedirectToAction(nameof(this.Index));
            }

            this.ViewData["CarId"] = new SelectList(this.carsRepository.All(), "Id", "Id", sale.CarId);
            this.ViewData["CountryId"] = new SelectList(this.countriesRepository.All(), "Id", "Id", sale.CountryId);
            this.ViewData["UserId"] = new SelectList(this.usersRepository.All(), "Id", "Id", sale.UserId);
            return this.View(sale);
        }

        // GET: Administration/Sales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var sale = await this.salesRepository.All()
                .Include(s => s.Car)
                .Include(s => s.Country)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sale == null)
            {
                return this.NotFound();
            }

            return this.View(sale);
        }

        // POST: Administration/Sales/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sale = await this.salesRepository.All().FirstOrDefaultAsync(x => x.Id == id);
            this.salesRepository.Delete(sale);
            await this.salesRepository.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool SaleExists(int id)
        {
            return this.salesRepository.All().Any(e => e.Id == id);
        }
    }
}
