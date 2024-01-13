using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Patricia_Adelina_web.Data;
using Patricia_Adelina_web.Models;

namespace Patricia_Adelina_web.Pages.Actori
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly Patricia_Adelina_web.Data.Patricia_Adelina_webContext _context;

        public CreateModel(Patricia_Adelina_web.Data.Patricia_Adelina_webContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Actor Actor { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Actor == null || Actor == null)
            {
                return Page();
            }

            _context.Actor.Add(Actor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
