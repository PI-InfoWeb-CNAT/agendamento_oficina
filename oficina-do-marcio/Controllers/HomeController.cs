using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace oficina_do_marcio.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return Content("Sobre");
        }

        public ActionResult Contact()
        {
            return Content("Contato");
        }
    }
}