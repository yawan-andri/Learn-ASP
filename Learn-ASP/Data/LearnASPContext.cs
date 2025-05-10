using Learn_ASP.Models;
using Microsoft.EntityFrameworkCore;

namespace Learn_ASP.Data
{
	public class LearnASPContext : DbContext
	{
		public LearnASPContext(DbContextOptions<LearnASPContext> options) : base(options) { }
		public DbSet<Item> Items { get; set; }
	}
}
