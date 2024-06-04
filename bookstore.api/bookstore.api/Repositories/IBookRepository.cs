using bookstore.api.Models;

namespace bookstore.api.Repositories
{
	public interface IBookRepository
	{
		Task<List<Book>> GetAllBooks();
		Task<Book> GetBook(int id);
		Task<Book> PostBook(Book book);
		void EditBook(int id, Book book);
		Task<Book> DeleteBook(int id);
	}
}
