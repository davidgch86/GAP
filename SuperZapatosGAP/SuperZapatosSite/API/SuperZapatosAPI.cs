using SuperZapatosSite.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace SuperZapatosSite.API
{
    public class SuperZapatosAPI
    {
        /// <summary>
        /// Basic authentication credentials
        /// </summary>
        public static HttpClient ClientAPI()
        {
            // Credentials could be save in DB or config file are here 
            var user = "gaptest";
            var password = "gaptest";
            var url = "http://localhost:1881/";

            HttpClient client = new HttpClient();

            string authInfo = user + ":" + password;
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authInfo);
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        public static HttpResponseMessage CallAPI(string url, object _data = null)
        {
            HttpClient client = ClientAPI();
            string data = "";
            if (_data != null)
            {
                data = new JavaScriptSerializer().Serialize(_data);
            }

            HttpContent content = new StringContent(data);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            try
            {
              return client.PostAsync(url, content).Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static HttpResponseMessage CallGetAPI(string url, string id = "")
        {
            HttpClient client = ClientAPI();

            try
            {
                return client.GetAsync(url + id).Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}