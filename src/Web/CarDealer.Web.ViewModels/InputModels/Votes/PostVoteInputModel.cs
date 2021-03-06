﻿namespace CarDealer.Web.ViewModels.InputModels.Votes
{
    using System.ComponentModel.DataAnnotations;

    public class PostVoteInputModel
    {
        public int SaleId { get; set; }

        [Range(1, 5)]
        public byte Value { get; set; }
    }
}
