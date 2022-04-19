using System;
using System.Collections.Generic;

#nullable disable

namespace AdaProjectWithSql.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Baskets = new HashSet<Basket>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }

        public virtual ICollection<Basket> Baskets { get; set; }
    }
}
