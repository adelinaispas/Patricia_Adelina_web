using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Patricia_Adelina_web.Models;

namespace Patricia_Adelina_web.Data
{
    public class Patricia_Adelina_webContext : DbContext
    {
        public Patricia_Adelina_webContext (DbContextOptions<Patricia_Adelina_webContext> options)
            : base(options)
        {
        }

        public DbSet<Patricia_Adelina_web.Models.Actor> Actor { get; set; } = default!;

        public DbSet<Patricia_Adelina_web.Models.Orar>? Orar { get; set; }

        public DbSet<Patricia_Adelina_web.Models.Vizionator>? Vizionator { get; set; }

        public DbSet<Patricia_Adelina_web.Models.Vizionare>? Vizionare { get; set; }

        public DbSet<Patricia_Adelina_web.Models.Film>? Film { get; set; }

        public DbSet<Patricia_Adelina_web.Models.Gen>? Gen { get; set; }
    }
}
