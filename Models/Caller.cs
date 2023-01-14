namespace Szilveszter_Levente_Proiect.Models
{
    public class Caller
    {
        public int ID { get; set; }
        public string CallerName { get; set; }
        public ICollection<Shipment>? Shipments { get; set; }
    }
}

