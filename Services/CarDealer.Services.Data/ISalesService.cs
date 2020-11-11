namespace CarDealer.Services.Data
{
    using System.Collections.Generic;
    using CarDealer.Services.Data.Models;
    using CarDealer.Web.ViewModels.InputModels.Sales;
    using CarDealer.Web.ViewModels.Sales;

    public interface ISalesService
    {
        void CreateSale(AddSaleInputModel input);

        void RemoveSale(int saleId);

        SaleDto GetSaleById(int id);

        IEnumerable<SaleDto> GetAll();

        IEnumerable<SaleDto> GetAllByCategory(string category);

        IEnumerable<SaleDto> GetAllBySearchForm(SearchSaleFormInputModel input);
    }
}
