using System;
using System.Collections.Generic;

namespace CopyStar.Sources.Models.DataBase
{
    public partial class CatalogItem
    {
        public CatalogItem()
        {
            ItemsInOrders = new HashSet<ItemsInOrder>();
            OrderItems = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public int? TypeId { get; set; }
        public int? BrandId { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string? Image { get; set; }

        public virtual CatalogBrand? Brand { get; set; }
        public virtual CatalogType? Type { get; set; }
        public virtual ICollection<ItemsInOrder> ItemsInOrders { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
