using System;
using System.Collections.Generic;

namespace CopyStar.Sources.Model
{
	public partial class OrderItem
	{
		public int Id { get; set; }
		public int ItemId { get; set; }

		public virtual CatalogItem Item { get; set; } = null!;
	}
}
