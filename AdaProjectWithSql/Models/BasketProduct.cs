using System;
using System.Collections.Generic;

#nullable disable

namespace AdaProjectWithSql.Models
{
    public partial class BasketProduct
    {
        public int Id { get; set; }
        public int? BasketId { get; set; }
        public decimal? Amount { get; set; }
        public string Statement { get; set; }

        public virtual Basket Basket { get; set; }
    }
}
