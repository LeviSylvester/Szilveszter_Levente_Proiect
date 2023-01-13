namespace Szilveszter_Levente_Proiect.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<ShipmentCategory>? ShipmentCategories { get; set; }
    }
}
