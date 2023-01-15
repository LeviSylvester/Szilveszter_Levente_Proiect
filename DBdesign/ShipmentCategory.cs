using System;
using System.Collections.Generic;

namespace Szilveszter_Levente_Proiect.ReverseEngineeredTables
{
    public partial class ShipmentCategory
    {
        public int Id { get; set; }
        public int ShipmentId { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual Shipment Shipment { get; set; } = null!;
    }
}
