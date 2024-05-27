using Microsoft.AspNetCore.Identity;

namespace CLOUD_POE_Part2.Models
{
	public class Customer : IdentityUser
	{
		public int CustomerID { get; set; }
		public string? CustomerUsername { get; set; }
		public string? CustiomerPassword { get; set; }
	}
}
