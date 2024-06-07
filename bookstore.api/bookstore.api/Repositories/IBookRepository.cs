using bookstore.api.Models;

namespace bookstore.api.Repositories
{
	public interface IBookRepository
	{
		List<Book> GetAllBooks();
		Book GetBook(int id);
		Book PostBook(Book book);
		void EditBook(int id, Book book);
		Book DeleteBook(int id);
	}
}
