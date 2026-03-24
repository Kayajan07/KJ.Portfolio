using KJ.Portfolio.Web.Ui.Models.Entities;
using Microsoft.EntityFrameworkCore;
using KJ.Portfolio.WebUI.Controllers;
using KJ.Portfolio.WebUI.Models.Entities;

namespace KJ.Portfolio.WebUI.Models
{
    public class PortfolioDbContext : DbContext
    {
        public PortfolioDbContext() { }
        public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options) : base(options) { }

        public DbSet<HomePage> HomePages { get; set; }
        public DbSet<PortfolioCategory> PortfolioCategories { get; set; }
        public DbSet<PortfolioItem> PortfolioItems { get; set; }
        public DbSet<PortfolioTag> PortfolioTags { get; set; }
        public DbSet<WhatIKnowCard> WhatIKnowCards { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<ExperienceListItem> ExperienceListItems { get; set; }
        //public DbSet<TechnologiesCard> TechnologiesCards { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PortfolioTag>()
                .HasMany(x => x.Items)
                .WithMany(x => x.Tags);

            base.OnModelCreating(modelBuilder);
        }
    }
}
