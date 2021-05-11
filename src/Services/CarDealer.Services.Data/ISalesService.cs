namespace CarDealer.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CarDealer.Web.ViewModels.InputModels.Sales;
    using CarDealer.Web.ViewModels.InputModels.SearchSales;
    using CarDealer.Web.ViewModels.Sales;

    public interface ISalesService
    {
        Task<int> CreateSaleAsync(AddSaleViewModel input, string userId);

        Task<EditSaleViewModel> GetEditSaleViewModel(int id);

        Task<SaleViewModel> UpdateSaleAsync(int id, EditSaleInputModel input);

        Task DeleteAsync(int id);

        Task<IEnumerable<SaleViewModel>> GetAllByCountryId(int page, int itemsPerPage, int countryId);

        Task<IEnumerable<SaleViewModel>> GetAllBySearchForm(SearchListInputModel input);

        Task<IEnumerable<SaleViewModel>> GetTopSixteenCarsInUsersCountry(int id);

        Task<IEnumerable<SaleViewModel>> GetUserDashboardSalesByUserId(string userId);

        Task<SaleViewModel> GetSaleInfo(int saleId);

        Task<SaleViewModel> GetSingleSaleInfo(int saleId);

        Task<int> GetSalesCountByCountryId(int countryId);

        Task IncreaseOpensSaleCounter(int id);

        Task<AddSaleViewModel> GetViewModelForCreateSale(int countryId);

        Task<SalesListViewModel> GetSalesListViewModelByCountryId(int id, int itemsPerPage, int countryId);

        Task<IEnumerable<SaleViewModel>> GetSalesListViewModelByUserId(string id);
    }
}
