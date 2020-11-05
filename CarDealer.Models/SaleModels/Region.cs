using System.Collections.Generic;

namespace CarDealer.Models.SaleModels
{
    public class Region
    {
        public Region()
        {
            this.Sales = new HashSet<Sale>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
