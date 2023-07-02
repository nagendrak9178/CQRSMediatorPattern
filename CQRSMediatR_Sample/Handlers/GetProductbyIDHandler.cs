using CQRSMediatR_Sample.DataStore;
using CQRSMediatR_Sample.Queries;
using MediatR;

namespace CQRSMediatR_Sample.Handlers
{
    public class GetProductbyIDHandler: IRequestHandler<GetProductByIdQuery,Product>
    {
        private readonly FakeDataStore _fakeDataStore;
        public GetProductbyIDHandler(FakeDataStore fakeDataStore)
        { 
          _fakeDataStore = fakeDataStore;
        }

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
           return await _fakeDataStore.GetProductByID(request.id);
        }
    }
}
