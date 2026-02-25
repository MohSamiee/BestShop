namespace BestShop.Domain.Enums;
public enum RegisterUserResultEnum
{
	Success,
	InvalidInput,
	EmailDuplicated,
	UserNameDuplicated,
	SendActivationEmail,
	Failed
}
