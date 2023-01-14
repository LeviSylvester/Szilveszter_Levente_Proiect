using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;
using System.Xml.Linq;

namespace Szilveszter_Levente_Proiect.Models
{
    public class Shipment
    {
        public int ID { get; set; }

        [Required, StringLength(150, MinimumLength = 4)]
        [Display(Name = "Recipient's Address")]
        public string Recipient { get; set; }

        [Required, StringLength(150, MinimumLength = 4)]
        [Display(Name = "Sender's Address")]
        public string Sender { get; set; }

        [Range(1, 400)]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime BookingDateTime { get; set; }

        public int CallerID { get; set; }
        public Caller Caller { get; set; }

        public ICollection<ShipmentCategory> ShipmentCategories { get; set; }
    }
}
