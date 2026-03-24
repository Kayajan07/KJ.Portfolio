using KJ.Portfolio.Web.Ui.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KJ.Portfolio.WebUI.Models;
using System.Threading.Tasks;

namespace KJ.Portfolio.WebUI.Areas.Management.Controllers
{
    [Area("Management"), Authorize(Roles = "Admin,MasterAdmin")]
    public class PortfolioCategoriesController : Controller
    {
        private readonly PortfolioDbContext _context;

        public PortfolioCategoriesController(PortfolioDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context
                .PortfolioCategories
                .AsNoTracking()
                .ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PortfolioCategory model)
        {
            if (ModelState.IsValid)
            {
                model.Id = Guid.NewGuid();
                await _context.PortfolioCategories.AddAsync(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var tag = await _context
                .PortfolioCategories
                .FindAsync(id);

            //var tag = await _context
            //    .PortfolioCategories
            //    .Where(x=>x.Id == id)
            //    .Include(x => x.Items)
            //    .FirstOrDefaultAsync();

            if (tag is null)
                return Json(new { success = false, message = "Kategori bulunamadı!" });

            await _context
                .Entry(tag)
                .Collection(x => x.Items)
                .LoadAsync();

            if (tag.Items != null && tag.Items.Count > 0)
                return Json(new { success = false, message = "Önce kategorinin portfolio ile ilişkisini silin!" });

            _context.PortfolioCategories.Remove(tag);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Kategori silindi." });
        }

    }
}
