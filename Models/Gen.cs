using System.ComponentModel.DataAnnotations;

namespace Patricia_Adelina_web.Models
{
    public class Gen
    {
        public int ID { get; set; }
        [Display(Name = "Gen")]
        public string NumeGen { get; set; }
        public ICollection<ActorFilm>? ActoriFilme { get; set; }
    }
}
