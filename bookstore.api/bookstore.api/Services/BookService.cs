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

		public List<Book> GetAllBooks()
		{
			return _bookRepository.GetAllBooks();
		}

		public Book GetBook(int id)
		{
			return _bookRepository.GetBook(id);
		}

		public Book PostBook(Book book)
		{
			return _bookRepository.PostBook(book);
		}
		public void EditBook(int id, Book book)
		{
			_bookRepository.EditBook(id, book);
		}
		public Book DeleteBook(int id)
		{
			return _bookRepository.DeleteBook(id);
		}
	}
}
