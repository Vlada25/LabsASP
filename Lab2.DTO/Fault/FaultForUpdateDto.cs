namespace Lab2.DTO.Fault
{
    public class FaultForUpdateDto
    {
        public string Name { get; set; }
        public Guid RepairingModelId { get; set; }
        public string RepairingMethods { get; set; }
        public decimal Price { get; set; }
    }
}
