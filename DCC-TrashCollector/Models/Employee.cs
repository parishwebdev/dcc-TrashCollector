using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DCC_TrashCollector.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public int AssignZipCode { get; set; }

        public string AspNetUserId { get; set; }

    }
}