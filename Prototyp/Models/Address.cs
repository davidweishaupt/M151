using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prototyp.Models
{
    public class Address
    {
        public string streetName { get;set; }
        public int streetNumber { get;set; }
        public string city { get; set; }
        public int postalCode { get; set; }
        public Address(string streetName, int streetNumber, string city, int postalCode)
        {
            this.streetName = streetName;
            this.streetNumber = streetNumber;
            this.city = city;
            this.postalCode = postalCode;
        }
    }
}
