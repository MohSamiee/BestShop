namespace BestShop.Data.Repositories.Users;
public class UserRepository : GenericRepository<User>, IUserRepository
{
	private readonly BestShopContext _context;
	public UserRepository(BestShopContext context) : base(context)
	{
		_context = context;
	}

	public User? GetUserByEmail(string email)
	{
		var users = GetEntity(a => a.NormalizedEmail == email.Normalize());
		if (!users.Any())
			return null!;
		if (users.Count() > 1)
			return null!;
		var user = users.First();
		return user;
	}

	public bool IsEmailExist(string email)
	{
		var user = GetUserByEmail(email);
		if (user == null) return false;
		return true;
	}

	public User? GetUserByUserName(string userName)
	{
		var users = GetEntity(a => a.NormalizedUserName == userName.Normalize());
		if (!users.Any())
			return null!;
		if (users.Count() > 1)
			return null!;
		var user = users.First();
		return user;
	}

	public bool IsUserNameExist(string userName)
	{
		var user = GetUserByUserName(userName);
		if (user == null) return false;
		return true;
	}
}
