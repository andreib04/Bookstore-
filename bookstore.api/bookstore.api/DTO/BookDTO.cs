namespace bookstore.api.DTO
{
	public class BookDTO
	{
		public int Id { get; set; }
		public string Title { get; set; } = null!;
		public string Author { get; set; } = null!;
		public string Description { get; set; } = null!;
		public double Price { get; set; } 
		public IFormFile Image { get; set; } = null!;
	}
}
