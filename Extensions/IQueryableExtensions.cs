using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace projekt.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> ApplyOrdering<T>(this IQueryable<T> query, IQueryObject queryObject,Dictionary<string, Expression<Func<T, object>>> map)
        {
            if (String.IsNullOrWhiteSpace(queryObject.SortBy) ||!map.ContainsKey(queryObject.SortBy))
            {
                return query;
            }

            if (queryObject.isSortAscending)
                return query.OrderBy(map[queryObject.SortBy]);
            else
                return query.OrderByDescending(map[queryObject.SortBy]);
        }

        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, IQueryObject queryObject) 
        {
            if (queryObject.PageSize <= 0)
                queryObject.PageSize = 10;
            if (queryObject.Page <= 0)
                queryObject.Page = 1;

            return query.Skip((queryObject.Page - 1) * queryObject.PageSize).Take(queryObject.PageSize);
        }
    }
}