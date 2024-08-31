using MediatR;

namespace Application.Common;

// This class is used for pagination purposes
public class PagedList<TEntity>
    where TEntity : class
{
    private PagedList(
        List<TEntity> items,
        int pageSize,
        int pageIndex,
        int totalCount)
    {
        Items = items;
        PageSize = pageSize;
        PageIndex = pageIndex;
        TotalCount = totalCount;
    }

    public List<TEntity> Items { get; }
    public int PageSize { get; }
    public int PageIndex { get; }
    public int TotalCount { get; }
    public bool HasNextPage => 
        PageIndex * PageSize < TotalCount && 
        TotalCount > 0;
    public bool HasPreviousPage => 
        PageIndex > 1 && 
        TotalCount > 0;

    public static PagedList<TEntity> Create(
        IEnumerable<TEntity> list,
        int pageSize,
        int pageIndex)
    {
        int totalCount = list.Count();

        List<TEntity> items = list
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        return new PagedList<TEntity>(items, pageSize, pageIndex, totalCount);
    }
}