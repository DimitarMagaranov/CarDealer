namespace CarDealer.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CarDealer.Services.Data.Models;
    using CarDealer.Web.ViewModels.InputModels.Sales;
    using CarDealer.Web.ViewModels.Sales;

    public interface ISalesService
    {
        Task CreateSaleAsync(AddSaleInputModel input);

        void RemoveSale(int saleId);

        SaleDto GetSaleById(int id);

        IEnumerable<SaleDto> GetAll();

        IEnumerable<SaleDto> GetAllByCategory(string category);

        IEnumerable<SaleDto> GetAllBySearchForm(SearchSaleFormInputModel input);
    }
}
