using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onion.Data.Entities;

namespace Onion.Repo.Data.Mapping
{
    public class SeriesMap
    {
        public SeriesMap(EntityTypeBuilder<Series> entityBuilder)
        {
            entityBuilder.HasKey(s => s.Id);
            entityBuilder.HasMany(s => s.BookSeries)
                .WithOne(bs => bs.Series)
                .HasForeignKey(bs => bs.BookId);
            entityBuilder.ToTable("Series");
        }
    }
}