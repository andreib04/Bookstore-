using bookstore.api.Models;

namespace bookstore.api.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly DatabaseContext _databaseContext;

		public UserRepository(DatabaseContext databaseContext)
		{
			_databaseContext = databaseContext;
		}

		public List<User> GetAllUsers()
		{
			return _databaseContext.Users.ToList();
		}

		public User GetUser(int id)
		{
			var user = _databaseContext.Users.FirstOrDefault(u => u.Id == id);

			if (user == null)
			{
				throw new Exception($"User with id {id} does not exists");
			}

			return user;
		}

		public User PostUser(User user)
		{
			_databaseContext.Users.Add(user);
			_databaseContext.SaveChanges();

			return user;
		}

		public void EditUser(int id, User user)
		{
			var dbUser = _databaseContext.Users.FirstOrDefault(u => u.Id ==id);

			if(dbUser == null)
			{
				throw new Exception($"User with id {id} does not exists");
			}

			dbUser.Name = user.Name;
			dbUser.Email = user.Email;
			dbUser.Password = user.Password;

			_databaseContext.SaveChanges();
		}

		public User DeleteUser(int id)
		{
			var dbUser = _databaseContext.Users.FirstOrDefault(u => u.Id == u.Id);

			if(dbUser == null)
			{
				throw new Exception($"User with id {id} does not exists");
			}

			_databaseContext.Users.Remove(dbUser);
			_databaseContext.SaveChanges();

			return dbUser;
		}
	}
}
