using SendGrid;
using SendGrid.Helpers.Mail;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KJ.Portfolio.WebUI.Models;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace KJ.Portfolio.WebUI.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly PortfolioDbContext _context;

        public HomeController(PortfolioDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _context
                .HomePages
                .Include(x=>x.WhatIKnowCards)
                //.Include(x=>x.TechnologiesCards)
               
                .Include(x=>x.Experiences)
                .Include(x=>x.ExperienceListItems)
                .FirstOrDefaultAsync();

            var cats = await _context
                .PortfolioCategories
                .AsNoTracking()
                .Include(x => x.Items)
                .ThenInclude(x => x.Tags)
                .ToListAsync();

            model.Categories = cats;

            return View(model);
        }
        

        [HttpPost]
        public async Task<IActionResult> SendMessage(
string name,
string email,
string subject,
string message)
        {
            try
            {
                SmtpClient smtp = new SmtpClient
                {
                    Credentials = new NetworkCredential("contact@kayajanc.com", "Kayajan2302385"),
                    Host = "mail.kayajanc.com",
                    Port = 587,
                    EnableSsl = true
                };

                // 1. Kullanıcının mesajı contact@kayajanc.com'a gönder
                MailMessage mailToContact = new MailMessage
                {
                    From = new MailAddress("contact@kayajanc.com"),
                    Subject = subject,
                    Body = $"Gönderen: {name}\nEmail: {email}\nMesaj: {message}",
                    IsBodyHtml = false
                };
                mailToContact.To.Add("contact@kayajanc.com");
                smtp.Send(mailToContact);

                // 2. Aynı mesajı sadece kayajancetinkaya007@gmail.com'a gönder
                MailMessage forward = new MailMessage
                {
                    From = new MailAddress("contact@kayajanc.com"),
                    Subject = subject,
                    Body = mailToContact.Body, // birebir contact mesajı
                    IsBodyHtml = false
                };
                forward.To.Add("kayajancetinkaya007@gmail.com");
                smtp.Send(forward);

                // 3. Kullanıcıya sadece teşekkür mesajı gönder
                MailMessage autoReply = new MailMessage
                {
                    From = new MailAddress("contact@kayajanc.com"),
                    Subject = "Thank you for your message!",
                    Body = $"Hi {name},\n\n" +
                           "I have received your message sent to contact@kayajanc.com. " +
                           "I will get back to you as soon as possible.\n\n" +
                           "Best regards,\nKayajanc ",
                    IsBodyHtml = false
                };
                autoReply.To.Add(email);
                smtp.Send(autoReply);

                return Json(new { success = true, message = "Your message has been sent successfully." });
            }
            catch (SmtpFailedRecipientException)
            {
                // Kullanıcı maili yanlışsa uyarı
                return Json(new { success = false, message = "The email address you provided could not be found." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"An error occurred: {ex.Message}" });
            }
        }
        //78F9UZULYY2L76XY9ZPT4J2B sendgrid kodu
    }
}
