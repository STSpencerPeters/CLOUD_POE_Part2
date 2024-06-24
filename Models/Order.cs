using Microsoft.AspNetCore.Identity;

namespace CLOUD_POE_Part2.Models
{
	public class Order
	{
		public int OrderID { get; set; }
		public DateTime OrderDate { get; set; }
		public string? CustomerID { get; set; }
		public Customer Customer { get; set; }
		public decimal TotalAmount { get; set; }

		public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
	}
}
