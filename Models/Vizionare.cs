using System.ComponentModel.DataAnnotations;

namespace Patricia_Adelina_web.Models
{
    public class Vizionare
    {
        public int ID { get; set; }
        [Display(Name = "Nume Vizionator")]
        public int? VizionatorID { get; set; }
        public Vizionator? Vizionator { get; set; }
        [Display(Name = "Titlu Film")]
        public int? FilmID { get; set; }
        public Film? Film { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Data Vizionare")]
        public DateTime DataVizionare { get; set; }
    }
}
