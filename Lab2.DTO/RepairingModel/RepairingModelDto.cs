namespace Lab2.DTO.RepairingModel
{
    public class RepairingModelDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Manufacturer { get; set; }
        public string Specifications { get; set; }
        public string ParticularQualities { get; set; }

        public override string ToString()
        {
            return $"\n  Id: {Id}\n  Name: {Name}\n  Type: {Type}\n  Manufacturer: {Manufacturer}" +
                $"\n  Specifications: {Specifications}\n  ParticularQualities: {ParticularQualities}\n";
        }
    }
}
