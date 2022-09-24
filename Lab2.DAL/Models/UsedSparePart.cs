using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.DAL.Models
{
    public class UsedSparePart
    {
        public Guid Id { get; set; }
        public Guid FaultId { get; set; }
        public Guid SparePartId { get; set; }
        public Fault Fault { get; set; }
        public SparePart SparePart { get; set; }
    }
}
