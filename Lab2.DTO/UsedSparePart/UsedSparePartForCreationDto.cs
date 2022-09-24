using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.DTO.UsedSparePart
{
    public class UsedSparePartForCreationDto
    {
        public Guid FaultId { get; set; }
        public Guid SparePartId { get; set; }
    }
}
