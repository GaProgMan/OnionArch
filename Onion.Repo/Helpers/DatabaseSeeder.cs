using System;
using System.Linq;
using System.Threading.Tasks;
using Onion.Data.Entities;
using Onion.Repo.Data;

namespace Onion.Repo.Helpers
{
    public class DatabaseSeeder
    {
        private readonly DataContext _dataContext;

        public DatabaseSeeder(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<int> SeedBookEntries()
        {
            _dataContext.Books.Add(
                new Book()
                {
                    BookName = "The Colour of Magic",
                    BookOrdinal = 1,
                    BookIsbn10 = "086140324X",
                    BookIsbn13 = "9780552138932",
                    BookDescription = "On a world supported on the back of a giant turtle (sex unknown), a gleeful, explosive, wickedly eccentric expedition sets out. There's an avaricious but inept wizard, a naive tourist whose luggage moves on hundreds of dear little legs, dragons who only exist if you believe in them, and of course THE EDGE of the planet ...",
                    BookCoverImageUrl = "http://wiki.lspace.org/mediawiki/images/c/c9/Cover_The_Colour_Of_Magic.jpg"
                });
            // TODO implement method
            return await _dataContext.SaveChangesAsync();
        }

        public async Task<int> SeedSeriesEntries()
        {
            _dataContext.Series.Add(new Series()
            {
                SeriesName = "Rincewind"
            });
            // TODO implement method
            return await _dataContext.SaveChangesAsync();
        }

        public async Task<int> SeedBookSeriesEntries()
        {
            var rincewindBooks =
                _dataContext.Books.Where(book => book.BookName == "The Colour of Magic");

            var rincewindSeries = _dataContext.Series.FirstOrDefault(series => series.SeriesName == "Rincewind");

            if (!rincewindBooks.Any() || rincewindSeries == null)
            {
                throw new ArgumentException($"Unable to see {nameof(BookSeries)}");
            }

            _dataContext.BookSeries.AddRange(rincewindBooks.Select(b => new BookSeries()
            {
                BookId = b.Id,
                SeriesId = rincewindSeries.Id
            }));
            
            // TODO implement method
            return await _dataContext.SaveChangesAsync();
        }
    }
}