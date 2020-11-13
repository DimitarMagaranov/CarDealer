namespace CarDealer.Data.Models.SaleModels
{
    using System.Collections.Generic;

    public class Country
    {
        public Country()
        {
            this.Sales = new HashSet<Sale>();
            this.Cities = new HashSet<City>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
