using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pharmacita.Models
{
    public class DrugViewModel
    {
        public string DrugName { get; set; }
        public IEnumerable <BuyTheDrug>  Items { get; set; }
    }
}