namespace BestShop.Common.ViewModels.Options;
public class PasswordPolicyOptions
{
	public int MinLength { get; set; }
	public bool RequireUppercase { get; set; }
	public bool RequireLowercase { get; set; }
	public bool RequireDigit { get; set; }
	public bool RequireSpecialCharacter { get; set; }
}
