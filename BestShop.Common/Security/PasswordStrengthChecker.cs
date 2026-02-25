using BestShop.Common.OperationResult;
using BestShop.Common.Resources;
using Microsoft.Extensions.Options;
using System.Text.RegularExpressions;

namespace BestShop.Common.Security;
public class PasswordStrengthChecker
{


	public PasswordCheckResult Check(PasswordPolicyOptions passwordPolicy, string password, string passwordField = "Password")
	{
		var result = new PasswordCheckResult();
		if (string.IsNullOrWhiteSpace(password))
		{
			result.Errors.Add(ModelStateError.MakeModelStateError(passwordField, PropertyDictionary.PasswordCantBeEmpty));
			return result;
		}

		if (password.Length < passwordPolicy.MinLength)
			result.Errors.Add(ModelStateError.MakeModelStateError(passwordField, string.Format(PropertyDictionary.GnMinLengthErrorMessage, PropertyDictionary.Password, passwordPolicy.MinLength)));

		if (passwordPolicy.RequireUppercase && !Regex.IsMatch(password, "[A-Z]"))
			result.Errors.Add(ModelStateError.MakeModelStateError(passwordField, PropertyDictionary.PasswordMustContainUpperCase));

		if (passwordPolicy.RequireLowercase && !Regex.IsMatch(password, "[a-z]"))
			result.Errors.Add(ModelStateError.MakeModelStateError(passwordField, PropertyDictionary.PasswordMustContainLowerCase));

		if (passwordPolicy.RequireDigit && !Regex.IsMatch(password, "[0-9]"))
			result.Errors.Add(ModelStateError.MakeModelStateError(passwordField, PropertyDictionary.PasswordMustContainDigit));

		if (passwordPolicy.RequireSpecialCharacter && !Regex.IsMatch(password, "[^a-zA-Z0-9]"))
			result.Errors.Add(ModelStateError.MakeModelStateError(passwordField, PropertyDictionary.PasswordMustContainSpecialChar));


		result.IsValid = result.Errors.Count == 0;
		result.Score = CalculateScore(passwordPolicy, password);

		return result;
	}
	private int CalculateScore(PasswordPolicyOptions passwordPolicy, string password)
	{
		int score = 0;
		if (passwordPolicy.MinLength <= password.Length) score++;
		if (passwordPolicy.RequireUppercase && Regex.IsMatch(password, "[A-Z]")) score++;
		if (passwordPolicy.RequireLowercase && Regex.IsMatch(password, "[a-z]")) score++;
		if (passwordPolicy.RequireDigit && Regex.IsMatch(password, "[0-9]")) score++;
		if (passwordPolicy.RequireSpecialCharacter && Regex.IsMatch(password, "[^a-zA-Z0-9]")) score++;
		return score;
	}

	public class PasswordCheckResult
	{
		public bool IsValid { get; set; }
		public int Score { get; set; }
		public List<ModelStateError> Errors { get; set; } = new();
	}
}
