﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Patricia_Adelina_web.Data;
using Patricia_Adelina_web.Models;

namespace Patricia_Adelina_web.Pages.Vizionari
{
    public class IndexModel : PageModel
    {
        private readonly Patricia_Adelina_web.Data.Patricia_Adelina_webContext _context;

        public IndexModel(Patricia_Adelina_web.Data.Patricia_Adelina_webContext context)
        {
            _context = context;
        }

        public IList<Vizionare> Vizionare { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Vizionare != null)
            {
                Vizionare = await _context.Vizionare
                .Include(v => v.Film)
                .Include(v => v.Vizionator).ToListAsync();
            }
        }
    }
}
