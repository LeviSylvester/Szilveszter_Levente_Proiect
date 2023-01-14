using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Szilveszter_Levente_Proiect.Data;
using Szilveszter_Levente_Proiect.Models;

namespace Szilveszter_Levente_Proiect.Pages.Shipments
{
    public class CreateModel : ShipmentCategoriesPageModel
    {
        private readonly Szilveszter_Levente_Proiect.Data.Szilveszter_Levente_ProiectContext _context;

        public CreateModel(Szilveszter_Levente_Proiect.Data.Szilveszter_Levente_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["CallerID"] = new SelectList(_context.Set<Caller>(), "ID", "CallerName");

            var shipment = new Shipment();
            shipment.ShipmentCategories = new List<ShipmentCategory>();

            PopulateAssignedCategoryData(_context, shipment);

            return Page();
        }

        [BindProperty]
        public Shipment Shipment { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newShipment = new Shipment();
            if (selectedCategories != null)
            {
                newShipment.ShipmentCategories = new List<ShipmentCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new ShipmentCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newShipment.ShipmentCategories.Add(catToAdd);
                }
            }

            if (await TryUpdateModelAsync<Shipment>(newShipment, "Shipment",
                i => i.Recipient, i => i.Sender,
                i => i.Price, i => i.BookingDateTime, i => i.CallerID))
            {
                _context.Shipment.Add(newShipment);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newShipment);
            return Page();
        }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Shipment.Add(Shipment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
