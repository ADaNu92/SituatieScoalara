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
    public class DetailsModel : PageModel
    {
        private readonly SituatieScoalara.Data.SituatieScoalaraContext _context;

        public DetailsModel(SituatieScoalara.Data.SituatieScoalaraContext context)
        {
            _context = context;
        }

        public Nota Nota { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Nota = await _context.Nota
                .Include(n => n.Materie)
                .Include(n => n.Profesor)
                .Include(n => n.Student).FirstOrDefaultAsync(m => m.ID == id);

            if (Nota == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
