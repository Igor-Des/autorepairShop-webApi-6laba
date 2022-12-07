using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Autorepair.Shared.Models
{
    public class Owner
    {
        public int OwnerId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int DriverLicenseNumber { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
        public ICollection<Car> Cars { get; set; }

        public Owner()
        {
            Cars = new List<Car>();
        }
    }
}
