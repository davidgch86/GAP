using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SuperZapatosAPI.Models;

namespace SuperZapatosAPI.Data
{
    public class ContextBehaviours
    {
        /// <summary>
        /// Get all articles
        /// </summary>
        public static List<ArticleDTO> GetArticles()
        {
            try
            {
                using (SuperZapatosContext db = new SuperZapatosContext())
                {
                    var salida = (from a in db.Articles
                                  join s in db.Stores on a.store_id equals s.id
                                  select new ArticleDTO()
                             {
                                 id = a.id,
                                 name = a.name,
                                 description = a.description,
                                 price = a.price,
                                 total_in_shelf = a.total_in_shelf,
                                 total_in_vault = a.total_in_vault,
                                 store_id =a.store_id,
                                 store_name = s.name
                             }).ToList();
                    return salida;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get articles by ID
        /// </summary>
        public static ArticleDTO GetArticleById(int id)
        {
            try
            {
                using (SuperZapatosContext db = new SuperZapatosContext())
                {
                    return (from a in db.Articles
                            join s in db.Stores on a.store_id equals s.id
                            where a.id == id
                            select new ArticleDTO()
                            {
                                id = a.id,
                                name = a.name,
                                description = a.description,
                                price = a.price,
                                total_in_shelf = a.total_in_shelf,
                                total_in_vault = a.total_in_vault,
                                store_name = s.name
                            }).FirstOrDefault();
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///  Get articles by store id
        /// </summary>
        public static List<ArticleDTO> GetArticlesByStore(int storeId)
        {
            try
            {
                using (SuperZapatosContext db = new SuperZapatosContext())
                {
                    return (from a in db.Articles
                            join s in db.Stores on a.store_id equals s.id
                            where s.id == storeId
                            select new ArticleDTO()
                           {
                               id = a.id,
                               name = a.name,
                               description = a.description,
                               price = a.price,
                               total_in_shelf = a.total_in_shelf,
                               total_in_vault = a.total_in_vault,
                               store_name = s.name
                           }).ToList();
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///  Create new article
        /// </summary>
        public static void CreateArticle(ArticleDTO articleDTO)
        {
            try
            {
                using (SuperZapatosContext db = new SuperZapatosContext())
                {
                    var articleDB = new Article();
                    articleDB.name = articleDTO.name;
                    articleDB.description = articleDTO.description;
                    articleDB.price = articleDTO.price;
                    articleDB.total_in_shelf = articleDTO.total_in_shelf;
                    articleDB.total_in_vault = articleDTO.total_in_vault;
                    articleDB.store_id = articleDTO.store_id;
                    db.Articles.Add(articleDB);
                    db.SaveChanges();
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///  Update Article
        /// </summary>
        public static void UpdateArticle(ArticleDTO articleDTO)
        {
            try
            {
                using (SuperZapatosContext db = new SuperZapatosContext())
                {
                    var articleDB = new Article();
                    articleDB.name = articleDTO.name;
                    articleDB.description = articleDTO.description;
                    articleDB.price = articleDTO.price;
                    articleDB.total_in_shelf = articleDTO.total_in_shelf;
                    articleDB.total_in_vault = articleDTO.total_in_vault;
                    articleDB.store_id = articleDTO.store_id;
                    db.Entry(articleDB).State = EntityState.Modified;
                    db.SaveChanges();
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Remove article
        /// </summary>
        public static ArticleDTO DeleteArticle(int id)
        {
            try
            {
                using (SuperZapatosContext db = new SuperZapatosContext())
                {
                    var articleToDelete = GetArticleById(id);
                    var articlemodel = db.Articles.Find(id);
                    db.Articles.Remove(articlemodel);
                    db.SaveChanges();

                    return articleToDelete;
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all stores
        /// </summary>
        public static List<StoreDTO> GetStores()
        {
            try
            {
                using (SuperZapatosContext db = new SuperZapatosContext())
                {
                    return (from s in db.Stores
                            select new StoreDTO()
                            {
                                id = s.id,
                                name = s.name,
                                address = s.address
                            }).ToList();
                };

            }
            catch (Exception ex)
            {
                string sMsg = string.Format("SuperZapatos.GetStores");
                throw new Exception(sMsg, ex);
            }
        }

        /// <summary>
        /// Get stores by id
        /// </summary>
        public static StoreDTO GetStoreById(int id)
        {
            try
            {
                using (SuperZapatosContext db = new SuperZapatosContext())
                {
                    return (from s in db.Stores
                            where s.id == id
                            select new StoreDTO()
                            {
                                id = s.id,
                                name = s.name,
                                address = s.address
                            }).FirstOrDefault();
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Validate if the store exist
        /// </summary>
        public static bool ExistStore(int id)
        {
            try
            {
                using (SuperZapatosContext db = new SuperZapatosContext())
                {
                    return (from s in db.Stores
                            where s.id == id
                            select s).FirstOrDefault() == null ? false : true;
                };

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Create Store
        /// </summary>
        public static void CreateStore(StoreDTO storeDTO)
        {
            try
            {
                using (SuperZapatosContext db = new SuperZapatosContext())
                {
                    var storeDB = new Store();
                    storeDB.name = storeDTO.name;
                    storeDB.address = storeDTO.address;
                    db.Stores.Add(storeDB);
                    db.SaveChanges();
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///  Update store
        /// </summary>
        public static void UpdateStore(StoreDTO storeDTO)
        {
            try
            {
                using (SuperZapatosContext db = new SuperZapatosContext())
                {
                    var storeDB = new Store();
                    storeDB.name = storeDTO.name;
                    storeDB.address = storeDTO.address;
                    storeDB.id = storeDTO.id;
                    db.Entry(storeDB).State = EntityState.Modified;
                    db.SaveChanges();
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Remove  store
        /// </summary>
        public static StoreDTO DeleteStore(int id)
        {
            try
            {
                using (SuperZapatosContext db = new SuperZapatosContext())
                {
                    var storeToDelete = GetStoreById(id);
                    
                    var storemodel = db.Stores.Find(id);
                    db.Stores.Remove(storemodel);
                    db.SaveChanges();
                    return storeToDelete;
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}