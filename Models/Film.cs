using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Patricia_Adelina_web.Models
{
    public class Film
    {
        public int ID { get; set; }
        [Display(Name = "Titlu Film")]
        [Required]
        [StringLength(150, MinimumLength = 3)]
        public string Titlu { get; set; }
        public int? ActorID { get; set; }
        public Actor? Actor { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        [Display(Name = "Preț Bilet")]
        public decimal PretBilet { get; set; }
        public int? GenID { get; set; }
        public Gen? Gen { get; set; }
        public ICollection<ActorFilm>? ActoriFilme { get; set; }
    }
}
