using System.Collections.Generic;
using Onion.Data.Entities;
using Onion.Repo.Data;
using Onion.Service.Interfaces;

namespace Onion.Service
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<BookSeries> _bookSeriesRepository;

        public BookService(IRepository<Book> bookRepository,
            IRepository<BookSeries> bookSeriesRepository)
        {
            _bookRepository = bookRepository;
            _bookSeriesRepository = bookSeriesRepository;
        }

        public IEnumerable<Book> GetBooks()
        {
            return _bookRepository.GetAll();
        }

        public Book GetBook(int id)
        {
            return _bookRepository.Get(id);
        }

        public void InsertBook(Book book)
        {
            _bookRepository.Insert(book);
        }

        public void UpdateBook(Book book)
        {
            _bookRepository.Update(book);
        }

        public void DeleteBook(int id)
        {
            var bookSeries = _bookSeriesRepository.Get(id);
            _bookSeriesRepository.Delete(bookSeries);

            var user = _bookRepository.Get(id);
            _bookRepository.Delete(user);
            _bookRepository.SaveChanges();
        }
    }
}