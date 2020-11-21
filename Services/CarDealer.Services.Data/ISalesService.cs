namespace CarDealer.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CarDealer.Services.Data.Models;
    using CarDealer.Web.ViewModels.InputModels.Sales;
    using CarDealer.Web.ViewModels.Sales;

    public interface ISalesService
    {
        Task<int> CreateSaleAsync(AddSaleInputModel input);

        Task RemoveSaleAsync(int saleId);

        SaleDto GetSaleById(int id);

        IEnumerable<SaleViewModel> GetAllByCountryId(int countryId);

        IEnumerable<SaleDto> GetAllByCategory(string category);

        IEnumerable<SaleDto> GetAllBySearchForm(SearchSaleFormInputModel input);

        SaleViewModel GetSaleInfo(int saleId);
    }
}
