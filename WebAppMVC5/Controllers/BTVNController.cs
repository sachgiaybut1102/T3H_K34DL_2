using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppMVC5.Controllers
{
    public class BTVNController : Controller
    {
        // GET: BTVN
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TamGiac()
        {
            return View();
        }
    }
}