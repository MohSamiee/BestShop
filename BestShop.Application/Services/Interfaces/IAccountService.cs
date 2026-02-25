namespace BestShop.Application.Services.Interfaces;
public interface IAccountService
{
	Task<OperationResult<User>> RegisterUserAsync(RegisterViewModel register);
	Task<OperationResult<User>> ActivateAccount(string activationCode);
}
  