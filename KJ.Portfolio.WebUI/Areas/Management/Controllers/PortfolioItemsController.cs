using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;
using KJ.Portfolio.WebUI.Models;
using KJ.Portfolio.WebUI.Models.Entities;
using System.Threading.Tasks;

namespace KJ.Portfolio.WebUI.Areas.Management.Controllers
{
    [Area("Management"), Authorize]
    public class PortfolioItemsController : Controller
    {
        private readonly PortfolioDbContext _context;

        public PortfolioItemsController(PortfolioDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _context
                .PortfolioItems
                .AsNoTracking()
                .Include(x => x.Category)
                .ToListAsync();

            return View(model);
        }

        public async Task<IActionResult> Detail(Guid id)
        {
            var model = await _context
                .PortfolioItems
                .AsNoTracking()
                .Where(x => x.Id == id)
                .Include(x => x.Category)
                .Include(x => x.Tags)
                .FirstOrDefaultAsync();

            if (model is null)
                return RedirectToAction(nameof(Index));

            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            var categories = await _context
                .PortfolioCategories
                .ToListAsync();

            if (categories is null)
                return RedirectToAction("Index", "PortfolioCategories");

            ViewData["Categories"] = new SelectList(categories, "Id", "Name");

            var tags = await _context
                .PortfolioTags
                .ToListAsync();

            ViewData["Tags"] = tags;

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PortfolioItem model, List<Guid>? selectedTags)
        {
            if (ModelState.IsValid)
            {
                model.Id = Guid.NewGuid();

                var tgs = await _context
                    .PortfolioTags
                    .Where(x => selectedTags.Contains(x.Id))
                    .ToListAsync();

                model.Tags = tgs;

                //model.Tags.AddRange(tgs);

                //foreach (var item in selectedTags)
                //{
                //    var tag = _context.PortfolioTags.Find(item);
                //    model.Tags.Add(tag);
                //}

                await _context.PortfolioItems.AddAsync(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var categories = await _context
                .PortfolioCategories
                .ToListAsync();

            ViewData["Categories"] = new SelectList(categories, "Id", "Name", model.CategoryId);

            var tags = await _context
                .PortfolioTags
                .ToListAsync();

            ViewData["Tags"] = tags;

            ViewData["SelectedTags"] = selectedTags;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var model = await _context
                .PortfolioItems
                .Where(x => x.Id == id)
                .Include(x => x.Category)
                .Include(x => x.Tags)
                .FirstOrDefaultAsync();

            if (model is null)
                return Json(new { success = false, mesasge = "Veri bulunamadı" });

            _context.PortfolioItems.Remove(model);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "veri silindi" });
        }

        public async Task<IActionResult> Update(Guid id)
        {
            var model = await _context
                .PortfolioItems
                .Where(x => x.Id == id)
                .Include(x => x.Category)
                .Include(x => x.Tags)
                .FirstOrDefaultAsync();

            if (model is null)
                return RedirectToAction(nameof(Index));

            var categories = await _context
                .PortfolioCategories
                .AsNoTracking()
                .ToListAsync();

            ViewData["Categories"] = new SelectList(categories, "Id", "Name", model.CategoryId);

            ViewData["Tags"] = await _context
                .PortfolioTags
                .AsNoTracking()
                .ToListAsync();

            ViewData["SelectedTags"] = model.Tags?.Select(x => x.Id).ToList();

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(PortfolioItem model, List<Guid> selectedTags)
        {
            if (ModelState.IsValid)
            {
                var edited = await _context
                    .PortfolioItems
                    .Where(x => x.Id == model.Id)
                    .Include(x => x.Category)
                    .Include(x => x.Tags)
                    .FirstOrDefaultAsync();

                //edited.Category = null;
                edited.CategoryId = model.CategoryId;

                var tgs = edited.Tags?.ToList();
                var inclueded = tgs.Where(x => selectedTags.Contains(x.Id)).ToList();

                var exclueded = tgs.Where(x => !selectedTags.Contains(x.Id)).ToList();
                foreach (var item in exclueded)
                {
                    edited.Tags.Remove(item);
                }

                var newTgs = selectedTags.Where(x => !inclueded.Any(y => y.Id == x)).ToList();
                var newTags = await _context
                    .PortfolioTags
                    .Where(x => newTgs.Any(y => y == x.Id))
                    .ToListAsync();

                if (newTags != null && newTags.Count > 0)
                    edited.Tags.AddRange(newTags);

                _context.Entry(edited).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }

            var categories = await _context
             .PortfolioCategories
             .AsNoTracking()
             .ToListAsync();

            ViewData["Categories"] = new SelectList(categories, "Id", "Name", model.CategoryId);

            ViewData["Tags"] = await _context
               .PortfolioTags
               .AsNoTracking()
               .ToListAsync();

            ViewData["SelectedTags"] = selectedTags;

            return View(model);
        }
    }
}
