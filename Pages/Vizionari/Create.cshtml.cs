using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Patricia_Adelina_web.Data;
using Patricia_Adelina_web.Models;

namespace Patricia_Adelina_web.Pages.Vizionari
{
    public class CreateModel : PageModel
    {
        private readonly Patricia_Adelina_web.Data.Patricia_Adelina_webContext _context;

        public CreateModel(Patricia_Adelina_web.Data.Patricia_Adelina_webContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["FilmID"] = new SelectList(_context.Set<Film>(), "ID", "Titlu");
        ViewData["VizionatorID"] = new SelectList(_context.Vizionator, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Vizionare Vizionare { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Vizionare == null || Vizionare == null)
            {
                return Page();
            }

            _context.Vizionare.Add(Vizionare);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
