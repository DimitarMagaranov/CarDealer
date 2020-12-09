namespace CarDealer.Web.ViewModels.InputModels.Sales
{
    using CarDealer.Web.ViewModels.InputModels.Cars;

    public class EditSaleInputModel : BaseSaleInputModel
    {
        public int Id { get; set; }

        public int MakeId { get; set; }

        public int ModelId { get; set; }

        public EditCarInputModel Car { get; set; }
    }
}
