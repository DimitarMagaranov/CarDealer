﻿namespace CarDealer.Data.Models
{
    using System;
    using CarDealer.Data.Common.Models;
    using CarDealer.Data.Models.SaleModels;

    public class Sale : BaseDeletableModel<int>
    {

        public DaysValid DaysValid { get; set; }

        public int CarId { get; set; }

        public virtual Car Car { get; set; }

        public decimal Price { get; set; }

        public int RegionId { get; set; }

        public virtual Region Region { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string Description { get; set; }
    }
}
