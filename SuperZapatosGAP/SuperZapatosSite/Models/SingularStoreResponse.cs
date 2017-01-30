using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperZapatosSite.Models;

namespace SuperZapatosSite.Models
{
    public class SingularStoreResponse
    {
        public bool success { get; set; }

        public StoreModel store { get; set; }
    }
}