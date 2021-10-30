using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppMVC5.Models;

namespace WebAppMVC5.Controllers
{
    public class OutputController : Controller
    {
        // GET: Output
        public ActionResult Index()
        {
            return View();
        }


        //Action trả về 1 chuỗi
        public ActionResult TextPlain()
        {
            return Content("Xin chào các em, anh đứng từ sáng!");
        }

        //Action trả về nội dung của 1 File
        public ActionResult ContentFile()
        {
            return File("~/Global.asax.cs", "text/plain");
        }

        //Action trả về một trang khác
        //Có thể chỉ định nghĩa actionName nếu cùng Controller
        //còn khác Controller thì phải khai báo cả actionName và controllerName
        public ActionResult GoToHome()
        {
            return RedirectToAction("index", "home");
        }

        //Action trả về 1 trang url
        public ActionResult GoToGoogle()
        {
            return Redirect("htt://google.com");
        }

        //Action trả về dữ liệu kiểu Json
        public ActionResult GetMails()
        {
            List<MailInfo> mailInfos = new List<MailInfo>();
            mailInfos.Add(new MailInfo() { To = "email12332@gmail.com", Subject = "Test mail 1", Content = "Đây là để test mail tự động." });
            mailInfos.Add(new MailInfo() { To = "minhsaothe1102@gmail.com", Subject = "Test mail 2", Content = "Chào bạn cho mình làm quen!" });
            mailInfos.Add(new MailInfo() { To = "sachigaybut1103@gmail.com", Subject = "Test mail 3", Content = "Hello, how are u?" });

            return Json(mailInfos, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Mail()
        {
            List<MailInfo> mailInfos = new List<MailInfo>();
            mailInfos.Add(new MailInfo() { To = "email12332@gmail.com", Subject = "Test mail 1", Content = "Đây là để test mail tự động." });
            mailInfos.Add(new MailInfo() { To = "minhsaothe1102@gmail.com", Subject = "Test mail 2", Content = "Chào bạn cho mình làm quen!" });
            mailInfos.Add(new MailInfo() { To = "sachigaybut1103@gmail.com", Subject = "Test mail 3", Content = "Hello, how are u?" });

            return View(mailInfos);
        }
    }
}