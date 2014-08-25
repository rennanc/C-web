using MVCtrab.DAL;
using MVCtrab.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using MVCtrab.Models;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Data.Entity;

namespace MVCtrab.Controllers
{
    public class CostumerController : Controller
    {
        //conexão com Banco
        private DefaultConnection db = new DefaultConnection();

        public ActionResult Index(int? id)
        {
            var viewModel = new CostumerIndexData();

            if (id != null)
            {
                ViewBag.CostumerId = id.Value;
                viewModel.Costumers = db.Costumers.Where(x => x.Id == id.Value);
                viewModel.Phones = db.Phones.Where(x => x.IdCostumer == id.Value);
                viewModel.Adress = db.Address.Where(y => y.IdCostumer == id.Value);
            }
            else
                viewModel.Costumers = db.Costumers;

            return View(viewModel);
        }

        #region CRIAR
        // GET: /Costumer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Costumer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name, Branch, Owner")]Costumer costumer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Costumers.Add(costumer);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Falha ao salvar mudanças. Tente Novamente, se o problema persistir contate o administrador.");
            }
            return View(costumer);
        } 
        #endregion

        #region EDITAR
        // GET: /Costumer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                //retorna pagina de erro de badRequest
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Costumer costumer = db.Costumers.Find(id);
            if (costumer == null)
            {
                return HttpNotFound();
            }
            return View(costumer);
        }

        // POST: /Costumer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Name, Branch, Owner")]Costumer costumer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(costumer).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                ModelState.AddModelError("", "Falha ao salvar mudanças. Tente Novamente, se o problema persistir contate o administrador.");
            }
            return View(costumer);
        } 
        #endregion

        #region DELETAR
        // GET: /Costumer/Delete/5
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
            Costumer costumer = db.Costumers.Find(id);
            if (costumer == null)
            {
                return HttpNotFound();
            }
            return View(costumer);
        }

        // POST: /Costumer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Costumer costumer = db.Costumers.Find(id);
                db.Costumers.Remove(costumer);
                db.SaveChanges();
            }
            catch (RetryLimitExceededException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        } 
        #endregion

        #region Paginas para Renderizar com AJAX
        public PartialViewResult _PhoneRender(int? id)
        {
            var viewModel = new CostumerIndexData();
            if (id != null)
            {
                viewModel.Phones = db.Phones.Where(x => x.IdCostumer == id.Value);
            }
            return PartialView(viewModel);
        }

        public PartialViewResult _AddressRender(int? id)
        {
            var viewModel = new CostumerIndexData();
            if (id != null)
            {
                viewModel.Adress = db.Address.Where(x => x.IdCostumer == id.Value);
            }
            return PartialView(viewModel);
        }

        public PartialViewResult _CostumerRender(int? id)
        {
            var viewModel = new CostumerIndexData();
            if (id != null)
            {
                viewModel.Costumers = db.Costumers.Where(x => x.Id == id.Value);
            }
            return PartialView(viewModel);
        } 
        #endregion

    }
}