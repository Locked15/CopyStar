using System;
using System.Collections.Generic;

namespace CopyStar.Sources.Model
{
	public partial class Address
	{
		public Address()
		{
			FinalOrders = new HashSet<FinalOrder>();
		}

		public int Id { get; set; }
		public string Country { get; set; } = null!;
		public string? State { get; set; }
		public string City { get; set; } = null!;
		public string Street { get; set; } = null!;
		public string? ZipCode { get; set; }

		public virtual ICollection<FinalOrder> FinalOrders { get; set; }
	}
}
