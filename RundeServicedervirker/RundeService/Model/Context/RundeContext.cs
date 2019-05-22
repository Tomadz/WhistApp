using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RundeService.Model.Context
{
    public class RundeContext : DbContext
    {
        public RundeContext(DbContextOptions<RundeContext> options) : base(options) { }

        public DbSet<Runde> Runder { get; set; }   

    }
}
