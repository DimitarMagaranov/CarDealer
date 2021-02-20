namespace CarDealer.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CarDealer.Web.ViewModels.InputModels.Sales;
    using CarDealer.Web.ViewModels.InputModels.SearchSales;
    using CarDealer.Web.ViewModels.Sales;

    public interface ISalesService
    {
        Task<int> CreateSaleAsync(AddSaleInputModel input, string userId);

        Task<EditSaleViewModel> GetEditSaleViewModel(int id);

        Task UpdateSaleAsync(int id, EditSaleInputModel input);

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

        Task<AddSaleViewModel> GetViewModelForCreateSale(int countryId);

        SalesListViewModel GetSalesListViewModelByCountryId(int id, int itemsPerPage, int countryId);

        SalesListViewModel GetSalesListViewModelByUserId(int id, int itemsPerPage, string userId);
    }
}
