using Lab2.DAL.Extensions;
using Lab2.DAL.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.DAL.Models
{
    public class RepairingModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public EquipmentType Type { get; set; }
        public string Manufacturer { get; set; }
        public string Specifications { get; set; }
        public string ParticularQualities { get; set; }
    }
}
