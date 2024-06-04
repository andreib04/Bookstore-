using bookstore.api.Models;
using bookstore.api.Repositories;

namespace bookstore.api.Services
{
	public class BookService : IBookService
	{
		private readonly IBookRepository _bookRepository;

		public BookService(IBookRepository bookRepository)
		{
			_bookRepository = bookRepository;
		}

		public async Task<List<Book>> GetAllBooks()
		{
			return await _bookRepository.GetAllBooks();
		}

		public async Task<Book> GetBook(int id)
		{
			return await _bookRepository.GetBook(id);
		}

		public async Task<Book> PostBook(Book book)
		{
			return await _bookRepository.PostBook(book);
		}
		public void EditBook(int id, Book book)
		{
			_bookRepository.EditBook(id, book);
		}
		public async Task<Book> DeleteBook(int id)
		{
			return await _bookRepository.DeleteBook(id);
		}
	}
}
