using Microsoft.AspNetCore.Mvc;
using Product.API.Dtos;
using Product.API.Services;

namespace Product.API.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_productService.GetAll());
        }
        public IActionResult Get(int Id)
        {
            return Ok(_productService.Get(Id));
        }
        [HttpPost]
        public IActionResult Create(CreateProductDto dto)
        {
            
            return Ok(_productService.Create(dto));
        }
        [HttpPut]
        public IActionResult Update(UpdateProductDto dto)
        {
            return Ok($"this api should Update Product");
        }
        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            _productService.Delete(Id);
            return Ok("Deleted");
        }
    }
}
