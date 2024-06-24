using bookstore.api.Models;

namespace bookstore.api.Services
{
	public interface ICategoryService
	{
		List<Category> GetAllCategories();
		Category GetCategory(int id);
		Category PostCategory(Category category);
		Category DeleteCategory(int id);
	}
}
