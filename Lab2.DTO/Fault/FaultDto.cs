namespace Lab2.DTO.Fault
{
    public class FaultDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid RepairingModelId { get; set; }
        public string RepairingModelName { get; set; }
        public string RepairingModelSpecifications { get; set; }
        public string RepairingMethods { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"\n  Id: {Id}\n  Name: {Name}\n  RepairingModelId: {RepairingModelId}" +
                $"\n  RepairingModelName: {RepairingModelName}\n  RepairingModelSpecifications: {RepairingModelSpecifications}" +
                $"\n  RepairingMethods: {RepairingMethods}\n  Price: {Price}\n";
        }
    }
}
