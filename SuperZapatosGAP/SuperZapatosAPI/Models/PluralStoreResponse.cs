using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace SuperZapatosAPI.Models
{
    public class PluralStoreResponse
    {
        public bool success { get; set; }

        public List<StoreDTO> stores { get; set; }

        public int total_elements { get; set; }
    }
}