using MediatR;

namespace CQRSMediatR_Sample.Notifications
{
    //Here INotification is equivalent of "IRequest" of commands or Queries.
    public record ProductAddedNotification(Product product) : INotification;
}
