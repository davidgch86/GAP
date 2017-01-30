using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperZapatosSite.Models;

namespace SuperZapatosSite.Models
{
    public class PluralStoreResponse
    {
        public bool success { get; set; }

        public List<StoreModel> stores { get; set; }

        public int total_elements { get; set; }
    }
}