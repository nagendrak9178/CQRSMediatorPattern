using MediatR;

namespace CQRSMediatR_Sample.Queries
{
    public record GetProductsQuery() : IRequest<IEnumerable<Product>>;
}
