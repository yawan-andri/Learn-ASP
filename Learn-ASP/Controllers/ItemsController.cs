using Learn_ASP.Data;
using Learn_ASP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Learn_ASP.Controllers
{
	public class ItemsController : Controller
	{
		private readonly LearnASPContext _context;
		public ItemsController(LearnASPContext context)
		{
			_context = context;
		}
		public async Task<IActionResult> Index()
		{
			var items = await _context.Items.ToListAsync();
			return View(items);
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create([Bind("Id, Name, Price")] Item item)
		{
			if (ModelState.IsValid)
			{
				_context.Add(item);
				await _context.SaveChangesAsync();
				return RedirectToAction("Index");
			} 
			return View(item);
		}
		public async Task<IActionResult> Edit(int id)
		{
			var item = await _context.Items.FirstOrDefaultAsync(i => i.Id == id);
			return View(item);
		}
		[HttpPost]
		public async Task<IActionResult> Edit(int id, [Bind("Id, Name, Price")] Item item)
		{
			if (ModelState.IsValid)
			{
				_context.Update(item);
				await _context.SaveChangesAsync();
				return RedirectToAction("Index");
			}
			return View(item);
		}
		public async Task<IActionResult> Delete(int id)
		{
			var item = await _context.Items.FirstOrDefaultAsync(i => i.Id == id);
			return View(item);
		}
		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var item = await _context.Items.FindAsync(id);
			if(item != null)
			{
				_context.Items.Remove(item);
				await _context.SaveChangesAsync();
			}
			return RedirectToAction("Index");
		}
	}
}
