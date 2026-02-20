using BestShop.Domain.Models.Common;

namespace BestShop.Domain.Models.Users;
public class UserAddress : BaseEntity<Guid>
{

	#region Constructor
	//
	#endregion Constructor

	#region Properties
	public required string Title { get; set; }
	public required string PostalCode { get; set; }
	public required string Address { get; set; }
	public required int UserId { get; set; }

	#endregion Properties

	#region Relations
	public User User { get; set; }
	#endregion Relations
}
