using CarDealer.Models.SaleModels;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CarDealer.Models
{
    public class Sale
    {
        public Sale()
        {
            this.CarSales = new HashSet<CarSales>();
        }

        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DaysValid DaysValid { get; set; }

        public int CarId { get; set; }

        public virtual Car Car { get; set; }

        public decimal Price { get; set; }

        public int RegionId { get; set; }

        public virtual Region Region { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<CarSales> CarSales { get; set; }
    }
}
