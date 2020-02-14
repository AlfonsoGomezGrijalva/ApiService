using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Models
{
    public class ClientModel
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int age { get; set; }
        public AddressModel address { get; set; }
        public string phoneNumber { get; set; }
    }
}
