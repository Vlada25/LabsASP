namespace Lab2.DTO.SparePart
{
    public class SparePartDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Functions { get; set; }
        public decimal Price { get; set; }
        public string EquipmentType { get; set; }

        public override string ToString()
        {
            return $"\n  Id: {Id}\n  Name: {Name}\n  Functions: {Functions}\n  Price: {Price}" +
                $"\n  EquipmentType: {EquipmentType}\n";
        }
    }
}
