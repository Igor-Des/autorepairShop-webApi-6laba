using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Autorepair.Shared.Models
{
    public class Mechanic
    {
        public int MechanicId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int QualificationType { get; set; }
        public int Experience { get; set; }

        public Qualification Qualification { get; set; }
        public ICollection<Payment> Payments { get; set; }

        public Mechanic()
        {
            Payments = new List<Payment>();
        }
    }
}
