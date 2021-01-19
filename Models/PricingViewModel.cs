using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class PricingViewModel
    {
        [Display(Name = "Select a file")]
        public IFormFile formFile { get; set; }

        [Display(Name = "ColumnCode")]
        [Required(ErrorMessage = "Enter {0} value, please")]
        public string colCode { get; set; }

        [Display(Name = "ColumnName")]
        [Required(ErrorMessage = "Enter {0} value, please")]
        public string colName { get; set; }
    }
}
