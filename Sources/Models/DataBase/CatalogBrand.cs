using System;
using System.Collections.Generic;

namespace CopyStar.Sources.Models.DataBase
{
    public partial class CatalogBrand
    {
        public CatalogBrand()
        {
            CatalogItems = new HashSet<CatalogItem>();
        }

        public int Id { get; set; }
        public string Brand { get; set; } = null!;

        public virtual ICollection<CatalogItem> CatalogItems { get; set; }
    }
}
