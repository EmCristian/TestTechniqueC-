namespace TestTechniqueC_.DTOs
{
    public class ProjectDTO
    {
        public string Uuid { get; set; } = string.Empty;
        public DateTime? Date { get; set; }
        public string? WorkingHours { get; set; }
        public string? WorkAt { get; set; }
        public int? TemperatureMorning { get; set; }
        public int? TemperatureAfterNoon { get; set; }
        public string? Weather { get; set; }
    }
}
