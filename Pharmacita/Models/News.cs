using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pharmacita.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; }
        
    }
}