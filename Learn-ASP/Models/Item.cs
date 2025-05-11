﻿namespace Learn_ASP.Models
{
	public class Item
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public double Price { get; set; }
		public int? SerialNumberID { get; set; }
		public SerialNumber? SerialNumber { get; set; }
	}
}
