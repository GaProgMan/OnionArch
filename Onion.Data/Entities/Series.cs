using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Onion.Data.Entities
{
    public class Series : BaseAuditClass
    {
        public string SeriesName { get; set; }
        
        public virtual ICollection<BookSeries> BookSeries { get; set; } = new Collection<BookSeries>();
    }
}