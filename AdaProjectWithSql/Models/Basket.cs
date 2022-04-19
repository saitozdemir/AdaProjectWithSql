using System;
using System.Collections.Generic;

#nullable disable

namespace AdaProjectWithSql.Models
{
    public partial class Basket
    {
        public Basket()
        {
            BasketProducts = new HashSet<BasketProduct>();
        }

        public int Id { get; set; }
        public int? CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<BasketProduct> BasketProducts { get; set; }
    }
}
