using Lab2.DAL.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.DAL.Models
{
    public class SparePart
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Functions { get; set; }
        public decimal Price { get; set; }
        public EquipmentType EquipmentType { get; set; }
    }
}
