using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DCC_TrashCollector.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        [Display(Name = "City Name")]
        public String Name { get; set; }
    }
}