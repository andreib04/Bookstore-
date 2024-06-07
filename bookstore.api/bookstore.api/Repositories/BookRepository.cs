using bookstore.api.Models;
using Microsoft.EntityFrameworkCore;

namespace bookstore.api.Repositories
{
	public class BookRepository : IBookRepository
	{
		private readonly DatabaseContext _databaseContext;

		public BookRepository(DatabaseContext databaseContext)
		{
			_databaseContext = databaseContext;
		}

		public  List<Book> GetAllBooks()
		{
			var books = _databaseContext.Books.ToList();

			return books;
		}

		public  Book GetBook(int id)
		{
			var books = _databaseContext.Books.FirstOrDefault(book => book.Id == id);
			
			if(books == null)
			{
				throw new KeyNotFoundException($"Can not found book with id {id}");
			}

			return books;
		}

		public Book PostBook(Book book)
		{
			_databaseContext.Books.Add(book);
			_databaseContext.SaveChanges();

			return book;
		}

		public void EditBook(int id, Book book)
		{
			var dbBook = _databaseContext.Books.FirstOrDefault(books => books.Id == id);

			if(dbBook == null)
			{
				throw new KeyNotFoundException($"Can not found book with id {id}");
			}

			dbBook.Title = book.Title;
			dbBook.Description = book.Description;
			dbBook.Author = book.Author;
			dbBook.Price = book.Price;

			_databaseContext.SaveChanges();
		}

		public Book DeleteBook(int id)
		{
			var dbBook = _databaseContext.Books.FirstOrDefault(books => books.Id == id);

			if (dbBook == null)
			{
				throw new KeyNotFoundException($"Can not found book with id {id}");
			}

		    _databaseContext.Books.Remove(dbBook);
			_databaseContext.SaveChanges();
			return dbBook;
		}
	}
}
