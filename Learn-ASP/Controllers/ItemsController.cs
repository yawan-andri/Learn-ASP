using Learn_ASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace Learn_ASP.Controllers
{
	public class ItemsController : Controller
	{
		public IActionResult Overview()
		{
			var item = new Item() { Name = "Keyboard" };
			return View(item);	
		}

		public IActionResult Edit(int id)
		{
			return Content("id = " + id);
		}
	}
}
