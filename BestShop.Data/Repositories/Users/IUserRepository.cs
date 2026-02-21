using BestShop.Data.Context;
using BestShop.Domain.Contracts.Users;
using BestShop.Domain.Models.Users;

namespace BestShop.Data.Repositories.Users;
public class UserRepository : GenericRepository<User>,IUserRepository
{
	public UserRepository(BestShopContext context) : base(context)
	{
	}
}
