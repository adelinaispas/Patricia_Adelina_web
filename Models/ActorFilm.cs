namespace Patricia_Adelina_web.Models
{
    public class ActorFilm
    {
        public int ID { get; set; }
        public int FilmID { get; set; }
        public Film Film { get; set; }
        public int ActorID { get; set; }
        public Actor Actor { get; set; }
    }
}
