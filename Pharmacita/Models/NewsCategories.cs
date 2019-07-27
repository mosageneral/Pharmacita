using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pharmacita.Models
{
    public class NewsCategories
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<News> news { get; set; }
    }
}