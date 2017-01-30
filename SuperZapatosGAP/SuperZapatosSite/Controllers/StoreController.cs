using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperZapatosSite.API;
using System.Web.Script.Serialization;
using SuperZapatosSite.Models;

namespace SuperZapatosSite.Controllers
{
    public class StoreController : Controller
    {
        public JavaScriptSerializer serializer = new JavaScriptSerializer();
        // GET: Store
        public ActionResult Index()
        {
            var storeResponse = new PluralStoreResponse();
            var response = SuperZapatosAPI.CallGetAPI("services/GetStores/");
            if (response.IsSuccessStatusCode)
            {
                // Creating Json Request Object
                storeResponse = new JavaScriptSerializer().Deserialize<PluralStoreResponse>(response.Content.ReadAsStringAsync().Result);
            }

            return View(storeResponse.stores);
        }

        // GET: /Store/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Store/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Address")] StoreModel storemodel)
        {
            if (ModelState.IsValid)
            {
                var response = SuperZapatosAPI.CallAPI("services/CreateStore/",storemodel);

                return RedirectToAction("Index");
            }

            return View(storemodel);
        }

        // GET: /Store/Edit/
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var storeResponse = new SingularStoreResponse();
            var response = SuperZapatosAPI.CallGetAPI("services/GetStoreById/", id.ToString());
            if (response.IsSuccessStatusCode)
            {
                // Creating Json Request Object
                storeResponse = new JavaScriptSerializer().Deserialize<SingularStoreResponse>(response.Content.ReadAsStringAsync().Result);
            }

            return View(storeResponse.store);
        }

        // POST: /Store/Edit/
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Name,Address")] StoreModel storemodel)
        {
            if (ModelState.IsValid)
            {
                var response = SuperZapatosAPI.CallAPI("services/UpdateStore/", storemodel);

                return RedirectToAction("Index");
            }

            return View(storemodel);
        }

        // GET: /Stores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var storeResponse = new SingularStoreResponse();
            var response = SuperZapatosAPI.CallGetAPI("services/GetStoreById/", id.ToString());
            if (response.IsSuccessStatusCode)
            {
                // Creating Json Request Object
                storeResponse = new JavaScriptSerializer().Deserialize<SingularStoreResponse>(response.Content.ReadAsStringAsync().Result);
            }

            return View(storeResponse.store);
        }

        // Post: /Stores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            var storeResponse = new SingularStoreResponse();
            var idModel = new IdModel();
            idModel.id = id.ToString();
            var response = SuperZapatosAPI.CallAPI("services/DeleteStore/", idModel);
            if (response.IsSuccessStatusCode)
            {
                // Creating Json Request Object
                storeResponse = new JavaScriptSerializer().Deserialize<SingularStoreResponse>(response.Content.ReadAsStringAsync().Result);
            }

            return RedirectToAction("Index");
        }


    }
}