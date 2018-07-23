using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DCC_TrashCollector.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public decimal Balance { get; set; }

        public decimal MonthBalance
        {
            get
            {
                if (Balance != 0)
                {
                    return Balance * 4;
                }
                else
                {
                    return 0.00M;
                }
            }
        }
        

        //~~~~~~~ Day Section ~~~~~~~~
        [ForeignKey("Day")]
        [Display(Name = "Pick Up Day")]
        public int DayId { get; set; }
        public Day Day { get; set; }

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

        // ~~~~~ User ~~~~~
        public string AspNetUserId { get; set; }
       

        //~~~~~~~~~ Address Section ~~~~~~~~~~
        public string AddressLine { get; set; }

        [ForeignKey("City")]
        [Display(Name = "City")]
        public int CityId { get; set; }
        public City City { get; set; }

        [ForeignKey("ZipCode")]
        [Display(Name = "Zip Code")]
        public int ZipId { get; set; }
        public ZipCode ZipCode { get; set; }

        [ForeignKey("State")]
        [Display(Name = "State")]
        public int StateId { get; set; }
        public State State { get; set; }




    }
}