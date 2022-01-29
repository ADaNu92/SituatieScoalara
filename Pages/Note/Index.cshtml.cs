using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SituatieScoalara.Data;
using SituatieScoalara.Models;

namespace SituatieScoalara.Pages.Note
{
    public class IndexModel : PageModel
    {
        private readonly SituatieScoalara.Data.SituatieScoalaraContext _context;

        public IndexModel(SituatieScoalara.Data.SituatieScoalaraContext context)
        {
            _context = context;
        }

        public IList<Nota> Nota { get;set; }

        public async Task OnGetAsync()
        {
            Nota = await _context.Nota
                .Include(n => n.Materie)
                .Include(n => n.Profesor)
                .Include(n => n.Student).ToListAsync();
        }
    }
}
