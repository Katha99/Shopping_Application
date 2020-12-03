using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netzkern.MyBookstore.Model
{
    public class Product : BaseEntity
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Photo { get; set; }
        public string Content { get; set; }
        public int NumberOfPages { get; set; }

        public virtual Author Author{ get; set; }
        public int? AuthorId { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
