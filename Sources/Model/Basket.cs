using System;
using System.Collections.Generic;

namespace CopyStar.Sources.Model
{
	public partial class Basket
	{
		public Basket()
		{
			BasketItems = new HashSet<BasketItem>();
		}

		public int Id { get; set; }
		public int BuyerId { get; set; }

		public virtual Buyer Buyer { get; set; } = null!;
		public virtual ICollection<BasketItem> BasketItems { get; set; }
	}
}
