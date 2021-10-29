using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CQRS.Domain.Wrappers;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Domain.Extensions
{
    public static class DataPagerExtension
    {
        public static async Task<PagedModel<TModel>> PaginateAsync<TModel>(
            this IQueryable<TModel> query,
            int page,
            int limit,
            CancellationToken cancellationToken)
            where TModel : class
        {

            var paged = new PagedModel<TModel>();

            page = (page < 0) ? 1 : page;

            paged.PageNumber = page;
            paged.PageSize = limit;

            var totalItemsCountTask = query.CountAsync(cancellationToken);

            var startRow = (page - 1) * limit;
            paged.Items = await query
                       .Skip(startRow)
                       .Take(limit)
                       .ToListAsync(cancellationToken);

            paged.TotalCount = await totalItemsCountTask;
            paged.TotalPages = (int)Math.Ceiling(paged.TotalCount / (double)limit);

            return paged;
        }
    }
}