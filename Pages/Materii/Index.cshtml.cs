using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SituatieScoalara.Data;
using SituatieScoalara.Models;

namespace SituatieScoalara.Pages.Materii
{
    public class IndexModel : PageModel
    {
        private readonly SituatieScoalara.Data.SituatieScoalaraContext _context;

        public IndexModel(SituatieScoalara.Data.SituatieScoalaraContext context)
        {
            _context = context;
        }

        public IList<Materie> Materie { get;set; }

        public async Task OnGetAsync()
        {
            Materie = await _context.Materie.ToListAsync();
        }
    }
}
