using System.ComponentModel.DataAnnotations;

namespace Patricia_Adelina_web.Models
{
    public class Actor
    {
        public int ID { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        [Display(Name = "Nume complet")]
        public string NumeComplet
        {
            get
            {
                return Prenume + " " + Nume;
            }
        }
        public ICollection<Film>? Filme { get; set; }
    }
}
