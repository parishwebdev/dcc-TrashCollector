using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DCC_TrashCollector.Models
{
    public class ZipCode
    {
        [Key]
        public int ZipCodeId { get; set; }

        
        [Range(10000, 99999,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        [Display(Name = "Zip Code")]
        public int Zip { get; set; }
    }
}