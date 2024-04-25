using Application.Interfaces.Services.Categories;
using Application.ViewModels.Categories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServices _services;
        public CategoryController(ICategoryServices services)
        {
            _services = services;
        }

        [HttpGet]
        [Route("GetCategory")]
        public async Task<IActionResult> Get()
        {
            var list = await _services.GetAll();
            return Ok(list);
        }
        [HttpDelete]
        [Route("EraseCategories/{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            await _services.Delete(id);

            return Ok();
        }

    }
}
