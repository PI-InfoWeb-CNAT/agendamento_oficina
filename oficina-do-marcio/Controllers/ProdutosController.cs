using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using oficina_do_marcio.Context;
using oficina_do_marcio.Models;

namespace oficina_do_marcio.Controllers
{
    public class ProdutosController : Controller
    {
        private EFContext db = new EFContext();

        // GET: Produtos
        [Route("Produtos/Admin")]
        public ActionResult Index()
        {
            return View(db.produto.ToList());
        }

        // GET: Produtos/Details/5
        [Route("Produtos/Admin/Details/{id}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.produto.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Produtos/Create
        [Route("Produtos/Create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        [Route("Produtos/Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Marca,Descricao,Categoria,Quantidade")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.produto.Add(produto);
                db.SaveChanges();
                return RedirectToAction("Confirm");
            }

            return View(produto);
        }

        [Route("Produtos/Confirm")]
        public ActionResult Confirm()
        {
            return View();
        }

        // GET: Produtos/Edit/5
        [Route("Produtos/Admin/Edit/{id}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.produto.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Edit/5
        [Route("Produtos/Admin/Edit/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Marca,Descricao,Categoria,Quantidade")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produto);
        }

        // GET: Produtos/Delete/5
        [Route("Produtos/Admin/Delete/{id}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.produto.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Delete/5
        [Route("Produtos/Admin/Delete/{id}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produto produto = db.produto.Find(id);
            db.produto.Remove(produto);
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
