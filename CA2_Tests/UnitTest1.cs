using X00180930_EAD_CA2.Controllers;
using X00180930_EAD_CA2.Models;
using X00180930_EAD_CA2.Repository;

namespace CA2_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckCreate_IsWorking()
        {
            IRepository repo = new MockDB();
            ProductController pc = new ProductController(repo);
            Product newProduct = new Product
            {
                ProductID = 3,
                ProductName = "Boots",
                ProductPrice = 50.0,
                Rating = 4,
                ProductCategory = Category.Clothes,
                ProductSize = Size.S

            };
            pc.CreateProduct(newProduct);
            var exists = pc.GetProduct(3);
            Assert.IsNotNull(exists);
        }
    }
}
