using CQRSMediatR_Sample.DataStore;
using CQRSMediatR_Sample.Notifications;
using MediatR;

namespace CQRSMediatR_Sample.Handlers
{
    public class EmailHandler : INotificationHandler<ProductAddedNotification>
    {
        private readonly FakeDataStore _fakeDataStore;
        public EmailHandler(FakeDataStore fakeDataStore)
        {
            _fakeDataStore = fakeDataStore;
        }
        public async Task Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
        {
            await _fakeDataStore.EventOccurred(notification.product, "Emai Sent");
            await Task.CompletedTask;
        }

    }
}
