namespace BestShop.Domain.Contracts.Users;
public interface IUserRepository : IGenericRepository<User>
{
	User? GetUserByEmail(string email);
	bool IsEmailExist(string email);
	User? GetUserByUserName(string userName);
	bool IsUserNameExist(string userName);
}
