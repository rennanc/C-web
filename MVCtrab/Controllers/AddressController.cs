using MVCtrab.DAL;
using MVCtrab.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Web.Mvc;

namespace MVCtrab.Controllers
{
    public class AddressController : Controller
    {
        //conexão com Banco
        private DefaultConnection db = new DefaultConnection();

        // GET: Phone
        public ActionResult Index()
        {
            return View();
        }

        #region CRIAR
        // GET: /Address/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Address/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCostumer, Local")]Address address)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Address.Add(address);
                    db.SaveChanges();
                    //return RedirectToAction("Index");
                    return RedirectToAction("Index", "Costumer");
                }
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Falha ao salvar mudanças. Tente Novamente, se o problema persistir contate o administrador.");
            }
            return View(address);
        } 
        #endregion

        #region DELETAR
        // GET: /Address/Delete/5
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
            Address address = db.Address.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // POST: /Address/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Address address = db.Address.Find(id);
                db.Address.Remove(address);
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
            Address address = db.Address.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // POST: /Phone/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, IdCostumer, Local")]Address address)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //pega os estados modificados
                    db.Entry(address).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", "Costumer");
                }
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Falha ao salvar mudanças. Tente Novamente, se o problema persistir contate o administrador.");
            }
            return View(address);
        }
        #endregion
    }
}