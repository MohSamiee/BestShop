namespace BestShop.Application.Services.Interfaces;
public interface IAccountService
{
	Task<OperationResult<User>> RegisterUserAsync(RegisterViewModel register);
}
  