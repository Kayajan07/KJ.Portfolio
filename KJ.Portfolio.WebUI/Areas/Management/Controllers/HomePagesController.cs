using KB.ABZ.WebUi.Utils;
using KJ.Portfolio.Web.Ui.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KJ.Portfolio.WebUI.Models;
using System.Threading.Tasks;

namespace KJ.Portfolio.WebUI.Areas.Management.Controllers
{
    [Area("Management"), Authorize]
    public class HomePagesController : Controller
    {
        private readonly PortfolioDbContext _context;
        private readonly IWebHostEnvironment _env;

        public HomePagesController(PortfolioDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _context.HomePages.FirstOrDefaultAsync();

            if (model is null)
            {
                model = new HomePage
                {
                    Id = Guid.NewGuid(),
                };
                await _context.HomePages.AddAsync(model);
                await _context.SaveChangesAsync();
            }

            return View(model);
        }

        public async Task<IActionResult> Edit()
        {
            var model = await _context.HomePages.FirstOrDefaultAsync();

            if (model is null)
                return RedirectToAction(nameof(Index));

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            HomePage model, 
            IFormFile? heroImage, 
            IFormFile? aboutImage, 
            IFormFile? EducationImage)
        {


            if (ModelState.IsValid)
            {
                if(heroImage != null)
                {
                    if (!string.IsNullOrWhiteSpace(model.HeroImageUrl))
                        await FileUploader.DeleteAsync(_env, model.HeroImageUrl);

                    model.HeroImageUrl = await FileUploader.UploadAsync(_env, heroImage);
                }

                if (aboutImage != null)
                {
                    if (!string.IsNullOrWhiteSpace(model.AboutImageUrl))
                        await FileUploader.DeleteAsync(_env, model.AboutImageUrl);

                    model.AboutImageUrl = await FileUploader.UploadAsync(_env, aboutImage);
                }

                if (EducationImage != null)
                {
                    if (!string.IsNullOrWhiteSpace(model.EducationImageUrl))
                        await FileUploader.DeleteAsync(_env, model.EducationImageUrl);

                    model.EducationImageUrl = await FileUploader.UploadAsync(_env, EducationImage);
                }



                _context.HomePages.Update(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}
