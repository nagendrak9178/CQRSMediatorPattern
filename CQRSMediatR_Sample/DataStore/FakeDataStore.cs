namespace CQRSMediatR_Sample.DataStore
{
    public class FakeDataStore
    {
        private static List<Product> _products;
        public FakeDataStore() {
            _products = new List<Product>
           {
               new Product {Id = 1, Name="Mouse"},
               new Product {Id = 2, Name="Keyboard"},
               new Product {Id = 3, Name="Cable"}
           };
        }
        /// <summary>
        /// Add single Product to the Products List
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task AddProduct(Product product)
        {
            _products.Add(product);
            await Task.CompletedTask;
        }

        /// <summary>
        /// Get All Products list
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> GetAllProducts() => await Task.FromResult(_products);

        public async Task<Product> GetProductByID(int productid) => await Task.FromResult(_products.SingleOrDefault(x => x.Id == productid));
        //public async Task<Product> GetProductByID(int productid)
        //{
        //    var product = _products.SingleOrDefault(x => x.Id == productid);
        //    product.UpdatedName= product.Name +"Updated";
        //    return await Task.FromResult(product);
        //}

        public async Task EventOccurred(Product product, string evt)
        {
            _products.Single(x => x.Id == product.Id).Name = $" {product.Name} event: {evt}";
            await Task.CompletedTask;
        }

    }
}
