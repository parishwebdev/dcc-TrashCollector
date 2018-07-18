using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DCC_TrashCollector.Models
{
    public class State
    {
        [Key]
        public int StateId { get; set; }
        [Required]
        [StringLength(2, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [Display(Name = "State Name")]
        public string Name { get; set; }
    }
}