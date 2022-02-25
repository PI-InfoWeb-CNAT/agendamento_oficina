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
using Microsoft.AspNet.Identity;

namespace oficinadomarcio.Controllers
{
    [Authorize(Roles = "ADMIN,MECANICO")]
    public class AgendamentosController : Controller
    {
        private EFContext db = new EFContext();

        // GET: Agendamentos
        public ActionResult Index()
        {
            var agendamento = db.agendamento.Include(a => a.Cliente).Include(a => a.Horario).Include(a => a.Veiculo);
            return View(agendamento.ToList());
        }

        // GET: Agendamentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agendamento agendamento = db.agendamento.Find(id);
            if (agendamento == null)
            {
                return HttpNotFound();
            }
            return View(agendamento);
        }

        // GET: Agendamentos/Create
        [AllowAnonymous]
        public ActionResult Create()
        {
            string currentUserId = User.Identity.GetUserId();
            ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);

            ViewBag.CpfCliente = new SelectList(db.cliente, "Cpf", "Nome");
            ViewBag.HorarioId = new SelectList(db.horario, "Id", "Hora");
            ViewBag.PlacaVeiculo = new SelectList(db.veiculo, "Placa", "Marca");

            if (User.IsInRole("CLIENTE")) ViewBag.PlacaVeiculo = new SelectList(db.veiculo.Where(v => v.CpfCliente == currentUser.Cpf), "Placa", "Marca");

            return View();
        }

        // POST: Agendamentos/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Titulo,Descricao,Data_agendamento,HorarioId,CpfCliente,PlacaVeiculo")] Agendamento agendamento)
        {
            if (ModelState.IsValid)
            {
                db.agendamento.Add(agendamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            string currentUserId = User.Identity.GetUserId();
            ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);

            ViewBag.CpfCliente = new SelectList(db.cliente, "Cpf", "Nome", agendamento.CpfCliente);
            ViewBag.HorarioId = new SelectList(db.horario, "Id", "Hora", agendamento.HorarioId);
            ViewBag.PlacaVeiculo = new SelectList(db.veiculo, "Placa", "Marca", agendamento.PlacaVeiculo);

            if (User.IsInRole("CLIENTE")) ViewBag.PlacaVeiculo = new SelectList(db.veiculo.Where(v => v.CpfCliente == currentUser.Cpf), "Placa", "Marca", agendamento.PlacaVeiculo);

            return View(agendamento);
        }

        // GET: Agendamentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agendamento agendamento = db.agendamento.Find(id);
            if (agendamento == null)
            {
                return HttpNotFound();
            }
            ViewBag.CpfCliente = new SelectList(db.cliente, "Cpf", "Nome", agendamento.CpfCliente);
            ViewBag.HorarioId = new SelectList(db.horario, "Id", "Hora", agendamento.HorarioId);
            ViewBag.PlacaVeiculo = new SelectList(db.veiculo, "Placa", "Marca", agendamento.PlacaVeiculo);
            return View(agendamento);
        }

        // POST: Agendamentos/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titulo,Descricao,Data_agendamento,HorarioId,CpfCliente,PlacaVeiculo")] Agendamento agendamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agendamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CpfCliente = new SelectList(db.cliente, "Cpf", "Nome", agendamento.CpfCliente);
            ViewBag.HorarioId = new SelectList(db.horario, "Id", "Hora", agendamento.HorarioId);
            ViewBag.PlacaVeiculo = new SelectList(db.veiculo, "Placa", "Marca", agendamento.PlacaVeiculo);
            return View(agendamento);
        }

        // GET: Agendamentos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agendamento agendamento = db.agendamento.Find(id);
            if (agendamento == null)
            {
                return HttpNotFound();
            }
            return View(agendamento);
        }

        // POST: Agendamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Agendamento agendamento = db.agendamento.Find(id);
            db.agendamento.Remove(agendamento);
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
