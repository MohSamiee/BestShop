using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BestShop.Domain.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BestShop.Data.Configuration.UsersConfig;
public class UserAddressConfiguration:IEntityTypeConfiguration<UserAddress>
{
	public void Configure(EntityTypeBuilder<UserAddress> builder)
	{
		builder.HasKey(k => k.Id);
		builder.Property(p => p.Address).IsRequired(true).HasMaxLength(3000);
		builder.Property(p => p.Title).IsRequired(true).HasMaxLength(300);
		builder.Property(p => p.PostalCode).IsRequired(true).HasMaxLength(20);
		builder.HasOne(o => o.User).WithMany(m => m.UserAddresses).HasForeignKey(f => f.UserId);
	}
}
