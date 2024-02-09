using System.ComponentModel.DataAnnotations;

namespace TestTechniqueC_.Models
{
    public class ProjectModel
    {
        public string Uuid { get; set; } = string.Empty;
        public DateTime? Date { get; set; }
        public string? WorkingHours { get; set; }
        [MaxLength(2)]
        public string? WorkAt { get; set; }
        public int? TemperatureMorning { get; set; }
        public int? TemperatureAfterNoon { get; set; }
        public string? Weather { get; set; }

        public Project GetEntity()
        {
            //var mapper = MapperConfig.Initialize();
            //return mapper.Map<Project>(this);
            return new Project()
            {
                Uuid = Guid.NewGuid().ToString(),
                Date = Date,
                Horaires = WorkingHours,
                Travail = WorkAt,
                Temp1 = TemperatureMorning,
                Temp2 = TemperatureAfterNoon,
                Meteo = Weather
            };
        }
    }
}
