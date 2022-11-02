using Lab2.DAL;
using Lab2.DAL.Configuration;
using Lab2.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Lab2.DAL
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Fault> Faults { get; set; }
        public DbSet<RepairingModel> RepairingModels { get; set; }
        public DbSet<SparePart> SpareParts { get; set; }
        public DbSet<UsedSparePart> UsedSpareParts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            DbInitializer.Initialize();

            modelBuilder.ApplyConfiguration(new FaultsConfig());
            modelBuilder.ApplyConfiguration(new RepairingModelsConfig());
            modelBuilder.ApplyConfiguration(new SparePartsConfig());
            modelBuilder.ApplyConfiguration(new UsedSparePartsConfig());
        }
    }
}