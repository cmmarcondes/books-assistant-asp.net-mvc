using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace books.Controllers
{
    public class NaoLidosController : Controller
    {
        // GET: NaoLidos
        public ActionResult Index()
        {
            return View();
        }
    }
}