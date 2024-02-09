using Npgsql;
using TestTechniqueC_.Models;

namespace TestTechniqueC_.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private NpgsqlDataSource dataSource;
        private readonly string connectionString = "Host=127.0.0.1;Username=postgres;Password=1234;Database=project";
        public ProjectRepository()
        {
            dataSource = NpgsqlDataSource.Create(connectionString);
        }

        public List<Project> GetAllProjects()
        {
            List<Project> result = new List<Project>();

            using var command = dataSource.CreateCommand("SELECT * FROM public.projet");
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var project = new Project()
                {
                    Uuid = reader.GetString(0),
                    Date = DateTime.Parse(reader.GetString(1)),
                    Horaires = reader.GetString(2),
                    Travail = reader.GetString(3),
                    Temp1 = reader.GetInt32(5),
                    Temp2 = reader.GetInt32(6),
                    Meteo = reader.GetString(4)
                };
                result.Add(project);
            }

            return result;
        }
        public bool Insert(Project entity)
        {
            try
            {
                using var conn = new NpgsqlConnection(connectionString);
                conn.Open();

                using var command = new NpgsqlCommand(@"INSERT INTO public.projet (uuid, _date, horaires, travail, meteo, temp1, temp2) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7)", conn)
                {
                    Parameters =
                {
                    new("p1", entity.Uuid),
                    new("p2", entity.Date.Value.ToShortDateString()),
                    new("p3", entity.Horaires),
                    new("p4", entity.Travail),
                    new("p5", entity.Meteo),
                    new("p6", entity.Temp1),
                    new("p7", entity.Temp2),
                }
                };

                bool inserted = command.ExecuteNonQuery() > 0;
                conn.Close();
                return inserted;
            }
            catch(Exception ex)
            {
                //ex
                return false;
            }
        }
    }
}
