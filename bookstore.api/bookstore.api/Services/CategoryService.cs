using bookstore.api.Models;
using bookstore.api.Repositories;

namespace bookstore.api.Services
{
	public class CategoryService : ICategoryService
	{
		private readonly ICategoryRepository _categoryRepository;

		public CategoryService(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}

		public List<Category> GetAllCategories()
		{
			return _categoryRepository.GetAllCategories();
		}

		public Category GetCategory(int id)
		{
			return _categoryRepository.GetCategory(id);
		}

		public Category PostCategory(Category category)
		{
			return _categoryRepository.PostCategory(category);
		}

		public Category DeleteCategory(int id)
		{
			return _categoryRepository.DeleteCategory(id);
		}
	}
}
