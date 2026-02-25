using BestShop.Common.Generator;
using BestShop.Common.Security;
using BestShop.Common.ViewModels.Options;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;

namespace BestShop.Application.Services.Implementations;
public class AccountService : IAccountService
{
	private readonly PasswordPolicyOptions _passwordPolicy;
	private readonly IUserRepository _userRepository;

	public AccountService(
		IUserRepository userRepository,
		IOptions<PasswordPolicyOptions> passwordPolicy)
	{
		_passwordPolicy = passwordPolicy.Value;
		_userRepository = userRepository;
	}


	public async Task<OperationResult<User>> RegisterUserAsync(RegisterViewModel register)
	{
		var modelErrors = new List<ModelStateError>();

		#region Validate Model
		var validation = await ValidateRegisterModel(register);
		if (!validation.IsSuccess && validation.ModelStateErrors != null && validation.ModelStateErrors.Any())
		{
			return new OperationResult<User>(false, null!, "Somethings went wrong", modelErrors);
		}


		#endregion Validate Model

		#region Check Email
		var isEmailExist = _userRepository.IsEmailExist(register.Email);
		if (isEmailExist)
			modelErrors.Add(ModelStateError.MakeModelStateError("Email", PropertyDictionary.EmailIsDuplicated));
		#endregion Check Email

		#region Check UserName
		var isUserNameExist = _userRepository.IsUserNameExist(register.UserName);
		if (isUserNameExist)
			modelErrors.Add(ModelStateError.MakeModelStateError("UserName", PropertyDictionary.UserNameIsDuplicated));
		#endregion Check UserName

		if (modelErrors.Any())
			return new OperationResult<User>(false, null!, "Somethings went wrong", modelErrors);

		#region Check Password
		var passwordValidation = new PasswordStrengthChecker().Check(_passwordPolicy, register.Password, nameof(register.Password));

		if (!passwordValidation.IsValid)
			return new OperationResult<User>(false, null!, PropertyDictionary.GnSomethingWenWrong, passwordValidation.Errors);
		#endregion Check Password


		var registeredUser = RegisterViewModel.MapRegisterViewModelToUser(register);
		_userRepository.Add(registeredUser, true);

		return new OperationResult<User>(true, registeredUser, "Success");
	}

	public async Task<OperationResult<User>> ActivateAccount(string activationCode)
	{
		var user = _userRepository.GetUserByEmailActivationCode(activationCode);
		if (user == null)
			return new OperationResult<User>(false, user, PropertyDictionary.GnSomethingWenWrong);

		user.IsActive = true;
		user.IsEmailConfirmed = true;
		user.EmailActivationCode = NameGenerator.GenerateUniqueName();
		_userRepository.Update(user, true);
		return new OperationResult<User>(true, user, "");
	}



	#region Private
	private async Task<OperationResult<bool>> ValidateRegisterModel(object model)
	{
		var validations = new List<ValidationResult>();
		var errors = new List<ModelStateError>();
		if (model == null)
			return new OperationResult<bool>(false, false, PropertyDictionary.GnSomethingWenWrong, ModelStateError.MakeModelStateError("", PropertyDictionary.GnSomethingWenWrong));

		var context = new ValidationContext(model);
		var res = Validator.TryValidateObject(
			model,
			context,
			validations,
			validateAllProperties: true
		);
		if (res)
			return new OperationResult<bool>(true, true, "");

		foreach (var item in validations)
		{
			foreach (var err in item.MemberNames)
			{
				errors.Add(ModelStateError.MakeModelStateError(err, item.ErrorMessage ?? ""));
			}
		}

		return new OperationResult<bool>(false, false, PropertyDictionary.GnSomethingWenWrong, errors);
	}
	#endregion Private
}