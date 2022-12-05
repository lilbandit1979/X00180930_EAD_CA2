using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using X00180930_EAD_CA2.Models;
using X00180930_EAD_CA2.Repository;

namespace X00180930_EAD_CA2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepository _db;
        public ProductController(IRepository db)
        {
            _db = db;
        }
        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            return _db.GetProduct(id);
        }

        [HttpGet("Product/all")]
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            return _db.GetAllProducts().ToList(); // Get all products
        }

        [HttpPost]
        public ActionResult<Product> CreateProduct(Product product) //working
        {
            _db.CreateProduct(product);
            return Ok();
        }

        [HttpGet("Products/{category}/{rating}")]
        public ActionResult<IEnumerable<Product>>GetCategoryRating(Category category, int rating)
        {
            var result = _db.GetAllProducts();
            var match = result.Where(x => x.ProductCategory == category && x.Rating == rating).ToList();
            return Ok(match);
         
        }
        [HttpGet("Products/{min}/{max}")]
        public ActionResult<IEnumerable<Product>>GetProductPriceRange(double min, double max)
        {
            var result = _db.GetAllProducts();
            var priceRange = result.Where(x=>x.ProductPrice>=min && x.ProductPrice<=max).Select(x => x.ProductName); ;
            return Ok(priceRange); //not working in swagger
        }
    }
}


