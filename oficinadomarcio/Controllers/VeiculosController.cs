using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using oficinadomarcio.Context;
using oficinadomarcio.Models;

namespace oficinadomarcio.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class VeiculosController : Controller
    {
        private EFContext db = new EFContext();

        // GET: Veiculos
        public ActionResult Index()
        {
            var veiculo = db.veiculo.Include(v => v.Cliente);
            return View(veiculo.ToList());
        }

        // GET: Veiculos/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veiculo veiculo = db.veiculo.Include(v => v.Cliente).SingleOrDefault(v => v.Placa == id);
            if (veiculo == null)
            {
                return HttpNotFound();
            }
            return View(veiculo);
        }

        // GET: Veiculos/Create
        [AllowAnonymous]
        public ActionResult Create()
        {
            ViewBag.CpfCliente = new SelectList(db.cliente, "Cpf", "Nome");
            return View();
        }

        // POST: Veiculos/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Create([Bind(Include = "Placa,Marca,Modelo,Ano")] Veiculo veiculo)
        {
            if (User.IsInRole("CLIENTE"))
            {
                string currentUserId = User.Identity.GetUserId();
                ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);

                veiculo.CpfCliente = currentUser.Cpf;
            }

            if (ModelState.IsValid)
            {
                db.veiculo.Add(veiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CpfCliente = new SelectList(db.cliente, "Cpf", "Nome", veiculo.CpfCliente);

            return View(veiculo);
        }

        // GET: Veiculos/Edit/5
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
            ViewBag.CpfCliente = new SelectList(db.cliente, "Cpf", "Nome", veiculo.CpfCliente);
            return View(veiculo);
        }

        // POST: Veiculos/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Placa,Marca,Modelo,Ano,CpfCliente")] Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(veiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CpfCliente = new SelectList(db.cliente, "Cpf", "Nome", veiculo.CpfCliente);
            return View(veiculo);
        }

        // GET: Veiculos/Delete/5
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
