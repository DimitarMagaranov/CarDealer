namespace CarDealer.Web.ViewModels.Sales
{
    using System.Collections.Generic;

    public class SalesListViewModel : PagingViewModel
    {
        public IEnumerable<SaleViewModel> Sales { get; set; }
    }
}
