using bookstore.api.Models;
using bookstore.api.Repositories;

namespace bookstore.api.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;

		public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public List<User> GetAllUsers()
		{
			return _userRepository.GetAllUsers();
		}

		public User GetUser(int id)
		{
			return _userRepository.GetUser(id);
		}

		public User PostUser(User user)
		{
			return _userRepository.PostUser(user);
		}

		public void EditUser(int id, User user)
		{
			_userRepository.EditUser(id, user);
		}

		public User DeleteUser(int id)
		{
			return _userRepository.DeleteUser(id);
		}
	}
}
