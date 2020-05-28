using books.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace books.Controllers
{
    public class LidosController : Controller
    {
        // GET: Lidos
        public ActionResult Index()
        {
            return View();
        }
        
    }
}