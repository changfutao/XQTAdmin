using System.Linq.Expressions;

namespace System.Linq.Expressions
{
    /// <summary>
    /// IQueryable扩展类
    /// </summary>
    public static class QueryableExtensions
    {
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, bool>> predicate)
        {
            return condition ? query.Where(predicate) : query;
        }

        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, int, bool>> predicate)
        {
            return condition ? query.Where(predicate) : query;
        }

        public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> query, bool condition, Func<T, bool> predicate)
        {
            return condition ? query.Where(predicate) : query;
        }

        public static IOrderedQueryable<T> SortBy<T>(this IQueryable<T> query, Expression<Func<T, string>> sortField, string sort)
        {
            if (sort.Equals("desc", StringComparison.OrdinalIgnoreCase))
            {
                return query.OrderByDescending(sortField);
            }
            else
            {
                return query.OrderBy(sortField);
            }
        }
    }
}
