using System;
using Microsoft.EntityFrameworkCore;
using Leg_Warmers.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Leg_Warmers.Data
{
    public class MvcLegWarmersContext : DbContext
    {
        public MvcLegWarmersContext(DbContextOptions<MvcLegWarmersContext> options)
           : base(options)
        {
        }

        public DbSet<Legwarmers> LegWarmers{ get; set; }
    }
}