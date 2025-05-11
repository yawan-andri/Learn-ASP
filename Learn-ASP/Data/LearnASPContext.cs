using Learn_ASP.Models;
using Microsoft.EntityFrameworkCore;

namespace Learn_ASP.Data
{
	public class LearnASPContext : DbContext
	{
		public LearnASPContext(DbContextOptions<LearnASPContext> options) : base(options) { }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
		public DbSet<Item> Items { get; set; }
		public DbSet<SerialNumber> serialNumbers { get; set; }
	}
}
