using DemoDotNetAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoDotNetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilterPaginSortingProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public FilterPaginSortingProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult GetAllProducts (string search, double? from, double? to, string sortBy, int page = 1) //clean codee thi ham ko nen > 3 tham so
        {
            try
            {
                var result = _productRepository.GetAll(search, from, to, sortBy, page);
                return Ok(result);

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
                //return BadRequest("We can't not get list products");
            }
        }

    }
}
