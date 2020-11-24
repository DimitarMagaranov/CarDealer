using CarDealer.Data.Common.Models;
using System;

namespace CarDealer.Data.Models.SaleModels
{
    public class Image : BaseDeletableModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string AddedByUserId { get; set; }

        public int SaleId { get; set; }

        public virtual Sale Sale { get; set; }

        public string ImageUrl { get; set; }

        public string Extension { get; set; }

        // The contents of the image is in the file system
    }
}
