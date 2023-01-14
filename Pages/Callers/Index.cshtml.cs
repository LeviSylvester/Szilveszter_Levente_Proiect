using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Szilveszter_Levente_Proiect.Data;
using Szilveszter_Levente_Proiect.Models;
using Szilveszter_Levente_Proiect.Models.ViewModels;

namespace Szilveszter_Levente_Proiect.Pages.Callers
{
    public class IndexModel : PageModel
    {
        private readonly Szilveszter_Levente_Proiect.Data.Szilveszter_Levente_ProiectContext _context;

        public IndexModel(Szilveszter_Levente_Proiect.Data.Szilveszter_Levente_ProiectContext context)
        {
            _context = context;
        }

        public IList<Caller> Caller { get;set; } = default!;

        public CallerIndexData CallerData { get; set; }
        public int CallerID { get; set; }
        public int ShipmentID { get; set; }

        public async Task OnGetAsync(int? id, int? shipmentID)
        {
            CallerData = new CallerIndexData();
            CallerData.Callers = await _context.Caller
                .Include(i => i.Shipments)
                    .ThenInclude(c => c.Sender)
                .OrderBy(i => i.CallerName)
                .ToListAsync();

            if (id != null)
            {
                CallerID = id.Value;
                Caller caller = CallerData.Callers
                    .Where(i => i.ID == id.Value).Single();
                CallerData.Shipments = caller.Shipments;
            }
        }
    }
}

