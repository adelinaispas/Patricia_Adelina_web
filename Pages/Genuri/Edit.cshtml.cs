using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Patricia_Adelina_web.Data;
using Patricia_Adelina_web.Models;

namespace Patricia_Adelina_web.Pages.Genuri
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly Patricia_Adelina_web.Data.Patricia_Adelina_webContext _context;

        public EditModel(Patricia_Adelina_web.Data.Patricia_Adelina_webContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Gen Gen { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Gen == null)
            {
                return NotFound();
            }

            var gen =  await _context.Gen.FirstOrDefaultAsync(m => m.ID == id);
            if (gen == null)
            {
                return NotFound();
            }
            Gen = gen;
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

            _context.Attach(Gen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenExists(Gen.ID))
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

        private bool GenExists(int id)
        {
          return (_context.Gen?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
