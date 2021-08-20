using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppMVC5.Controllers
{
    public class HelloController : Controller
    {
        // GET: Hello
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SayHello()
        {
            ViewBag.Msg = "Đây là msg từ Action đến View lưu ở ViewBag";
            ViewData["Msg2"] = "Đây là msg từ Action đến View lưu ở ViewData";

            return View();
        }
    }
}