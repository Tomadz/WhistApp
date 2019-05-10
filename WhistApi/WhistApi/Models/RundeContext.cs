﻿using Microsoft.EntityFrameworkCore;

namespace WhistApi.Models
{
    public class RundeContext : DbContext
    {
        public RundeContext(DbContextOptions<RundeContext> options)
            : base(options)
        { }

        public DbSet<Runde> Runder { get; set; }
    }
}
