using X00180930_EAD_CA2.Models;

namespace X00180930_EAD_CA2.Repository
{
    public interface IRepository
    {
            IEnumerable<Product> GetAllProducts();
            Product GetProduct(int id);
            void CreateProduct(Product product);
            void EditProduct(Product product );  
    }
}
