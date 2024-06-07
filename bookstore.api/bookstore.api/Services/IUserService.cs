using bookstore.api.Models;

namespace bookstore.api.Services
{
	public interface IUserService
	{
		List<User> GetAllUsers();
		User GetUser(int id);
		User PostUser(User user);
		void EditUser(int id, User user);
		User DeleteUser(int id);
	}
}
