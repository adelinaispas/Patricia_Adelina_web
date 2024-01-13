namespace Patricia_Adelina_web.Models
{
    public class DateFilm
    {
        public IEnumerable<Film> Filme { get; set; }
        public IEnumerable<Gen> Genuri { get; set; }
        public IEnumerable<ActorFilm> ActoriFilme { get; set; }
    }
}
