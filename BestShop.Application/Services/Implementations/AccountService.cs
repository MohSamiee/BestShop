using System.ComponentModel.DataAnnotations;

namespace BestShop.Application.Services.Implementations;
public class AccountService(IUserRepository _userRepository) : IAccountService
{
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
		{
			return new OperationResult<User>(false, null!, "Somethings went wrong", modelErrors);
		}

		var registeredUser = RegisterViewModel.MapRegisterViewModelToUser(register);
		_userRepository.Add(registeredUser, true);

		return new OperationResult<User>(true, registeredUser, "Success");
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
