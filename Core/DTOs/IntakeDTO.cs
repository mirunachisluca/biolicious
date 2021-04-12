namespace Core.DTOs
{
    public class IntakeDTO
    {
        public int Id { get; set; }
        public int EnergyKJ { get; set; }
        public int EnergyKCAL { get; set; }
        public double Fat { get; set; }
        public double Saturates { get; set; }
        public double Sugars { get; set; }
        public double Salt { get; set; }
        public double Carbohydrates { get; set; }
        public double Proteins { get; set; }
        public double Fibres { get; set; }
    }
}