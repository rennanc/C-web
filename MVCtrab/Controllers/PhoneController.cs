using MVCtrab.DAL;
using MVCtrab.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVCtrab.Controllers
{
    public class PhoneController : Controller
    {
        //conexão com Banco
        private DefaultConnection db = new DefaultConnection();

        // GET: Phone
        public ActionResult Index()
        {
            return View();
        }

        #region CRIAR
        // GET: /Phone/Create
        public ActionResult Create()
        {
           return View();
        }

        // POST: /Phone/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCostumer, Telephone")]Phones phone)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Phones.Add(phone);
                    db.SaveChanges();
                    //return RedirectToAction("Index");
                    return RedirectToAction("Index", "Costumer");
                }
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Falha ao salvar mudanças. Tente Novamente, se o problema persistir contate o administrador.");
            }
            return View(phone);
        } 
        #endregion

        #region DELETAR
        // GET: /Phone/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Falha ao Deletar. Tente Novamente, se o problema persistir contate o administrador.";
            }
            Phones phone = db.Phones.Find(id);
            if (phone == null)
            {
                return HttpNotFound();
            }
            return View(phone);
        }

        // POST: /Phone/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Phones phone = db.Phones.Find(id);
                db.Phones.Remove(phone);
                db.SaveChanges();
            }
            catch (RetryLimitExceededException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index", "Costumer");
        }
        #endregion

        #region EDITAR
        // GET: /Phone/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phones phone = db.Phones.Find(id);
            if (phone == null)
            {
                return HttpNotFound();
            }
            return View(phone);
        }

        // POST: /Phone/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, IdCostumer, Telephone")]Phones phone)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(phone).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", "Costumer");
                }
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Falha ao salvar mudanças. Tente Novamente, se o problema persistir contate o administrador.");
            }
            return View(phone);
        } 
        #endregion
    }
}