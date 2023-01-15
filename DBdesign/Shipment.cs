using System;
using System.Collections.Generic;

namespace Szilveszter_Levente_Proiect.ReverseEngineeredTables
{
    public partial class Shipment
    {
        public Shipment()
        {
            ShipmentCategories = new HashSet<ShipmentCategory>();
        }

        public int Id { get; set; }
        public string Recipient { get; set; } = null!;
        public int SenderId { get; set; }
        public decimal Price { get; set; }
        public DateTime BookingDateTime { get; set; }
        public int CallerId { get; set; }

        public virtual Caller Caller { get; set; } = null!;
        public virtual Sender Sender { get; set; } = null!;
        public virtual ICollection<ShipmentCategory> ShipmentCategories { get; set; }
    }
}
