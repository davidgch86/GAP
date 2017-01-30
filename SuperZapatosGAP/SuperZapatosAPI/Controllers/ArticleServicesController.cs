using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using SuperZapatosAPI.Data;
using SuperZapatosAPI.Models;
using SuperZapatosAPI.Authentication;

namespace SuperZapatosAPI.Controllers
{
    [IdentityBasicAuthentication]
    [Authorize]
    public class ArticleServicesController : ApiController
    {

        [Route("services/GetArticles")]
        [HttpGet]
        public IHttpActionResult GetArticles()
        {
            var response = new PluralArticleResponse();
            var result = new List<ArticleDTO>();
            try
            {
                result = ContextBehaviours.GetArticles();

                // Validate if find record
                if (result.Count == 0)
                    return Ok(ResponseHandler.Error(404));

                // Prepare success response
                response.articles = result;
                response.total_elements = result.Count;
                response.success = true;
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ResponseHandler.Error(500));
            }
            
        }

        [Route("services/GetArticleById/{id?}")]
        [HttpGet]
        public IHttpActionResult GetArticleById(string id)
        {
            int idInt = 0;
            var response = new SingularArticleResponse();
            var result = new ArticleDTO();
            try
            {
                // Validate request
                if (string.IsNullOrEmpty(id) || !int.TryParse(id,out idInt ))
                    return Ok(ResponseHandler.Error(400));

                result = ContextBehaviours.GetArticleById(idInt);

                // Validate if find record
                if (result == null)
                    return Ok(ResponseHandler.Error(404));

                // Prepare  success response
                response.article = result;
                response.success = true;

                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ResponseHandler.Error(500));
            }
        }

        [Route("services/GetArticlesByStore/{storeId?}")]
        [HttpGet]
        public IHttpActionResult GetArticlesByStore(string storeId)
        {
            int storeIdInt;
            var response = new PluralArticleResponse();
            var result = new List<ArticleDTO>();
            try
            {
                // Validate request
                if (string.IsNullOrEmpty(storeId) || !int.TryParse(storeId, out storeIdInt))
                    return Ok(ResponseHandler.Error(400));

                result = ContextBehaviours.GetArticlesByStore(storeIdInt);

                // Validate if find record
                if (result.Count == 0)
                    return Ok(ResponseHandler.Error(404));

                // Prepare  success response
                response.articles = result;
                response.success = true;
                response.total_elements = result.Count;
            }
            catch (Exception ex)
            {
                return Ok(ResponseHandler.Error(500));
            }
            return Ok(response);
        }

        [Route("services/CreateArticle")]
        [HttpPost]
        public IHttpActionResult CreateArticle([FromBody] ArticleDTO article)
        {
            var response = new SingularArticleResponse();
            try
            {
                ContextBehaviours.CreateArticle(article);

                // Prepare  success response
                response.article = article;
                response.success = true;
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ResponseHandler.Error(500));
            }
        }

        [Route("services/UpdateArticle")]
        [HttpPost]
        public IHttpActionResult UpdateArticle([FromBody] ArticleDTO article)
        {
            var response = new SingularArticleResponse();
            try
            {
                ContextBehaviours.UpdateArticle(article);
               
                // Prepare  success response
                response.article = article;
                response.success = true;
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ResponseHandler.Error(500));
            }
        }

        [Route("services/DeleteArticle/{id?}")]
        [HttpPost]
        public IHttpActionResult DeleteArticle([FromBody] IdModels id)
        {
            int idInt; 
            var response = new SingularArticleResponse();
            try
            {
                // Validate request
                if (string.IsNullOrEmpty(id.id) || !int.TryParse(id.id, out idInt))
                    return Ok(ResponseHandler.Error(400));

                var result=ContextBehaviours.DeleteArticle(idInt);

                // Prepare  success response
                response.article = result;
                response.success = true;
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ResponseHandler.Error(500));
            }
        }


    }
}
