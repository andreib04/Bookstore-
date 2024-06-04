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

		public async Task<List<Book>> GetAllBooks()
		{
			var books = await _databaseContext.Books.ToListAsync();

			return books;
		}

		public async Task<Book> GetBook(int id)
		{
			var books = await _databaseContext.Books.FirstOrDefaultAsync(book => book.Id == id);
			
			if(books == null)
			{
				throw new KeyNotFoundException($"Can not found book with id {id}");
			}

			return books;
		}

		public async Task<Book> PostBook(Book book)
		{
			await _databaseContext.Books.AddAsync(book);
			await _databaseContext.SaveChangesAsync();

			return book;
		}

		public async void EditBook(int id, Book book)
		{
			var dbBook = await _databaseContext.Books.FirstOrDefaultAsync(books => books.Id == id);

			if(dbBook == null)
			{
				throw new KeyNotFoundException($"Can not found book with id {id}");
			}

			dbBook.Title = book.Title;
			dbBook.Description = book.Description;
			dbBook.Author = book.Author;
			dbBook.Price = book.Price;

			await _databaseContext.SaveChangesAsync();
		}

		public async Task<Book> DeleteBook(int id)
		{
			var dbBook = await _databaseContext.Books.FirstOrDefaultAsync(books => books.Id == id);

			if (dbBook == null)
			{
				throw new KeyNotFoundException($"Can not found book with id {id}");
			}

		    _databaseContext.Books.Remove(dbBook);
			await _databaseContext.SaveChangesAsync();
			return dbBook;
		}
	}
}
