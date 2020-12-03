using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netzkern.MyBookstore.Model
{
    public class PersonAccount : BaseEntity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
