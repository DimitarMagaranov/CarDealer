namespace CarDealer.Services.Data
{
    using CarDealer.Services.Data.Models;
    using CarDealer.Web.ViewModels.InputModels.Sales;
    using CarDealer.Web.ViewModels.Sales;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISalesService
    {
        Task<int> CreateSaleAsync(AddSaleInputModel input, string userId, string imagePath);

        Task RemoveSaleAsync(int saleId);

        SaleDto GetSaleById(int id);

        IEnumerable<SaleViewModel> GetAllByUserId(int page, int itemsPerPage, string userId);

        IEnumerable<SaleViewModel> GetAllByCountryId(int page, int itemsPerPage, int countryId);

        IEnumerable<SaleDto> GetAllByCategory(string category);

        IEnumerable<SaleDto> GetAllBySearchForm(SearchSaleFormInputModel input);

        SaleViewModel GetSaleInfo(int saleId);

        int GetSalesCountByCountryId(int countryId);

        int GetSalesCountByUserId(string userId);
    }
}
