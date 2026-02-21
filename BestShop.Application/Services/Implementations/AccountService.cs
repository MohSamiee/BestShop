namespace BestShop.Application.Services.Implementations;
public class AccountService(IUserRepository _userRepository) : IAccountService
{
	public async Task<OperationResult<User>> RegisterUserAsync(RegisterViewModel register)
	{
		//Check

	}
}
