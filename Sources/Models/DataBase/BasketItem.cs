using System;
using System.Collections.Generic;

namespace CopyStar.Sources.Models.DataBase
{
    public partial class BasketItem
    {
        public BasketItem()
        {
            InverseItem = new HashSet<BasketItem>();
        }

        public int Id { get; set; }
        public int ItemId { get; set; }
        public int BasketId { get; set; }

        public virtual Basket Basket { get; set; } = null!;
        public virtual BasketItem Item { get; set; } = null!;
        public virtual ICollection<BasketItem> InverseItem { get; set; }
    }
}
