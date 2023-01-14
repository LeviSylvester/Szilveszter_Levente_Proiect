using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Szilveszter_Levente_Proiect.Models
{
    public class Sender
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        [Display(Name = "Sender Data")]
        public string FullName
        {
            get
            {
                return LastName + " " + FirstName + " " + Address + " " + Phone;
            }
        }

        public ICollection<Shipment>? Shipments { get; set; }

    }
}
