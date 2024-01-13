﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Patricia_Adelina_web.Data;
using Patricia_Adelina_web.Models;

namespace Patricia_Adelina_web.Pages.Actori
{
    public class IndexModel : PageModel
    {
        private readonly Patricia_Adelina_web.Data.Patricia_Adelina_webContext _context;

        public IndexModel(Patricia_Adelina_web.Data.Patricia_Adelina_webContext context)
        {
            _context = context;
        }

        public IList<Actor> Actor { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Actor != null)
            {
                Actor = await _context.Actor.ToListAsync();
            }
        }
    }
}
