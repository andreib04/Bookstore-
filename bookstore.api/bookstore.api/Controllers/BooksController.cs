using bookstore.api.Models;
using bookstore.api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace bookstore.api.Controllers
{
	[Controller]
	[Route("/api/[controller]")]
	public class BooksController : ControllerBase
	{
		private readonly IBookService _bookService;

		public BooksController(IBookService bookService)
		{
			_bookService = bookService;
		}

		[HttpGet]
		[AllowAnonymous]
		public ActionResult GetAllBooks()
		{
			try
			{
				var books = _bookService.GetAllBooks();
				return new OkObjectResult(books);
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
		public ActionResult GetBook(int id)
		{
			try
			{
				var books = _bookService.GetBook(id);
				return new OkObjectResult(books);
			}
			catch(KeyNotFoundException e)
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
		public  ActionResult PostBook([FromBody] Book book)
		{
			try
			{
				var dbBook = _bookService.PostBook(book);
				return new OkObjectResult(dbBook);
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

		[HttpPut("{id}")]
		[Authorize(Policy = "Admin")]
		public ActionResult EditBook(int id, [FromBody] Book book)
		{
			try
			{
				_bookService.EditBook(id, book);
				return new NoContentResult();
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
		public  ActionResult DeleteBook(int id)
		{
			try
			{
				Book dbBook = _bookService.DeleteBook(id);
				return new OkObjectResult(dbBook);
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
