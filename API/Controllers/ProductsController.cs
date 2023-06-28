using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        //New code after applying Repository Pattern.
        private readonly IProductRepository _repo;
        public ProductsController(IProductRepository repo)
        {           
            _repo = repo;           
        }  

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _repo.GetProductBrandsAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _repo.GetProductTypesAsync());
        }
        
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _repo.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _repo.GetProductByIdAsync(id);
        }

        

        /* //Old code before applying Repository Pattern.
        private readonly StoreContext _context;

        public ProductsController(StoreContext context)
        {           
            _context = context;           
        }

        //Synchronous Get Product Method
        [HttpGet]
        public ActionResult<List<Product>> GetProducts()
        {
            var products = _context.Products.ToList();
            return products;
        }

        //Asynchronous Get Product Method
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _context.Products.FindAsync(id);
        }
        */
    }
}