﻿namespace CLOUD_POE_Part2.Models
{
	public class OrderItem
	{
		public int OrderItemID { get; set; }
		public int OrderID { get; set; }
		public Order? Order { get; set; }
		public int ProductID { get; set; }
		public Product? Product { get; set; }
		public int quantity { get; set; }
		public decimal Price { get; set; }
	}
}
