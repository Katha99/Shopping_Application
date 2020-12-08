using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netzkern.MyBookstore.Model
{
    public class Address : BaseEntity
    {
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
