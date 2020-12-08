using System.Collections.Generic;

namespace netzkern.MyBookstore.Model
{
    public class Order : BaseEntity
    {
        public int AddressId { get; set; }
        public Address AddressRef { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
