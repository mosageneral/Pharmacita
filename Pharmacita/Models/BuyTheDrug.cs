using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pharmacita.Models
{
    public class BuyTheDrug
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime BuyDate { get; set; }
        public int DrugId { get; set; }
        public string UserId { get; set; }
        public virtual Drug drug { get; set; }
        public virtual ApplicationUser user { get; set; }

    }
}