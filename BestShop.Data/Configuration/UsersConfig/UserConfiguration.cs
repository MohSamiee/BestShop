using BestShop.Domain.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BestShop.Data.Configuration.UsersConfig;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{
		builder.HasKey(k => k.Id);
		builder.Property(p => p.FirstName).IsRequired(false).HasMaxLength(200);
		builder.Property(p => p.LastName).IsRequired(false).HasMaxLength(200);
		builder.Property(p => p.UserName).IsRequired(false).HasMaxLength(200);
		builder.Property(p => p.NormalizedUserName).IsRequired(false).HasMaxLength(200);
		builder.Property(p => p.Email).IsRequired(false).HasMaxLength(200);
		builder.Property(p => p.NormalizedEmail).IsRequired(false).HasMaxLength(200);
		builder.Property(p => p.EmailActivationCode).IsRequired(false).HasMaxLength(50);
		builder.Property(p => p.IsEmailConfirmed).IsRequired(true).HasDefaultValue(false);
		builder.Property(p => p.HashedPassword).IsRequired(true).HasMaxLength(500);
		builder.Property(p => p.Mobile).IsRequired(false).HasMaxLength(20);
		builder.Property(p => p.MobileActivationCode).IsRequired(false).HasMaxLength(6);
		builder.Property(p => p.IsMobileConfirmed).IsRequired(true).HasDefaultValue(false);


		#region Relations
		builder.HasMany(u => u.UserAddresses)
			.WithOne(a => a.User)
			.HasForeignKey(a => a.UserId)
			.OnDelete(DeleteBehavior.Cascade);


		#endregion Relations
	}
}
