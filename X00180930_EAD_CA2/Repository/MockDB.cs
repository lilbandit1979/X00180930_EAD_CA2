using X00180930_EAD_CA2.Models;

namespace X00180930_EAD_CA2.Repository
{
    public class MockDB : IRepository
    {
        private static List<Product> _products = new List<Product>() {
            new Product {ProductID=0,ProductName="Hoodie",ProductPrice=24.99,Rating=4, ProductCategory=Category.Clothes,ProductSize=Size.M},
            new Product {ProductID=1,ProductName="Ball", ProductCategory=Category.Football,ProductPrice=49.99,Rating=3,ProductSize=Size.S},
         };

 
        public void CreateProduct(Product product)
        {
            _products.Add(product);
        }

        public void EditProduct(Product product)
        {
            var found = _products.FirstOrDefault(x => x.ProductID == product.ProductID);
            if(found != null)
            {
                found.ProductID = product.ProductID;
                found.ProductName = product.ProductName;
                found.ProductPrice=product.ProductPrice;
                found.ProductSize=product.ProductSize; 
                found.ProductCategory=product.ProductCategory;
                found.Rating=product.Rating;
            }
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _products;  
        }

        public Product GetProduct(int id)
        {
            var found = _products.FirstOrDefault(x => x.ProductID == id);
            if (found != null)
            {
                return found;
            }
            else throw new Exception("Product not found");
        }
        //public IEnumerable<Product> ProductCategoryRating(Category category, int rating)
        //{
        //    var found = _products.Where(x => x.ProductCategory == category && x.Rating == rating);
        //    if(found!=null)
        //    {
        //        return found;
        //    }
        //    throw new ArgumentException("Bad Request");
        //}
    }
}
