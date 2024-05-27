using Microsoft.AspNetCore.Identity;

namespace CLOUD_POE_Part2.Models
{
	public class Product
	{
		public int ProductID { get; set; }
		public string? ProductName { get; set; }
		public string? ProductCategory { get; set; }
		public decimal? ProductPrice { get; set; }

		public string AdminID { get; set; }
		public Admin Admin { get; set; }

		public string? ProductImageUrl { get; set; }
	}
}
