using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Szilveszter_Levente_Proiect.Models;

namespace Szilveszter_Levente_Proiect.Data
{
    public class Szilveszter_Levente_ProiectContext : DbContext
    {
        public Szilveszter_Levente_ProiectContext (DbContextOptions<Szilveszter_Levente_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Szilveszter_Levente_Proiect.Models.Shipment> Shipment { get; set; } = default!;

        public DbSet<Szilveszter_Levente_Proiect.Models.Caller> Caller { get; set; }

        public DbSet<Szilveszter_Levente_Proiect.Models.Category> Category { get; set; }

        public DbSet<Szilveszter_Levente_Proiect.Models.Sender> Sender { get; set; }
    }
}
