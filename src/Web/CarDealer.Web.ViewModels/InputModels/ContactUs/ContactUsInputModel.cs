﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Web.ViewModels.InputModels.ContactUs
{
    using System.ComponentModel.DataAnnotations;

    public class ContactUsInputModel
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Message { get; set; }
    }
}