using System.ComponentModel.DataAnnotations.Schema;

namespace Learn_ASP.Models
{
	public class SerialNumber
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public int? ItemID { get; set; }
		[ForeignKey("ItemID")]
		public Item Item { get; set; }
	}
}
