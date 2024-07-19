using SalesPro.Entities;

namespace SalesPro.Interfaces
{
    public interface IQueryProvider<T>
        where T : BaseEntityWithId
    {
        public Task<QueryResult<T>> GetResult();
    }

    public class QueryResult<T>
        where T : BaseEntityWithId
    {
        public QueryResult(IList<T>? records, long totalCount)
        {
            Records = records;
            TotalCount = totalCount;
        }

        public IList<T>? Records { get; init; }

        public long TotalCount { get; init; }
    }
}