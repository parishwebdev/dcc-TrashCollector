using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DCC_TrashCollector.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [ForeignKey("ZipCode")]
        [Display(Name = "Assigned Zip Code")]
        public int ZipId { get; set; }
        public ZipCode ZipCode { get; set; }


        public string AspNetUserId { get; set; }

    }
}