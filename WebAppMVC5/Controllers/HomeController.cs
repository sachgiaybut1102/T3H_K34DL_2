using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppMVC5.Models;

namespace WebAppMVC5.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Helper()
        {
            List<MailInfo> mailInfos = new List<MailInfo>();

            mailInfos.Add(new MailInfo() { To = "minhsaothe1102@gmail.com", Subject = "Tiêu đề 1", Content = "Nội dung là TestJson1" });
            mailInfos.Add(new MailInfo() { To = "sachigaybut1103@gmail.com", Subject = "Tiêu đề 2", Content = "Nội dung là TestJson2" });
            mailInfos.Add(new MailInfo() { To = "sachigaybut1103@gmail.com", Subject = "Tiêu đề 3", Content = "Nội dung là TestJson3" });
            mailInfos.Add(new MailInfo() { To = "sachigaybut1103@gmail.com", Subject = "Tiêu đề 4", Content = "Nội dung là TestJson4" });
            mailInfos.Add(new MailInfo() { To = "sachigaybut1103@gmail.com", Subject = "Tiêu đề 5", Content = "Nội dung là TestJson5" });

            ViewBag.MailInfos = new SelectList(mailInfos, "To", "To");

            return View();
        }

        public ActionResult StudentRegister()
        {
            Student model = new Student()
            {
                DateOfBirth = new DateTime()
            };

            ViewBag.Gender = new SelectList(new object[]
            {
                new {Name = "Nam", Value = true},
                new {Name = "Nữ", Value = false}
            }, "Value", "Name");

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmStudentRegister(Student model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Gender = new SelectList(new object[]
                {
                    new {Name = "Nam", Value = true},
                    new {Name = "Nữ", Value = false}
                }, "Value", "Name", model.Gender);

                return View("StudentRegister", model);
            }

            return View();
        }

        public ActionResult TestJQuery()
        {
            return View();
        }
    }
}