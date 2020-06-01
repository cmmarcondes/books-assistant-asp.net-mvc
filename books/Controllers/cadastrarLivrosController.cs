using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using books.Models;

namespace books.Controllers
{
    public class cadastrarLivrosController : Controller
    {
        private contexto db = new contexto();

        // GET: cadastrarLivros
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NomeParam = String.IsNullOrEmpty(sortOrder) ? "Nome_Desc" : "";
            ViewBag.StatusParam = sortOrder == "Status" ? "Status_Desc" : "Status";
            var livros = from s in db.Livros
                         select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                livros = livros.Where(s => s.livroName.ToUpper().Contains(searchString.ToUpper()));
            }

            switch(sortOrder)
            {
                case "Nome_desc":
                    livros = livros.OrderByDescending(s => s.livroName);
                        break;
                case "Status":
                    livros = livros.OrderBy(s => s.livroStatus);
                    break;
                case "Status_Desc":
                    livros = livros.OrderByDescending(s => s.livroStatus);
                        break;
                default:
                    livros = livros.OrderBy(s => s.livroName);
                    break;
            }

            return View(db.Livros.ToList());
        }

        // GET: cadastrarLivros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cadastrarLivros cadastrarLivros = db.Livros.Find(id);
            if (cadastrarLivros == null)
            {
                return HttpNotFound();
            }
            return View(cadastrarLivros);
        }

        // GET: cadastrarLivros/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: cadastrarLivros/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LivroId,livroName,livroGenero,livroStatus")] cadastrarLivros cadastrarLivros)
        {
            if (ModelState.IsValid)
            {
                db.Livros.Add(cadastrarLivros);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cadastrarLivros);
        }

        // GET: cadastrarLivros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cadastrarLivros cadastrarLivros = db.Livros.Find(id);
            if (cadastrarLivros == null)
            {
                return HttpNotFound();
            }
            return View(cadastrarLivros);
        }

        // POST: cadastrarLivros/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LivroId,livroName,livroGenero,livroStatus")] cadastrarLivros cadastrarLivros)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cadastrarLivros).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cadastrarLivros);
        }

        // GET: cadastrarLivros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cadastrarLivros cadastrarLivros = db.Livros.Find(id);
            if (cadastrarLivros == null)
            {
                return HttpNotFound();
            }
            return View(cadastrarLivros);
        }

        // POST: cadastrarLivros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cadastrarLivros cadastrarLivros = db.Livros.Find(id);
            db.Livros.Remove(cadastrarLivros);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
