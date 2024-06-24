using bookstore.api.Models;
using bookstore.api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace bookstore.api.Controllers
{
	[Controller]
	[Route("/api/[controller]")]
	public class CategoriesController : ControllerBase
	{
		private readonly ICategoryService _categoryService;

		public CategoriesController(ICategoryService categoryService)
		{
			this._categoryService = categoryService;
		}

		[HttpGet]
		[AllowAnonymous]
		public ActionResult GetAllCategories()
		{
			try
			{
				var categories = _categoryService.GetAllCategories();
				return new OkObjectResult(categories);
			}
			catch
			{
				return new ObjectResult("Something went wrong!")
				{
					StatusCode = 500
				};
			}
		}

		[HttpGet("{id}")]
		[AllowAnonymous]
		public ActionResult GetCategory(int id)
		{
			try
			{
				var category = _categoryService.GetCategory(id);
				return new OkObjectResult(category);
			}
			catch (KeyNotFoundException e)
			{
				return new NotFoundObjectResult(e.Message);
			}
			catch
			{
				return new ObjectResult("Something went wrong!")
				{
					StatusCode = 500
				};
			}
		}

		[HttpPost]
		[Authorize(Policy = "Admin")]
		public ActionResult PostCategory([FromBody] Category category)
		{
			try
			{
				var dbCategory = _categoryService.PostCategory(category);
				return new OkObjectResult(dbCategory);
			}
			catch (KeyNotFoundException e)
			{
				return new NotFoundObjectResult(e.Message);
			}
			catch
			{
				return new ObjectResult("Something went wrong!")
				{
					StatusCode = 500
				};
			}
		}

		[HttpDelete]
		[Authorize(Policy = "Admin")]
		public ActionResult DeleteCategory(int id)
		{
			try
			{
				var category = _categoryService.DeleteCategory(id);
				return new OkObjectResult(category);
			}
			catch (KeyNotFoundException e)
			{
				return new NotFoundObjectResult(e.Message);
			}
			catch
			{
				return new ObjectResult("Something went wrong!")
				{
					StatusCode = 500
				};
			}
		}
	}
}
