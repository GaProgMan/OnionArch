namespace Onion.Data.Entities
{
    public class BookSeries : BaseAuditClass
    {
        public int BookId { get; set; }
        public virtual Book Book { get; set; }

        public int SeriesId { get; set; }
        public virtual Series Series { get; set; }

        public int Ordinal { get; set; }
    }
}