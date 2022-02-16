using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using oficinadomarcio.Context;
using oficinadomarcio.Models;

namespace oficinadomarcio.Controllers
{
    public class MecanicosController : Controller
    {
        private EFContext db = new EFContext();

        // GET: Mecanicos
        public ActionResult Index()
        {
            return View(db.mecanico.ToList());
        }

        // GET: Mecanicos/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mecanico mecanico = db.mecanico.Find(id);
            if (mecanico == null)
            {
                return HttpNotFound();
            }
            return View(mecanico);
        }

        // GET: Mecanicos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mecanicos/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Cpf,Nome,Telefone,Email,Senha")] Mecanico mecanico)
        {
            if (ModelState.IsValid)
            {
                db.mecanico.Add(mecanico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mecanico);
        }

        // GET: Mecanicos/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mecanico mecanico = db.mecanico.Find(id);
            if (mecanico == null)
            {
                return HttpNotFound();
            }
            return View(mecanico);
        }

        // POST: Mecanicos/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Cpf,Nome,Telefone,Email,Senha")] Mecanico mecanico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mecanico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mecanico);
        }

        // GET: Mecanicos/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mecanico mecanico = db.mecanico.Find(id);
            if (mecanico == null)
            {
                return HttpNotFound();
            }
            return View(mecanico);
        }

        // POST: Mecanicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Mecanico mecanico = db.mecanico.Find(id);
            db.mecanico.Remove(mecanico);
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
