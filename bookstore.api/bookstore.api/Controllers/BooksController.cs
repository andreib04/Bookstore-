using bookstore.api.Models;
using bookstore.api.Services;
using Microsoft.AspNetCore.Mvc;

namespace bookstore.api.Controllers
{
	public class BooksController : ControllerBase
	{
		private readonly IBookService _bookService;

		public BooksController(IBookService bookService)
		{
			_bookService = bookService;
		}

		[HttpGet]
		public async Task<ActionResult> GetAllBooks()
		{
			try
			{
				var books = await _bookService.GetAllBooks();
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
		public async Task<ActionResult> GetBook(int id)
		{
			try
			{
				var books = await _bookService.GetBook(id);
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
		public async Task<ActionResult> PostBook([FromBody] Book book)
		{
			try
			{
				var dbBook = await _bookService.PostBook(book);
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
		public async Task<ActionResult> DeleteBook(int id)
		{
			try
			{
				Book dbBook = await _bookService.DeleteBook(id);
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
