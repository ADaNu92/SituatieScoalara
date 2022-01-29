using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SituatieScoalara.Data;
using SituatieScoalara.Models;

namespace SituatieScoalara.Pages.Note
{
    public class CreateModel : PageModel
    {
        private readonly SituatieScoalara.Data.SituatieScoalaraContext _context;

        public CreateModel(SituatieScoalara.Data.SituatieScoalaraContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["MaterieID"] = new SelectList(_context.Materie, "ID", "Nume");
        ViewData["ProfesorID"] = new SelectList(_context.Profesor, "ID", "Nume");
        ViewData["StudentID"] = new SelectList(_context.Student, "ID", "Nume");
            return Page();
        }

        [BindProperty]
        public Nota Nota { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Nota.Add(Nota);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
