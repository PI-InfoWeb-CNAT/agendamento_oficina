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
    public class AgendamentosController : Controller
    {
        private EFContext db = new EFContext();

        // GET: Agendamentos
        [Route("Admin/Agendamentos")]
        public ActionResult Index()
        {
            var agendamento = db.agendamento.Include(a => a.Horario);
            return View(agendamento.ToList());
        }

        // GET: Agendamentos/Details/5
        [Route("Admin/Agendamentos/Details/{id}")]
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
        [Route("Agendamentos/Create")]
        public ActionResult Create()
        {
            ViewBag.HorarioId = new SelectList(db.horario, "Id", "Hora");
            return View();
        }

        // POST: Agendamentos/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Agendamentos/Create")]
        public ActionResult Create([Bind(Include = "Id,Titulo,Descricao,Data_agendamento,Data_servico,HorarioId")] Agendamento agendamento)
        {
            if (agendamento.Data_servico == null)
            {
                ViewBag.HorarioId = new SelectList(db.horario, "Id", "Hora", agendamento.HorarioId);
                return View(agendamento);
            }

            if (ModelState.IsValid)
            {
                var horario = db.horario.SingleOrDefault(h => h.Id == agendamento.HorarioId);
                var hora = new TimeSpan(int.Parse(horario.Hora.Split(':')[0]), int.Parse(horario.Hora.Split(':')[1]), 0);
                agendamento.Data_servico += hora;

                db.agendamento.Add(agendamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HorarioId = new SelectList(db.horario, "Id", "Hora", agendamento.HorarioId);
            return View(agendamento);
        }

        // GET: Agendamentos/Edit/5
        [Route("Admin/Agendamentos/Edit/{id}")]
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
            ViewBag.HorarioId = new SelectList(db.horario, "Id", "Hora", agendamento.HorarioId);
            return View(agendamento);
        }

        // POST: Agendamentos/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Admin/Agendamentos/Edit/{id}")]
        public ActionResult Edit([Bind(Include = "Id,Titulo,Descricao,Data_agendamento,Data_servico,HorarioId")] Agendamento agendamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agendamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HorarioId = new SelectList(db.horario, "Id", "Hora", agendamento.HorarioId);
            return View(agendamento);
        }

        // GET: Agendamentos/Delete/5
        [Route("Admin/Agendamentos/Delete/{id}")]
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
        [Route("Admin/Agendamentos/Delete/{id}")]
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
