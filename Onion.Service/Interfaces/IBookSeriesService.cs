using Onion.Data.Entities;

namespace Onion.Service.Interfaces
{
    public interface IBookSeriesService
    {
        BookSeries GetBookSeries(int id);
    }
}