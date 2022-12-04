using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Autorepair.Shared.Models
{
    public class Qualification
    {
        public int QualificationId { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }

        public ICollection<Mechanic> Mechanics { get; set; }

        public Qualification()
        {
            Mechanics = new List<Mechanic>();
        }
    }
}
