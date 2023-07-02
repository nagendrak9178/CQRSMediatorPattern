using MediatR;

namespace CQRSMediatR_Sample.Commands
{
    //Here IRequest  have a return type "Product". But it also accept input parameter "Product".
    public record AddProductCommand(Product product) : IRequest<Product>;
}
