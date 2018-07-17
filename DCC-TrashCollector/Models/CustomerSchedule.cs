using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DCC_TrashCollector.Models
{
    public class CustomerSchedule
    {
        [Key]
        public int CustomerScheduleId { get; set; }

        [ForeignKey("Day")]
        [Display(Name = "Pick Up Day")]
        public int DayId { get; set; }
        public Day Day { get; set; }

        public IEnumerable<Day> DaysOfWeek;

        public bool Pickedup { get; set; }

        [Display(Name = "Extra Pickup Date")]
        [DataType(DataType.Date)]
        public DateTime? ExtraPickUpDate { get; set; }

        [Display(Name = "Pause Start Date")]
        [DataType(DataType.Date)]
        public DateTime? TempStartDate { get; set; }
        [Display(Name = "Pause End Date")]
        [DataType(DataType.Date)]
        public DateTime? TempEndDate { get; set; }

        

    }
}