using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperZapatosAPI.Data;

namespace SuperZapatosAPI.Models
{
    public class SingularStoreResponse
    {
        public bool success { get; set; }

        public StoreDTO store { get; set; }
    }
}