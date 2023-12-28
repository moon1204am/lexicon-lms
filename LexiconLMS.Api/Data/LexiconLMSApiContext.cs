using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LexiconLMS.Shared.Entities;

    public class LexiconLMSApiContext : DbContext
    {
        public LexiconLMSApiContext (DbContextOptions<LexiconLMSApiContext> options)
            : base(options)
        {
        }

        public DbSet<LexiconLMS.Shared.Entities.Course> Course { get; set; } = default!;
    }
