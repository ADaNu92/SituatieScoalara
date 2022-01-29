using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SituatieScoalara.Data;
using SituatieScoalara.Models;

namespace SituatieScoalara.Pages.Note
{
    public class EditModel : PageModel
    {
        private readonly SituatieScoalara.Data.SituatieScoalaraContext _context;

        public EditModel(SituatieScoalara.Data.SituatieScoalaraContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["MaterieID"] = new SelectList(_context.Materie, "ID", "Nume");
           ViewData["ProfesorID"] = new SelectList(_context.Profesor, "ID", "Nume");
           ViewData["StudentID"] = new SelectList(_context.Student, "ID", "Nume");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Nota).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotaExists(Nota.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool NotaExists(int id)
        {
            return _context.Nota.Any(e => e.ID == id);
        }
    }
}
