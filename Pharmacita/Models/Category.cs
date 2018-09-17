using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pharmacita.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [Display (Name="Category Name" )]
        public string CategoryName { get; set; }
        
        [Display(Name = "Category Icon")]
        public string CategoryIcon { get; set; }

        [Required]
        [Display(Name = "Category Content")]
        public string CategoryContent { get; set; }
        public ICollection <Drug > drugs { get; set; }

    }

}