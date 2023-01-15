using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Szilveszter_Levente_Proiect.Data;
using Szilveszter_Levente_Proiect.Models;

namespace Szilveszter_Levente_Proiect.Pages.Shipments
{
    public class IndexModel : PageModel
    {
        private readonly Szilveszter_Levente_Proiect.Data.Szilveszter_Levente_ProiectContext _context;

        public IndexModel(Szilveszter_Levente_Proiect.Data.Szilveszter_Levente_ProiectContext context)
        {
            _context = context;
        }

        public IList<Shipment> Shipment { get;set; }
        public ShipmentData ShipmentD { get; set; }
        public int ShipmentID { get; set; }
        public int CategoryID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            ShipmentD = new ShipmentData();

            ShipmentD.Shipments = await _context.Shipment
                     .Include(s => s.Caller)
                     .Include(s => s.Sender)
                     .Include(s => s.ShipmentCategories)
                        .ThenInclude(sc => sc.Category)
                     .AsNoTracking()
                     .OrderBy(s => s.Recipient)
                     .ToListAsync();

            if (id != null)
            {
                ShipmentID = id.Value;
                Shipment shipment = ShipmentD.Shipments
                        .Where(i => i.ID == id.Value).Single();
                ShipmentD.Categories = shipment.ShipmentCategories.Select(sel => sel.Category);
            }
        }
    }
}
