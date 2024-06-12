using bookstore.api.Models;
using bookstore.api.Services;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace bookstore.api.Controllers
{
	[Controller]
	[Route("/api/[controller]")]
	public class UsersController : ControllerBase
	{
		private readonly IUserService _userService;
		private readonly AbstractValidator<User> _validator;

		public UsersController(IUserService userService, AbstractValidator<User> validator)
		{
			_userService = userService;
			_validator = validator;
		}

		[HttpGet]
		[Authorize(Policy = "Admin")]
		public ActionResult GetAllUsers()
		{
			try
			{
				var users = _userService.GetAllUsers();
				return new OkObjectResult(users);
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
		[Authorize(Policy = "Admin")]
		public ActionResult GetUser(int id)
		{
			try
			{
				var user = _userService.GetUser(id);
				return new OkObjectResult(user);
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
		[AllowAnonymous]
		public ActionResult PostUser([FromBody] User user)
		{
			try
			{
				var validation = _validator.Validate(user);

				if (!validation.IsValid)
				{
					return new BadRequestObjectResult(validation.Errors.Select(error => error.ErrorMessage));
				}

				var dbUser = _userService.PostUser(user);
				return new OkObjectResult(dbUser);
			}
			catch
			{
				return new ObjectResult("Something went wrong!")
				{
					StatusCode = 500
				};
			}
		}

		[HttpPut("{id}")]
		[Authorize(Policy = "Admin")]
		public ActionResult EditUser(int id, [FromBody] User user)
		{
			try
			{
				var validation = _validator.Validate(user);

				if(!validation.IsValid)
				{
					return new BadRequestObjectResult(validation.Errors.Select(error => error.ErrorMessage));
				}

				_userService.EditUser(id, user);
				return new OkObjectResult(true);
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

		[HttpDelete("{id}")]
		[Authorize(Policy = "Admin")]
		public ActionResult DeleteUser(int id)
		{
			try
			{
				var dbUser = _userService.DeleteUser(id);
				return new OkObjectResult(dbUser);
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
