﻿using System;
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
    public class DeleteModel : PageModel
    {
        private readonly SituatieScoalara.Data.SituatieScoalaraContext _context;

        public DeleteModel(SituatieScoalara.Data.SituatieScoalaraContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Materie Materie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Materie = await _context.Materie.FirstOrDefaultAsync(m => m.ID == id);

            if (Materie == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Materie = await _context.Materie.FindAsync(id);

            if (Materie != null)
            {
                _context.Materie.Remove(Materie);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
