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

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            return _db.GetAllProducts().ToList(); // Get all products
        }
        [HttpGet("Products/{category}/{rating}")]
        public ActionResult<IEnumerable<Product>>GetCategoryRating(Category category, int rating)
        {
            var result = _db.GetAllProducts();
            var match = result.Where(x => x.ProductCategory == category && x.Rating == rating).ToList();
            return Ok(rating);
         
        }
        [HttpGet("Products/{min}/{max}")]
        public ActionResult<IEnumerable<Product>>GetProductPriceRange(double min, double max)
        {
            var result = _db.GetAllProducts();
            var priceRange = result.Where(x=>x.ProductPrice>=min && x.ProductPrice<=max);
            return Ok(priceRange);
        }
    }
}

//(2) Add in an RestAPI controller called ProductsContoller that will provide the following operations on request:
//1.Return a list of products for a specified category and a specified rating
//2. Return a list of products for a specified price range (i.e. allow the user to specify a
//min and max price)
//Implement an appropriate URI addressing scheme for the service and its operations (i.e. define appropriate URL’s to route to your controller actions
