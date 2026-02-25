using System.ComponentModel.DataAnnotations;
namespace BestShop.Domain.ViewModels.Account;
public class RegisterViewModel
{
	[Display(Name = "UserName", ResourceType = typeof(PropertyDictionary))]
	[MaxLength(100, ErrorMessageResourceName = "GnMaxLengthErrorMessage", ErrorMessageResourceType = typeof(PropertyDictionary))]
	[Required(ErrorMessageResourceName = "GnRequiredErrorMessage", ErrorMessageResourceType = typeof(PropertyDictionary))]
	public string UserName { get; set; }


	[Display(Name = "Email", ResourceType = typeof(PropertyDictionary))]
	[MaxLength(100, ErrorMessageResourceName = "GnMaxLengthErrorMessage", ErrorMessageResourceType = typeof(PropertyDictionary))]
	[Required(ErrorMessageResourceName = "GnRequiredErrorMessage", ErrorMessageResourceType = typeof(PropertyDictionary))]
	[DataType(DataType.EmailAddress, ErrorMessageResourceName = "GnEmailFormatErrorMessage", ErrorMessageResourceType = typeof(PropertyDictionary))]
	public string Email { get; set; }


	[Display(Name = "Password", ResourceType = typeof(PropertyDictionary))]
	[Required(ErrorMessageResourceName = "GnRequiredErrorMessage", ErrorMessageResourceType = typeof(PropertyDictionary))]
	[DataType(DataType.Password)]
	public string Password { get; set; }


	[Display(Name = "RePassword", ResourceType = typeof(PropertyDictionary))]
	[Required(ErrorMessageResourceName = "GnRequiredErrorMessage", ErrorMessageResourceType = typeof(PropertyDictionary))]
	[DataType(DataType.Password)]
	[Compare(nameof(Password), ErrorMessageResourceName = "ComparePasswordErrorMessage", ErrorMessageResourceType = typeof(PropertyDictionary))]
	public string RePassword { get; set; }

	public static User MapRegisterViewModelToUser(RegisterViewModel vm)
	{
		var user = new User()
		{
			//Id = ,
			Guid = Guid.NewGuid(),
			CreatedDate = DateTime.Now,
			CreatedUserId = null,
			LastModifiedDate = null,
			LastModifiedUserId = null,
			Description = null,
			IsActive = false,
			IsDeleted = false,

			FirstName = null,
			LastName = null,
			Avatar = "DefaultAvatar.PNG",
			HashedPassword = vm.Password.Hash(),

			NormalizedUserName = vm.UserName.Normalize(),
			UserName = vm.UserName,


			Email = vm.Email,
			NormalizedEmail = vm.Email.Normalize(),
			IsEmailConfirmed = false,
			EmailActivationCode = NameGenerator.GenerateUniqueName(),
			ExpireEmailActivationCode = DateTime.Now.AddHours(2),

			Mobile = null,
			MobileActivationCode = null,
			IsMobileConfirmed = false,
			ExpireMobileActivationCode = null,

			LastLoginTime = null,
			AccessFailedCount = 0,
		};

		return user;
	}
}