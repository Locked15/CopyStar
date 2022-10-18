using System;
using System.Collections.Generic;

namespace CopyStar.Sources.Model
{
	public partial class PaymentMethod
	{
		public PaymentMethod()
		{
			Buyers = new HashSet<Buyer>();
		}

		public int Id { get; set; }
		public string Method { get; set; } = null!;
		public string CardId { get; set; } = null!;
		public string SvcCode { get; set; } = null!;

		public virtual ICollection<Buyer> Buyers { get; set; }
	}
}
