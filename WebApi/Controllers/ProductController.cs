using Application.Interfaces.Services.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _services;

        public ProductController(IProductServices services)
        {
            _services = services;
        }

        [HttpGet]
        [Route("GetProducts")]
        
        public async Task<IActionResult> Get()
        {
            var list = await _services.GetAll();

            return Ok(list);
        }


    }
}
