using System.Security.Cryptography;
public static class PasswordHasher
{
	private const int SaltSize = 16;       // 128 bit
	private const int KeySize = 32;        // 256 bit
	private const int Iterations = 100_000;
	private static readonly HashAlgorithmName Algorithm = HashAlgorithmName.SHA256;

	public static string Hash(this string password)
	{
		// تولید salt تصادفی
		byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);

		// تولید hash
		byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
			password,
			salt,
			Iterations,
			Algorithm,
			KeySize);

		// ترکیب salt + hash
		byte[] hashBytes = new byte[SaltSize + KeySize];
		Array.Copy(salt, 0, hashBytes, 0, SaltSize);
		Array.Copy(hash, 0, hashBytes, SaltSize, KeySize);

		// ذخیره به صورت Base64
		return Convert.ToBase64String(hashBytes);
	}

	public static bool Verify(string password, string storedHash)
	{
		byte[] hashBytes = Convert.FromBase64String(storedHash);

		// استخراج salt
		byte[] salt = new byte[SaltSize];
		Array.Copy(hashBytes, 0, salt, 0, SaltSize);

		// محاسبه hash جدید
		byte[] hashToCompare = Rfc2898DeriveBytes.Pbkdf2(
			password,
			salt,
			Iterations,
			Algorithm,
			KeySize);

		// مقایسه امن
		for (int i = 0; i < KeySize; i++)
		{
			if (hashBytes[i + SaltSize] != hashToCompare[i])
				return false;
		}

		return true;
	}
}