using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CLOUD_POE_Part2.Models
{
	public class Admin : IdentityUser
	{
		public string? AdminUsername { get; set; }
		public string? AdminPassword { get; set; }

		public List<Product> Products { get; set; } = new List<Product>();
	}
}
