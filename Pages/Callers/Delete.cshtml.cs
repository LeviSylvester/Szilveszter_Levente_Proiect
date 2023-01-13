using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Szilveszter_Levente_Proiect.Data;
using Szilveszter_Levente_Proiect.Models;

namespace Szilveszter_Levente_Proiect.Pages.Callers
{
    public class DeleteModel : PageModel
    {
        private readonly Szilveszter_Levente_Proiect.Data.Szilveszter_Levente_ProiectContext _context;

        public DeleteModel(Szilveszter_Levente_Proiect.Data.Szilveszter_Levente_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Caller Caller { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Caller == null)
            {
                return NotFound();
            }

            var caller = await _context.Caller.FirstOrDefaultAsync(m => m.ID == id);

            if (caller == null)
            {
                return NotFound();
            }
            else 
            {
                Caller = caller;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Caller == null)
            {
                return NotFound();
            }
            var caller = await _context.Caller.FindAsync(id);

            if (caller != null)
            {
                Caller = caller;
                _context.Caller.Remove(Caller);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
