namespace Lab2.DTO.UsedSparePart
{
    public class UsedSparePartDto
    {
        public Guid Id { get; set; }
        public Guid FaultId { get; set; }
        public string FaultName { get; set; }
        public decimal FaultPrice { get; set; }
        public Guid SparePartId { get; set; }
        public string SparePartName { get; set; }
        public decimal SparePartPrice { get; set; }

        public override string ToString()
        {
            return $"\n  Id: {Id}\n  FaultId: {FaultId}\n  FaultName: {FaultName}\n  FaultPrice: {FaultPrice}" +
                $"\n  SparePartId: {SparePartId}\n  SparePartName: {SparePartName}\n  SparePartPrice: {SparePartPrice}\n";
        }
    }
}
