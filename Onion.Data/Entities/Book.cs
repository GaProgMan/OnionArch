using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Onion.Data.Entities
{
    public class Book : BaseAuditClass
    {
        public int BookOrdinal { get; set; }
        public string BookName { get; set; }
        public string BookIsbn10 { get; set; }
        public string BookIsbn13 { get; set; }
        public string BookDescription { get; set; }
        public byte[] BookCoverImage { get; set; }
        public string BookCoverImageUrl { get; set; }
        
        public virtual ICollection<BookSeries> BookSeries { get; } = new Collection<BookSeries>();
    }
}