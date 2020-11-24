﻿namespace CarDealer.Data.Models
{
    using CarDealer.Data.Common.Models;
    using CarDealer.Data.Models.SaleModels;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Sale : BaseDeletableModel<int>
    {
        public Sale()
        {
            this.Images = new HashSet<Image>();
        }

        [Range(0, 60)]
        public int DaysValid { get; set; }

        public int CarId { get; set; }

        public virtual Car Car { get; set; }

        public decimal Price { get; set; }

        public int CountryId { get; set; }

        [NotMapped]
        public int CityId { get; set; }

        public virtual Country Country { get; set; }

        // TODO: must make userid required
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public int MetaDataId { get; set; }

        public virtual MetaData MetaData { get; set; }
    }
}
