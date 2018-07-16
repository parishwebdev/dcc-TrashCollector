using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DCC_TrashCollector.Models
{
    public class CustomerAddress
    {
        [Key]
        public int CustomerAddressId { get; set; }

        [Display(Name = "Address")]
        public string AddressLine { get; set; }
        public string City { get; set; }
        //filter for only 5 digets (watch vid)
        public int Zip { get; set; }
        public string State { get; set; }

    }
}