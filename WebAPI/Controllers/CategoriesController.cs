using Business.Abstract;
using Business.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController] //attribute= it is properties

   
    public class CategoriesController : ControllerBase
    {
        ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet("getall")]
        //[Authorize(Roles = "admin")]
        public IActionResult GetAll()
        {
            Thread.Sleep(100);
            var result = _categoryService.GetAll();

            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

    }
}
