using CQRSMediatR_Sample.Commands;
using CQRSMediatR_Sample.DataStore;
using MediatR;

namespace CQRSMediatR_Sample.Handlers
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, Product>
    {
        private readonly FakeDataStore _fakeDataStore;
        public AddProductHandler(FakeDataStore fakeDataStore)
        {
            _fakeDataStore = fakeDataStore;
        }
        public async Task<Product> Handle(AddProductCommand request,CancellationToken cancellationToken)
        {
            //this "request.product " is the input parameter passed to "AddProductCommand" class.
             await Task.FromResult(_fakeDataStore.AddProduct(request.product));
            return request.product;
        }

       
    }
}
