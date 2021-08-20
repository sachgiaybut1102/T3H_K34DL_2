using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebAppMVC5.Models;

namespace WebAppMVC5.Controllers
{
    public class MailController : Controller
    {
        // GET: Mail
        public ActionResult Index()
        {
            ViewBag.Error = TempData["Error"];
            ViewBag.Success = TempData["Success"];
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Send(MailInfo mailInfo)
        {
            string userName = "t3heducation@gmail.com";
            string password = "T3h@123123";

            //Configuaration gmail
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 25)
            {
                Credentials = new NetworkCredential(userName, password),
                EnableSsl = true,
            };

            //Init Email
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(userName);
            mailMessage.To.Add(new MailAddress(mailInfo.To));
            mailMessage.Subject = mailInfo.Subject;
            mailMessage.Body = mailInfo.Content;

            //Send mail
            try
            {
                await smtpClient.SendMailAsync(mailMessage);
            }
            catch(Exception ex)
            {
                TempData["Error"] = "Có lỗi xảy ra, không thể gửi mail!\n" + ex.Message;

                return RedirectToAction("Index", mailInfo);
            }

            TempData["Success"] = "Gửi mail thành công ^^!";
             
            return RedirectToAction("Index");
        }
    }
}