using System.Collections.Generic;

namespace netzkern.MyBookstore.Model
{
    public class Order : BaseEntity
    {
        public virtual ICollection<Product> Products { get; set; }
    }
}
