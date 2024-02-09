namespace TestTechniqueC_.Models
{
    public class Project
    {
        public string Uuid { get; set; } = string.Empty;
        public DateTime? Date { get; set; }
        public string? Horaires { get; set; }
        public string? Travail { get; set; }
        public int? Temp1 { get; set; }
        public int? Temp2 { get; set; }
        public string? Meteo { get; set; }
    }
}
