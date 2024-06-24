using bookstore.api.Models;

namespace bookstore.api.Repositories
{
	public interface ICategoryRepository
	{
		List<Category> GetAllCategories();
		Category GetCategory(int id);
		Category PostCategory(Category category);	
		Category DeleteCategory(int id);
	}
}
