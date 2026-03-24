//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using KJ.Portfolio.WebUI.Models;
//using KJ.Portfolio.WebUI.Models.Entities;
//using System.Threading.Tasks;

//namespace KJ.Portfolio.WebUI.Areas.Management.Controllers
//{
//    [Area("Management"), Authorize]
//    public class TechnologiesCardsController : Controller
//    {
//        private readonly PortfolioDbContext _context;

//        public TechnologiesCardsController(PortfolioDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<IActionResult> Index()
//        {
//            return View(await _context
//                .TechnologiesCards
//                .ToListAsync());
//        }

//        public IActionResult Create()
//        {
//            return View();
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create(TechnologiesCard model)
//        {
//            if (ModelState.IsValid)
//            {
//                model.Id = Guid.NewGuid();
//                model.HomePageId = _context.HomePages.First().Id;
//                await _context.TechnologiesCards.AddAsync(model);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }

//            return View(model);
//        }

//        public async Task<IActionResult> Edit(Guid id)
//        {
//            var model = await _context.TechnologiesCards.FindAsync(id);

//            if (model is null)
//                return RedirectToAction(nameof(Index));

//            return View(model);
//        }

//        [HttpPost, ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(TechnologiesCard model)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.TechnologiesCards.Update(model);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }

//            return View(model);
//        }

//        [HttpPost]
//        public async Task<IActionResult> Delete(Guid id)
//        {
//            var model = await _context.TechnologiesCards.FindAsync(id);

//            if (model is null)
//                return Json(new { success = false, message = "Veri bulunamadı!" });

//            _context.TechnologiesCards.Remove(model);
//            await _context.SaveChangesAsync();

//            return Json(new { success = true, message = "Veri silindi." });
//        }
//    }
//}
