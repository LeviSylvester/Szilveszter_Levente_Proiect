using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Szilveszter_Levente_Proiect.Data;
using Szilveszter_Levente_Proiect.Models;

namespace Szilveszter_Levente_Proiect.Pages.Senders
{
    public class EditModel : PageModel
    {
        private readonly Szilveszter_Levente_Proiect.Data.Szilveszter_Levente_ProiectContext _context;

        public EditModel(Szilveszter_Levente_Proiect.Data.Szilveszter_Levente_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Sender Sender { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Sender == null)
            {
                return NotFound();
            }

            var sender =  await _context.Sender.FirstOrDefaultAsync(m => m.ID == id);
            if (sender == null)
            {
                return NotFound();
            }
            Sender = sender;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Sender).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SenderExists(Sender.ID))
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

        private bool SenderExists(int id)
        {
          return _context.Sender.Any(e => e.ID == id);
        }
    }
}

