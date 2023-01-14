using System.Security.Policy;

namespace Szilveszter_Levente_Proiect.Models.ViewModels
{
    public class SenderIndexData
    {
        public IEnumerable<Sender> Senders { get; set; }
        public IEnumerable<Shipment> Shipments { get; set; }
    }
}

