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
        [Range(10000, 99999,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Zip { get; set; }
        public string State { get; set; }

    }
}