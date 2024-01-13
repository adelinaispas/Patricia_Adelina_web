using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Patricia_Adelina_web.Data;
using Patricia_Adelina_web.Models;

namespace Patricia_Adelina_web.Pages.Vizionari
{
    public class EditModel : PageModel
    {
        private readonly Patricia_Adelina_web.Data.Patricia_Adelina_webContext _context;

        public EditModel(Patricia_Adelina_web.Data.Patricia_Adelina_webContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Vizionare Vizionare { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Vizionare == null)
            {
                return NotFound();
            }

            var vizionare =  await _context.Vizionare.FirstOrDefaultAsync(m => m.ID == id);
            if (vizionare == null)
            {
                return NotFound();
            }
            Vizionare = vizionare;
           ViewData["FilmID"] = new SelectList(_context.Set<Film>(), "ID", "Titlu");
           ViewData["VizionatorID"] = new SelectList(_context.Vizionator, "ID", "ID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Vizionare).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VizionareExists(Vizionare.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool VizionareExists(int id)
        {
          return (_context.Vizionare?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
