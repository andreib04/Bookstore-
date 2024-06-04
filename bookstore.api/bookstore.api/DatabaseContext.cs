﻿using bookstore.api.Models;
using Microsoft.EntityFrameworkCore;

namespace bookstore.api
{
	public class DatabaseContext : DbContext
	{
		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

		public DbSet<Book> Books { get; set; }
	}
}
