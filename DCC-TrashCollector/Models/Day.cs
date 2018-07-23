using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DCC_TrashCollector.Models
{
    public class Day
    {
        public int DayId { get; set; }


        [Display(Name = "Pick Up Day")]
        public String DayChoosen { get; set; }
    }
}