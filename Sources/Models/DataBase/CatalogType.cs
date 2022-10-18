using System;
using System.Collections.Generic;

namespace CopyStar.Sources.Models.DataBase
{
    public partial class CatalogType
    {
        public CatalogType()
        {
            CatalogItems = new HashSet<CatalogItem>();
        }

        public int Id { get; set; }
        public string Type { get; set; } = null!;

        public virtual ICollection<CatalogItem> CatalogItems { get; set; }
    }
}
