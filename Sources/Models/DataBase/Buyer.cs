using System;
using System.Collections.Generic;

namespace CopyStar.Sources.Models.DataBase
{
    public partial class Buyer
    {
        public Buyer()
        {
            Baskets = new HashSet<Basket>();
            FinalOrders = new HashSet<FinalOrder>();
        }

        public int Id { get; set; }
        public int? FavoritePaymentId { get; set; }
        public string Login { get; set; } = null!;

        public virtual PaymentMethod? FavoritePayment { get; set; }
        public virtual ICollection<Basket> Baskets { get; set; }
        public virtual ICollection<FinalOrder> FinalOrders { get; set; }
    }
}
