using MangoRead.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoRead.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Manuscript> Manuscripts { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            /*_ = this.Database.EnsureDeleted();*/
            _ = this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Manuscript>()
                .HasIndex(x => x.Index);

            builder.Entity<Manuscript>()
                .HasMany(x => x.Genres)
                .WithOne(y => y.Manuscript)
                .HasForeignKey(x => x.ManuscriptId);

            builder.Entity<Manuscript>()
                .Property(x => x.Title)
                .HasMaxLength(100);
            
            builder.Entity<ManuscriptContent>()
                .HasOne(x => x.Manuscript)
                .WithOne(y => y.Content);

            builder.Entity<Page>()
                .HasOne(x => x.Content)
                .WithMany(y => y.Pages)
                .HasForeignKey(x => x.ManuscriptContentId);

        }
    }
}
