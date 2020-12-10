namespace CarDealer.Services.Data
{
    using CarDealer.Services.Data.Dtos;
    using CarDealer.Web.ViewModels.InputModels.Sales;
    using CarDealer.Web.ViewModels.InputModels.SearchSales;
    using CarDealer.Web.ViewModels.Sales;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISalesService
    {
        Task<int> CreateSaleAsync(AddSaleInputModel input, string userId, string imagePath);

        Task RemoveSaleAsync(int saleId);

        EditSaleInputModel GetEditSaleInputModel(int id);

        Task UpdateAsync(int id, EditSaleInputModel input);

        Task DeleteAsync(int id);

        IEnumerable<SaleViewModel> GetAllByUserId(int page, int itemsPerPage, string userId);

        IEnumerable<SaleViewModel> GetAllByCountryId(int page, int itemsPerPage, int countryId);

        IEnumerable<SaleViewModel> GetAllBySearchForm(SearchListInputModel input);

        IEnumerable<SaleViewModel> GetTopNineCarsInUsersCountry(int id);

        IEnumerable<SaleViewModel> GetTopNineCarsFromEnywhere();

        SaleViewModel GetSaleInfo(int saleId);

        SaleViewModel GetSingleSaleInfo(int saleId);

        int GetSalesCountByCountryId(int countryId);

        int GetSalesCountByUserId(string userId);

        Task IncreaseOpensSaleCounter(int id);
    }
}
