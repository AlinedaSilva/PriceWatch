using PriceWatch.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using System.Data.Entity.Infrastructure;
namespace PriceWatch.DAL
{
    public class PriceWatchContext : DbContext
    {
        public PriceWatchContext() : base("PriceWatchContext")
        {

        }
       
        public DbSet<PriceWatchViewModel> PriceWatches {get;set;}

        public DbSet<PriceWatchEntry> PriceWatchEntries { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}