using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using BestShop.Common.Resources;

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

}
