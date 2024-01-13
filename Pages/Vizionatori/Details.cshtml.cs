using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Patricia_Adelina_web.Data;
using Patricia_Adelina_web.Models;

namespace Patricia_Adelina_web.Pages.Vizionatori
{
    public class DetailsModel : PageModel
    {
        private readonly Patricia_Adelina_web.Data.Patricia_Adelina_webContext _context;

        public DetailsModel(Patricia_Adelina_web.Data.Patricia_Adelina_webContext context)
        {
            _context = context;
        }

      public Vizionator Vizionator { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Vizionator == null)
            {
                return NotFound();
            }

            var vizionator = await _context.Vizionator.FirstOrDefaultAsync(m => m.ID == id);
            if (vizionator == null)
            {
                return NotFound();
            }
            else 
            {
                Vizionator = vizionator;
            }
            return Page();
        }
    }
}
