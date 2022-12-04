using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace Autorepair.Shared.Models
{
    public class Car
    {
        public int CarId { get; set; }
        public string Brand { get; set; }
        public int Power { get; set; }
        public string Color { get; set; }
        public string StateNumber { get; set; }
        public int OwnerId { get; set; }
        public int Year { get; set; }
        public string VIN { get; set; }
        public string EngineNumber { get; set; }
        [DataType(DataType.Date)]
        public DateTime AdmissionDate { get; set; }
        public Owner Owner { get; set; }
        public ICollection<Payment> Payments { get; set; }

        public Car()
        {
            Payments = new List<Payment>();
        }
    }
}
