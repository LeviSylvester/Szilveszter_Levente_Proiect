using System;
using System.Collections.Generic;

namespace Szilveszter_Levente_Proiect.ReverseEngineeredTables
{
    public partial class Sender
    {
        public Sender()
        {
            Shipments = new HashSet<Shipment>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;

        public virtual ICollection<Shipment> Shipments { get; set; }
    }
}
