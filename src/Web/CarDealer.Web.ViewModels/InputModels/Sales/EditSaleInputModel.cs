using CarDealer.Web.ViewModels.InputModels.Cars;
using System;

namespace CarDealer.Web.ViewModels.InputModels.Sales
{
    public class EditSaleInputModel : BaseSaleInputModel
    {
        public int Id { get; set; }

        public EditCarInputModel Car { get; set; }
    }
}
