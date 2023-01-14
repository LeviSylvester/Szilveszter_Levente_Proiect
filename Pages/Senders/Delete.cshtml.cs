using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Szilveszter_Levente_Proiect.Data;
using Szilveszter_Levente_Proiect.Models;

namespace Szilveszter_Levente_Proiect.Pages.Senders
{
    public class DeleteModel : PageModel
    {
        private readonly Szilveszter_Levente_Proiect.Data.Szilveszter_Levente_ProiectContext _context;

        public DeleteModel(Szilveszter_Levente_Proiect.Data.Szilveszter_Levente_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Sender Sender { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Sender == null)
            {
                return NotFound();
            }

            var sender = await _context.Sender.FirstOrDefaultAsync(m => m.ID == id);

            if (sender == null)
            {
                return NotFound();
            }
            else 
            {
                Sender = sender;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Sender == null)
            {
                return NotFound();
            }
            var sender = await _context.Sender.FindAsync(id);

            if (sender != null)
            {
                Sender = sender;
                _context.Sender.Remove(Sender);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

