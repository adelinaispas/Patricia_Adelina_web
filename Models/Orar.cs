using System.ComponentModel.DataAnnotations;

namespace Patricia_Adelina_web.Models
{
    public class Orar
    {
        public int ID { get; set; }
        [Display(Name = "Program")]
        public string Zi { get; set; }
        public ICollection<Film>? Filme { get; set; }
    }
}
