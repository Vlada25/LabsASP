using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.DAL.Models
{
    public class Fault
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid RepairingModelId { get; set; }
        public string RepairingMethods { get; set; }
        public decimal Price { get; set; }
        public RepairingModel RepairingModel { get; set; }
    }
}
