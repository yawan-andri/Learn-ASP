using Learn_ASP.Models;
using Microsoft.EntityFrameworkCore;

namespace Learn_ASP.Data
{
	public class LearnASPContext : DbContext
	{
		public LearnASPContext(DbContextOptions<LearnASPContext> options) : base(options) { }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ItemClient>().HasKey(ic => new
			{
				ic.ItemId,
				ic.ClientId
			});

			modelBuilder.Entity<ItemClient>().HasOne(i => i.Item)
				.WithMany(ic => ic.ItemClients)
				.HasForeignKey(i => i.ItemId);

			modelBuilder.Entity<ItemClient>().HasOne(c => c.Client)
				.WithMany(ic => ic.ItemClients)
				.HasForeignKey(c => c.ClientId);

			modelBuilder.Entity<Item>().HasData(
				new Item { Id = 1, Name = "Keyboard", Price = 200000, SerialNumberID = 1 }
				);

			modelBuilder.Entity<SerialNumber>().HasData(
				new SerialNumber { Id=1, Name="KEY001", ItemID=1 }
				);

			modelBuilder.Entity<Category>().HasData(
				new Category { Id=1, Name="Electronics"},
				new Category { Id=2, Name="Books" }
				);

			base.OnModelCreating(modelBuilder);
		}
		public DbSet<Item> Items { get; set; }
		public DbSet<SerialNumber> serialNumbers { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Client> Clients { get; set; }
		public DbSet<ItemClient> ItemsClients { get; set; }
	}
}
