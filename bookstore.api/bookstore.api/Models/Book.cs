﻿namespace bookstore.api.Models
{
	public class Book
	{
		public int Id { get; set; }
		public string Title { get; set; } = null!;
		public string Author { get; set; } = null!;
		public string Description { get; set; } = null!;
		public string Category { get; set; } = null!;

		public double Price { get; set; }
		public byte[] Image { get; set; } = null!;
	}
}
