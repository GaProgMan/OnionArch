using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Onion.Data.Entities;
using Onion.Data.Mapping;
using Onion.Repo.Extensions;

namespace Onion.Repo.Data
{
    public class DwContext : DbContext
    {
        public DwContext(DbContextOptions<DwContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new BookMap(modelBuilder.Entity<Book>());
            new SeriesMap(modelBuilder.Entity<Series>());
        }
        
        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            ChangeTracker.ApplyAuditInformation();
            
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        
        public DbSet<Book> Books { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<BookSeries> BookSeries { get; set; }
    }
}