using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KJ.Portfolio.WebUI.Models;
using KJ.Portfolio.WebUI.Models.Entities;
using System.Threading.Tasks;

namespace KJ.Portfolio.WebUI.Areas.Management.Controllers
{
    [Area("Management"), Authorize(Roles = "MasterAdmin")]
    public class PortfolioTagsController : Controller
    {
        private readonly PortfolioDbContext _context;

        public PortfolioTagsController(PortfolioDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context
                .PortfolioTags
                .AsNoTracking()
                .ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PortfolioTag model)
        {
            if (ModelState.IsValid)
            {
                model.Id = Guid.NewGuid();
                await _context.PortfolioTags.AddAsync(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var tag = await _context
                .PortfolioTags
                .FindAsync(id);

            //var tag = await _context
            //    .PortfolioTags
            //    .Where(x=>x.Id == id)
            //    .Include(x => x.Items)
            //    .FirstOrDefaultAsync();

            if (tag is null)
                return Json(new { success = false, message = "Etiket bulunamadı!" });

            await _context
                .Entry(tag)
                .Collection(x => x.Items)
                .LoadAsync();

            if (tag.Items != null && tag.Items.Count > 0)
                return Json(new { success = false, message = "Önce etiketin portfolio ile ilişkisini silin!" });

            _context.PortfolioTags.Remove(tag);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Etiket silindi." });
        }

    }
}
