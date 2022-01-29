using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SituatieScoalara.Data;
using SituatieScoalara.Models;

namespace SituatieScoalara.Pages.Profesori
{
    public class IndexModel : PageModel
    {
        private readonly SituatieScoalara.Data.SituatieScoalaraContext _context;

        public IndexModel(SituatieScoalara.Data.SituatieScoalaraContext context)
        {
            _context = context;
        }

        public IList<Profesor> Profesor { get;set; }

        public async Task OnGetAsync()
        {
            Profesor = await _context.Profesor.ToListAsync();
        }
    }
}
