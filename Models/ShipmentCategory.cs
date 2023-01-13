namespace Szilveszter_Levente_Proiect.Models
{
    public class ShipmentCategory
    {
        public int ID { get; set; }
        public int ShipmentID { get; set; }
        public Shipment Shipment { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
