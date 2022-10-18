using System;
using System.Collections.Generic;

namespace CopyStar.Sources.Models.DataBase
{
    public partial class ItemsInOrder
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }

        public virtual CatalogItem Item { get; set; } = null!;
        public virtual FinalOrder Order { get; set; } = null!;
    }
}
