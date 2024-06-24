using bookstore.api.Models;

namespace bookstore.api.Repositories
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly DatabaseContext _dbContext;

		public CategoryRepository(DatabaseContext dbContext) 
		{
			_dbContext = dbContext;
		}

		public List<Category> GetAllCategories()
		{
			var category = _dbContext.Categories.ToList();

			return category;
		}

		public Category GetCategory(int id)
		{
			var category = _dbContext.Categories.FirstOrDefault(cat => cat.Id == id);

			if(category == null)
			{
				throw new KeyNotFoundException($"Can not found category with id {id}");
			}

			return category;
		}

		public Category PostCategory(Category category)
		{
			_dbContext.Categories.Add(category);
			_dbContext.SaveChanges();

			return category;
		}
		
		public Category DeleteCategory(int id)
		{
			var dbCategory = _dbContext.Categories.FirstOrDefault(cat => cat.Id == id);

			if (dbCategory == null)
			{
				throw new KeyNotFoundException($"Can not found category with id {id}");
			}

			_dbContext.Categories.Remove(dbCategory);
			_dbContext.SaveChanges();
			return dbCategory;
		}
	}
}
