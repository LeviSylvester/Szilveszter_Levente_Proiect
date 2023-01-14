using System.ComponentModel.DataAnnotations;

namespace Szilveszter_Levente_Proiect.Models
{
    public class Caller
    {
        public int ID { get; set; }

        [Display(Name = "Caller Data")]
        public string CallerName { get; set; }
        public ICollection<Shipment>? Shipments { get; set; }
    }
}

