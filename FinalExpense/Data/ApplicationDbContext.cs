using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinalExpense.Models;


namespace FinalExpense.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {

        }

        public DbSet<Records> Transfers  { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Records>().HasKey(x => x.Id);
            base.OnModelCreating(builder);
            // ...
        }

    }
}
