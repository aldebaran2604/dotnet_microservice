using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.Models;
using ProductMicroservice.Repositories.Products;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        #region Properties

        private readonly IProductRepository _productRepository;

        #endregion

        #region Constructors

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        #endregion

        #region Methods

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            IEnumerable<Product> products = await _productRepository.GetProducts();
            return Ok(products);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetAsync(int id)
        {
            Product? product = await _productRepository.GetProductByID(id);
            return Ok(product);
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] Product product)
        {
            int changes = await _productRepository.InsertProduct(product);
            return Ok(changes);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<int>> Put([FromBody] Product product)
        {
            int changes = await _productRepository.UpdateProduct(product);
            return Ok(changes);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            int changes = await _productRepository.DeleteProduct(id);
            return Ok(changes);
        }

        #endregion
    }
}
