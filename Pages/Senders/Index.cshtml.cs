using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Szilveszter_Levente_Proiect.Data;
using Szilveszter_Levente_Proiect.Models;
using Szilveszter_Levente_Proiect.Models.ViewModels;

namespace Szilveszter_Levente_Proiect.Pages.Senders
{
    public class IndexModel : PageModel
    {
        private readonly Szilveszter_Levente_Proiect.Data.Szilveszter_Levente_ProiectContext _context;

        public IndexModel(Szilveszter_Levente_Proiect.Data.Szilveszter_Levente_ProiectContext context)
        {
            _context = context;
        }

        public IList<Sender> Sender { get; set; } = default!;

        public SenderIndexData SenderData { get; set; }
        public int SenderID { get; set; }
        public int BookID { get; set; }
        public async Task OnGetAsync(int? id, int? senderID)
        {
            SenderData = new SenderIndexData();
            SenderData.Senders = await _context.Sender
            .Include(i => i.Shipments)
                .ThenInclude(c => c.Caller)
            .OrderBy(i => i.LastName)
            .ToListAsync();
            if (id != null)
            {
                SenderID = id.Value;
                Sender sender = SenderData.Senders
                .Where(i => i.ID == id.Value).Single();
                SenderData.Shipments = sender.Shipments;
            }
        }
    }
}

