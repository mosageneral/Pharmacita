using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pharmacita.Models
{
    public class Drug
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
        
        [Display(Name = "Drug Image ")]
        public string DrugImage { get; set; }
        [Required]
        [Display(Name = "Expire ")]
        public string  Expire { get; set; }
        [Required]
        [Display(Name = "Off ")]
        public decimal  Off { get; set; }
        [Required]
        [Display(Name = "Price ")]
        public decimal Price { get; set; }
        [Required]
        [Display(Name = "Category ")]
        public int categoryId { get; set; }
        public string UserId { get; set; }
        public virtual  Category category { get; set; }
        public virtual ApplicationUser User { get; set; }


    }
}