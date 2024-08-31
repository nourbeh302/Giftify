using Application.Common;
using Domain.Products;
using MediatR;
using SharedKernel;
using SharedKernel.Errors;
using System.Linq.Expressions;

namespace Application.Products.ListProducts;

public record ListProductsQuery(
    string? SearchTerm,
    int? PageSize,
    int? PageIndex) :
    IRequest<Result<PagedList<ProductResponse>, Error>>;

public class ListProductsQueryHandler(IProductRepository productRepository) :
    IRequestHandler<ListProductsQuery, Result<PagedList<ProductResponse>, Error>>
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task<Result<PagedList<ProductResponse>, Error>> Handle(ListProductsQuery request, CancellationToken cancellationToken)
    {
        int pageSize = request.PageSize ?? 4;
        int pageIndex = request.PageIndex ?? 1;

        IReadOnlyList<Product> products = await GetProducts(request, cancellationToken);

        IEnumerable<ProductResponse> productResponses = products
            .Select(p => new ProductResponse(
                Id: p.Id,
                Title: p.Title,
                Description: p.Description,
                Price: p.Price,
                AddedOnUtc: p.AddedOnUtc,
                Quantity: p.Quantity,
                Sku: p.Sku,
                Category: Enum.GetName(p.Category)!));

        PagedList<ProductResponse> pagedList = PagedList<ProductResponse>.Create(
            list: productResponses,
            pageSize: pageSize,
            pageIndex: pageIndex);

        return pagedList;
    }

    private async Task<IReadOnlyList<Product>> GetProducts(ListProductsQuery request, CancellationToken cancellationToken)
    {
        IReadOnlyList<Product> products;

        if (string.IsNullOrEmpty(request.SearchTerm))
        {
            products = await _productRepository.ListAsync(cancellationToken);
        }
        else
        {
            Expression<Func<Product, bool>> expression = p =>
                p.Sku.Contains(request.SearchTerm.ToLower()) ||
                p.Title.Contains(request.SearchTerm.ToLower()) ||
                p.Description.Contains(request.SearchTerm.ToLower());

            products = await _productRepository.FindAsync(expression, cancellationToken);
        }

        return products;
    }
}
