namespace CarDealer.Web.ViewModels.Sales
{
    using CarDealer.Web.ViewModels.Cars;

    public class EditSaleViewModel : BaseSaleViewModel
    {
        public int Id { get; set; }

        public int MakeId { get; set; }

        public int ModelId { get; set; }

        public EditCarViewModel Car { get; set; }
    }
}
