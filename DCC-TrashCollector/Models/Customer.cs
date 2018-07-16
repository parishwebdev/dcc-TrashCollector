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

        public string AspNetUserId { get; set; }

        [ForeignKey("CustomerAddress")]
        [Display(Name = "Address")]
        public int CustomerAddressId { get; set; }
        public CustomerAddress CustomerAddress { get; set; }

        [ForeignKey("CustomerSchedule")]
        [Display(Name = "Schedule")]
        public int CustomerScheduleId { get; set; }
        public CustomerSchedule CustomerSchedule { get; set; }


    }
}