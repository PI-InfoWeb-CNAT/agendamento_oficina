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
    public class VeiculosController : Controller
    {
        private EFContext db = new EFContext();

        // GET: Veiculos
        [Route("Admin/Veiculos")]
        public ActionResult Index()
        {
            return View(db.veiculo.ToList());
        }

        // GET: Veiculos/Details/5
        [Route("Admin/Veiculos/Details/{id}")]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veiculo veiculo = db.veiculo.Find(id);
            if (veiculo == null)
            {
                return HttpNotFound();
            }
            return View(veiculo);
        }

        // GET: Veiculos/Create
        [Route("Admin/Veiculos/Create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Veiculos/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Admin/Veiculos/Create")]
        public ActionResult Create([Bind(Include = "Placa,Marca,Modelo,Ano")] Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                db.veiculo.Add(veiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(veiculo);
        }

        // GET: Veiculos/Edit/5
        [Route("Admin/Veiculos/Edit/{id}")]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veiculo veiculo = db.veiculo.Find(id);
            if (veiculo == null)
            {
                return HttpNotFound();
            }
            return View(veiculo);
        }

        // POST: Veiculos/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Admin/Veiculos/Edit/{id}")]
        public ActionResult Edit([Bind(Include = "Placa,Marca,Modelo,Ano")] Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(veiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(veiculo);
        }

        // GET: Veiculos/Delete/5
        [Route("Admin/Veiculos/Delete/{id}")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veiculo veiculo = db.veiculo.Find(id);
            if (veiculo == null)
            {
                return HttpNotFound();
            }
            return View(veiculo);
        }

        // POST: Veiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Admin/Veiculos/Delete/{id}")]
        public ActionResult DeleteConfirmed(string id)
        {
            Veiculo veiculo = db.veiculo.Find(id);
            db.veiculo.Remove(veiculo);
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
