using bookstore.api.Models;

namespace bookstore.api.Services
{
	public interface IBookService
	{
		List<Book> GetAllBooks();
		Book GetBook(int id);
		Book PostBook(Book book);
		void EditBook(int id, Book book);
		Book DeleteBook(int id);
	}
}
