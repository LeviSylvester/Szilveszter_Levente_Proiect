namespace Szilveszter_Levente_Proiect.Models
{
    public class ShipmentData
    {
        public IEnumerable<Shipment> Shipments { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<ShipmentCategory> ShipmentCategories { get; set; }
    }
}
