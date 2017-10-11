using Onion.Data.Entities;
using Onion.Repo.Interfaces;
using Onion.Service.Interfaces;

namespace Onion.Service
{
    public class BookSeriesService : IBookSeriesService
    {
        private readonly IRepository<BookSeries> _bookSeriesRepository;

        public BookSeriesService(IRepository<BookSeries> bookSeriesRepository)
        {
            _bookSeriesRepository = bookSeriesRepository;
        }

        public BookSeries GetBookSeries(int id)
        {
            return _bookSeriesRepository.Get(id);
        }
    }
}