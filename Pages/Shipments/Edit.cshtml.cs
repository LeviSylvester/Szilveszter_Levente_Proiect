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

namespace Szilveszter_Levente_Proiect.Pages.Shipments
{
    public class EditModel : ShipmentCategoriesPageModel
    {
        private readonly Szilveszter_Levente_Proiect.Data.Szilveszter_Levente_ProiectContext _context;

        public EditModel(Szilveszter_Levente_Proiect.Data.Szilveszter_Levente_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Shipment Shipment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Shipment = await _context.Shipment
                .Include(s => s.Caller)
                .Include(s => s.ShipmentCategories).ThenInclude(s => s.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Shipment == null)
            {
                return NotFound();
            }

            //calling the following method to obtain checkbox info using AssignedCategoryData 
            PopulateAssignedCategoryData(_context, Shipment);

            ViewData["CallerID"] = new SelectList(_context.Caller, "ID", "CallerName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)

        {
            if (id == null)
            {
                return NotFound();
            }

            var shipmentToUpdate = await _context.Shipment
                .Include(i => i.Caller)
                .Include(i => i.ShipmentCategories)
                .ThenInclude(i => i.Category)
                .FirstOrDefaultAsync(s => s.ID == id);

            if (shipmentToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Shipment>(shipmentToUpdate, "Shipment",
                i => i.Recipient, i => i.Sender,
                i => i.Price, i => i.BookingDateTime, i => i.Caller))
            {
                UpdateShipmentCategories(_context, selectedCategories, shipmentToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            //calling the following method to apply info from checkboxes to the Shipment entity which is edited
            UpdateShipmentCategories(_context, selectedCategories, shipmentToUpdate);
            PopulateAssignedCategoryData(_context, shipmentToUpdate);
            return Page();
        }
    }
}
