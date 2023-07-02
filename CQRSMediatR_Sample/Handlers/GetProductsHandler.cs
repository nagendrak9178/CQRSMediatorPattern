using CQRSMediatR_Sample.DataStore;
using CQRSMediatR_Sample.Queries;
using MediatR;

namespace CQRSMediatR_Sample.Handlers
{
    public class GetProductsHandler: IRequestHandler<GetProductsQuery, IEnumerable<Product>> 
        // we need to implement this interface "IRequestHandler" with "Handle" method as follows
    {
        private readonly FakeDataStore _fakeDataStore;
        public GetProductsHandler(FakeDataStore fakeDataStore)
        {
            _fakeDataStore = fakeDataStore;
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
           return await _fakeDataStore.GetAllProducts();
        }
    }
}
