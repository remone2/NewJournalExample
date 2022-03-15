#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewJournalExample.Models;

namespace NewJournalExample.Data
{
    public class NewJournalExampleContext : DbContext
    {
        public NewJournalExampleContext (DbContextOptions<NewJournalExampleContext> options)
            : base(options)
        {
        }

        public DbSet<NewJournalExample.Models.Journal> Journal { get; set; }
        public DbSet<NewJournalExample.Models.User> Users { get; set; }
        public DbSet<NewJournalExample.Models.Comment> Comments { get; set; }
    }
}
