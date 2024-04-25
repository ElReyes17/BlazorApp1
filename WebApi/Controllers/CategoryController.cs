using Application.Interfaces.Services.Categories;
using Application.ViewModels.Categories;
using Application.ViewModels.Products;
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


        [HttpPost]
        [Route("PostCategory")]

        public async Task<IActionResult> Post([FromQuery] SaveCategoryViewModel vm)
        {

            await _services.Add(vm);

            return Ok();
        }

        [HttpPut]
        [Route("UpdateCategory/{id}")]

        public async Task<IActionResult> Update([FromQuery] SaveCategoryViewModel vm, int id)
        {

            await _services.Update(vm, id);

            return Ok();
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
