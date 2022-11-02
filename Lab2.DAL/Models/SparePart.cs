using Lab2.DAL.Models.Enums;

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
