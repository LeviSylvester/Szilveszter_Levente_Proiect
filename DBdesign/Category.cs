using System;
using System.Collections.Generic;

namespace Szilveszter_Levente_Proiect.ReverseEngineeredTables
{
    public partial class Category
    {
        public Category()
        {
            ShipmentCategories = new HashSet<ShipmentCategory>();
        }

        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;

        public virtual ICollection<ShipmentCategory> ShipmentCategories { get; set; }
    }
}
