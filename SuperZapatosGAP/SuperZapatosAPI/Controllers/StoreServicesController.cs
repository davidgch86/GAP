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
    public class StoreServicesController : ApiController
    {

        [Route("services/GetStores/")]
        [HttpGet]
        public IHttpActionResult GetStores()
        {
            var response = new PluralStoreResponse();
            var result = new List<StoreDTO>();
            try
            {
                result = ContextBehaviours.GetStores();

                // Validate if find record
                if (result.Count == 0)
                    return Ok(ResponseHandler.Error(404));

                // Prepare success response
                response.stores = result;
                response.total_elements = result.Count;
                response.success = true;
                return Ok(response);

            }
            catch (Exception ex)
            {
                return Ok(ResponseHandler.Error(500));
            }
        }

        [Route("services/GetStoreById/{id?}")]
        [HttpGet]
        public IHttpActionResult GetStoreById(string id)
        {
            int idInt = 0;
            var response = new SingularStoreResponse();
            var result = new StoreDTO();
            try
            {
                // Validate request
                if (string.IsNullOrEmpty(id) || !int.TryParse(id, out idInt))
                    return Ok(ResponseHandler.Error(400));

                result = ContextBehaviours.GetStoreById(idInt);

                // Validate if find record
                if (result == null)
                    return Ok(ResponseHandler.Error(404));

                // Prepare  success response
                response.store = result;
                response.success = true;
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ResponseHandler.Error(500));
            }
        }

        [Route("services/ExistStore/{storeId?}")]
        [HttpGet]
        public IHttpActionResult ExistStore(int storeId)
        {
            try
            {
                var result = ContextBehaviours.ExistStore(storeId);

            }
            catch (Exception ex)
            {
                return Ok(ResponseHandler.Error(500));
            }
            return Ok(true);
        }

        [Route("services/CreateStore")]
        [HttpPost]
        public IHttpActionResult CreateStore([FromBody] StoreDTO store)
        {
            var response = new SingularStoreResponse();
            try
            {
                ContextBehaviours.CreateStore(store);

                // Prepare  success response
                response.store = store;
                response.success = true;
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ResponseHandler.Error(500));
            }
        }

        [Route("services/UpdateStore")]
        [HttpPost]
        public IHttpActionResult UpdateStore([FromBody] StoreDTO store)
        {
            var response = new SingularStoreResponse();
            try
            {
                ContextBehaviours.UpdateStore(store);

                // Prepare  success response
                response.store = store;
                response.success = true;
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ResponseHandler.Error(500));
            }
        }

        [Route("services/DeleteStore/")]
        [HttpPost]
        public IHttpActionResult DeleteStore([FromBody] IdModels id)
        {
            int idInt=0;
            var response = new SingularStoreResponse();
            try
            {
                // Validate request
                if (string.IsNullOrEmpty(id.id) || !int.TryParse(id.id, out idInt))
                    return Ok(ResponseHandler.Error(400));

                var result = ContextBehaviours.DeleteStore(idInt);
                // Prepare  success response
                response.store = result;
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
