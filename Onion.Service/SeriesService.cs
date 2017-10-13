using System.Collections.Generic;
using Onion.Data.Entities;
using Onion.Repo.Data;
using Onion.Service.Interfaces;

namespace Onion.Service
{
    public class SeriesService : ISeriesService
    {
        private readonly IRepository<Series> _seriesRepository;
        private readonly IRepository<BookSeries> _bookSeriesRepository;

        public SeriesService(IRepository<Series> seriesRepository,
            IRepository<BookSeries> bookSeriesRepository)
        {
            _seriesRepository = seriesRepository;
            _bookSeriesRepository = bookSeriesRepository;
        }

        public IEnumerable<Series> GetSeries()
        {
            return _seriesRepository.GetAll();
        }

        public Series GetSeries(int id)
        {
            return _seriesRepository.Get(id);
        }

        public void InsertSeries(Series series)
        {
            _seriesRepository.Insert(series);
        }

        public void UpdateSeries(Series series)
        {
            _seriesRepository.Update(series);
        }

        public void DeleteSeries(int id)
        {
            var bookSeries = _bookSeriesRepository.Get(id);
            _bookSeriesRepository.Delete(bookSeries);

            var user = _seriesRepository.Get(id);
            _seriesRepository.Delete(user);
            _seriesRepository.SaveChanges();
        }
    }
}