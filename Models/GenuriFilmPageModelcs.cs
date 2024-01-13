using Microsoft.AspNetCore.Mvc.RazorPages;
using Patricia_Adelina_web.Data;
using System.Collections.Generic;
using System.Linq;
namespace Patricia_Adelina_web.Models
{
    public class GenuriFilmPageModel : PageModel
    {
        public List<DateGenAtribuite> ListaDateGenAtribuite;

        public void PopulareDateGenAtribuite(Patricia_Adelina_webContext context, Film film)
        {
            var toateGenurile = context.Gen.ToList();
            var genuriFilm = new HashSet<int>(film.ActoriFilme.Select(c => c.ActorID));
            ListaDateGenAtribuite = new List<DateGenAtribuite>();

            foreach (var gen in toateGenurile)
            {
                ListaDateGenAtribuite.Add(new DateGenAtribuite
                {
                    GenID = gen.ID,
                    Nume = gen.NumeGen,
                    Atribuit = genuriFilm.Contains(gen.ID)
                });
            }
        }

    }
}
