using KB.ABZ.WebUi.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KJ.Portfolio.WebUI.Models;
using KJ.Portfolio.WebUI.Models.Entities;
using System.Threading.Tasks;

namespace KJ.Portfolio.WebUI.Areas.Management.Controllers
{
    [Area("Management"), Authorize]
    public class ExperiencesController : Controller
    {
        private readonly PortfolioDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ExperiencesController(PortfolioDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context
                .Experiences
                .AsNoTracking()
                .ToListAsync());
        }

        public async Task<IActionResult> Detail(Guid id)
        {
            var member = await _context
                .Experiences
                .FindAsync(id);

            if (member is null)
                return RedirectToAction(nameof(Index));

            return View(member);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Experience model, IFormFile? img)
        {
            model.Id = Guid.NewGuid();
            model.HomePageId = _context.HomePages.First().Id;

            if (ModelState.IsValid)
            {
                if (img is not null)
                    model.ImageUrl = await FileUploader.UploadAsync(_env, img);

                await _context
                    .Experiences
                    .AddAsync(model);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    
        public async Task<IActionResult> Edit(Guid id)
        {
            var member = await _context
                .Experiences
                .FindAsync(id);

            if(member is null)
                return RedirectToAction(nameof(Index));

            return View(member);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Experience model, IFormFile? img)
        {
            if (ModelState.IsValid)
            {
                if(img is not null)
                {
                    if (!string.IsNullOrWhiteSpace(model.ImageUrl))
                        await FileUploader.DeleteAsync(_env, model.ImageUrl);

                    model.ImageUrl = await FileUploader.UploadAsync(_env, img);
                }

                _context.Experiences.Update(model);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var member = await _context
                .Experiences
                .FindAsync(id);

            if (member is null)
                return Json(new { success = false, message = "Çalışan bulunamadı!" });

            _context.Experiences.Remove(member);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Çalışan silindi!" });

        }
    }
}
