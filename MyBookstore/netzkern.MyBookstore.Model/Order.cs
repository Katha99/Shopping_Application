using System.Collections.Generic;

namespace netzkern.MyBookstore.Model
{
    public class Order : BaseEntity
    {
        public int PersonAccountId { get; set; }
        public PersonAccount PersonAccountRef { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
