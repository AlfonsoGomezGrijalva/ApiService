using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Models
{
    public class AddressModel
    {
        public string streetAddress { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public int postalCode { get; set; }
    }
}
