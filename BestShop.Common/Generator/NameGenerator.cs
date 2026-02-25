namespace BestShop.Common.Generator;
public static class NameGenerator
{
	public static string GenerateUniqueName()
	{
		var res = Guid.NewGuid().ToString("N");
		return res;
	}
}
