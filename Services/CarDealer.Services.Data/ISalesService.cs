namespace CarDealer.Services.Data
{
    using System.Collections.Generic;

    using CarDealer.Web.ViewModels.InputModels.Sales;
    using CarDealer.Web.ViewModels.Sales;

    public interface ISalesService
    {
        void CreateSale(AddSaleInputModel input);

        void RemoveSale(int saleId);

        SaleViewModel GetSaleById(int id);

        IEnumerable<SaleViewModel> GetAll();

        IEnumerable<SaleViewModel> GetAllByCategory(string category);

        IEnumerable<SaleViewModel> GetAllBySearchForm(SearchSaleFormInputModel input);
    }
}
