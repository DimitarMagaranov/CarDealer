namespace CarDealer.Models
{
    public class CarSales
    {
        public int CarId { get; set; }

        public virtual Car Car { get; set; }

        public int SaleId { get; set; }

        public virtual Sale Sale { get; set; }
    }
}
