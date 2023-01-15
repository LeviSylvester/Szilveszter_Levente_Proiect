using System;
using System.Collections.Generic;

namespace Szilveszter_Levente_Proiect.ReverseEngineeredTables
{
    public partial class Caller
    {
        public Caller()
        {
            Shipments = new HashSet<Shipment>();
        }

        public int Id { get; set; }
        public string CallerName { get; set; } = null!;

        public virtual ICollection<Shipment> Shipments { get; set; }
    }
}
