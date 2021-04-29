namespace CarDealer.Web.ViewModels.Sales
{
    using AutoMapper;
    using CarDealer.Data.Models;
    using CarDealer.Services.Mapping;
    using CarDealer.Web.ViewModels.Cars;

    public class EditSaleViewModel : BaseSaleViewModel, IMapFrom<Sale>
    {
        public int Id { get; set; }

        public int MakeId { get; set; }

        public int ModelId { get; set; }

        public EditCarViewModel Car { get; set; }
    }
}
