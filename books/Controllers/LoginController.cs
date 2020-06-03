using books.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace books.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Authorize(Account account)
        {
            using(loginEntities db = new loginEntities())
            {
                var userDetails = db.Account.Where(x => x.name == account.name && x.password == account.password).FirstOrDefault();
                if(userDetails == null)
                {
                    account.loginError = "Wrong username or pass";
                    return View("Index", account);
                }
                else
                {
                    Session["id"] = userDetails.id;
                    return RedirectToAction("Index", "cadastrarLivros");
                }
            }
            return View();
        }
    }
}