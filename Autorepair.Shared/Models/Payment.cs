using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace Autorepair.Shared.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int CarId { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public int Cost { get; set; }
        public int MechanicId { get; set; }
        public string ProgressReport { get; set; }
        public Car Car { get; set; }
        public Mechanic Mechanic { get; set; }
    }
}
