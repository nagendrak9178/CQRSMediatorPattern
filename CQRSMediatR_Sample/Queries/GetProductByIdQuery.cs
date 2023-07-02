using MediatR;

namespace CQRSMediatR_Sample.Queries
{
    //Here "id" is the input parameter to GetProductByIdQuery class and returns the output "Product" from using "IRequest"
    public record GetProductByIdQuery(int id): IRequest<Product>;
}
