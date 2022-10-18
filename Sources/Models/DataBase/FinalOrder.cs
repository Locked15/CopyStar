using System;
using System.Collections.Generic;

namespace CopyStar.Sources.Models.DataBase
{
    public partial class FinalOrder
    {
        public FinalOrder()
        {
            ItemsInOrders = new HashSet<ItemsInOrder>();
        }

        public int Id { get; set; }
        public int BuyerId { get; set; }
        public int AddressId { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual Address Address { get; set; } = null!;
        public virtual Buyer Buyer { get; set; } = null!;
        public virtual ICollection<ItemsInOrder> ItemsInOrders { get; set; }
    }
}
