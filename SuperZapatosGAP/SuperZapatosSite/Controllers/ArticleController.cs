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
    public class ArticleController : Controller
    {
        public JavaScriptSerializer serializer = new JavaScriptSerializer();
        // GET: Article
        public ActionResult Index()
        {
            var articleResponse = new PluralArticleResponse();
            var response = SuperZapatosAPI.CallGetAPI("services/GetArticles/");
            if (response.IsSuccessStatusCode)
            {
                // Creating Json Request Object
                articleResponse = new JavaScriptSerializer().Deserialize<PluralArticleResponse>(response.Content.ReadAsStringAsync().Result);
            }

            return View(articleResponse.articles);

        }

        // GET: /Article/Create
        public ActionResult Create()
        {
            //Load stores
            var storeResponse = new PluralStoreResponse();
            var response = SuperZapatosAPI.CallGetAPI("services/GetStores/");
            var items = new List<SelectListItem>();
            if (response.IsSuccessStatusCode)
            {
                // Creating Json Request Object
                storeResponse = new JavaScriptSerializer().Deserialize<PluralStoreResponse>(response.Content.ReadAsStringAsync().Result);

                
                foreach (var item in storeResponse.stores)
                {
                    SelectListItem newItem = new SelectListItem()
                    {
                        Text = item.name,
                        Value = item.id.ToString()
                    };
                    items.Add(newItem);
                }
            }
            ViewBag.Stores = items;
            return View();
        }

        // POST: /Article/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "name, description, price, total_in_shelf, total_in_vault, store_id")] ArticleModel articlemodel)
        {
            if (ModelState.IsValid)
            {
                var response = SuperZapatosAPI.CallAPI("services/CreateArticle/", articlemodel);

                return RedirectToAction("Index");
            }

            return View(articlemodel);
        }


        // GET: /Article/Edit/
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var articleResponse = new SingularArticleResponse();
            var result = SuperZapatosAPI.CallGetAPI("services/GetArticleById/", id.ToString());
            if (result.IsSuccessStatusCode)
            {
                // Creating Json Request Object
                articleResponse = new JavaScriptSerializer().Deserialize<SingularArticleResponse>(result.Content.ReadAsStringAsync().Result);
            }

             //Load stores
            var storesResponse = new PluralStoreResponse();
            var response = SuperZapatosAPI.CallGetAPI("services/GetStores/");
            var items = new List<SelectListItem>();
            if (response.IsSuccessStatusCode)
            {
                // Creating Json Request Object
                storesResponse = new JavaScriptSerializer().Deserialize<PluralStoreResponse>(response.Content.ReadAsStringAsync().Result);

                
                foreach (var item in storesResponse.stores)
                {
                    SelectListItem newItem = new SelectListItem()
                    {
                        Text = item.name,
                        Value = item.id.ToString()
                    };
                    items.Add(newItem);
                }
            }
            ViewBag.Stores = items;

            return View(articleResponse.article);
        }

        // POST: /Article/Edit/
        [HttpPost]
        public ActionResult Edit([Bind(Include = "id,name, description, price, total_in_shelf, total_in_vault, store_id")]  ArticleModel articlemodel)
        {
            if (ModelState.IsValid)
            {
                var response = SuperZapatosAPI.CallAPI("services/UpdateArticle/", articlemodel);

                return RedirectToAction("Index");
            }

            return View(articlemodel);
        }

        // GET: /Stores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var articleResponse = new SingularArticleResponse();
            var response = SuperZapatosAPI.CallGetAPI("services/GetArticleById/", id.ToString());
            if (response.IsSuccessStatusCode)
            {
                // Creating Json Request Object
                articleResponse = new JavaScriptSerializer().Deserialize<SingularArticleResponse>(response.Content.ReadAsStringAsync().Result);
            }

            return View(articleResponse.article);
        }

        // Post: /Article/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            var articleResponse = new SingularArticleResponse();
            var idModel = new IdModel();
            idModel.id = id.ToString();
            var response = SuperZapatosAPI.CallAPI("services/DeleteArticle/", idModel);
            if (response.IsSuccessStatusCode)
            {
                // Creating Json Request Object
                articleResponse = new JavaScriptSerializer().Deserialize<SingularArticleResponse>(response.Content.ReadAsStringAsync().Result);
            }

            return RedirectToAction("Index");
        }

    }
}