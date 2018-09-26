using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pharmacita.Models
{
    public class DrugFind
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Drug Name ")]
        public string DrugName { get; set; }
        [Required]
        [Display(Name = "Drug Describtion ")]
        public string DrugDescribtion { get; set; }
        [Required]
        [Display(Name = "Quantity ")]
        public int Quantity { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }


    }
}