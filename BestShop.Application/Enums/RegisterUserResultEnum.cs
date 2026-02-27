namespace BestShop.Application.Enums;
public enum RegisterUserResultEnum
{
	Success,
	InvalidInput,
	EmailDuplicated,
	UserNameDuplicated,
	SendActivationEmail,
	Failed
}
