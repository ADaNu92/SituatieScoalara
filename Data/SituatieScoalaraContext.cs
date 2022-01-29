using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SituatieScoalara.Models;

namespace SituatieScoalara.Data
{
    public class SituatieScoalaraContext : DbContext
    {
        public SituatieScoalaraContext (DbContextOptions<SituatieScoalaraContext> options)
            : base(options)
        {
        }

        public DbSet<SituatieScoalara.Models.Materie> Materie { get; set; }

        public DbSet<SituatieScoalara.Models.Profesor> Profesor { get; set; }

        public DbSet<SituatieScoalara.Models.Student> Student { get; set; }

        public DbSet<SituatieScoalara.Models.Nota> Nota { get; set; }
    }
}
