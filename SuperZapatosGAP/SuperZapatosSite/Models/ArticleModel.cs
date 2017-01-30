using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SuperZapatosSite.Models
{
    public class ArticleModel
    {
        [DisplayName("Article ID")]
        public int id { get; set; }

        [DisplayName("Name")]
        public string name { get; set; }

        [DisplayName("Description")]
        public string description { get; set; }

        [DisplayName("Price")]
        public Decimal price { get; set; }

        [DisplayName("Total In Shelf")]
        public int total_in_shelf { get; set; }

        [DisplayName("Total In Vault")]
        public int total_in_vault { get; set; }

        [DisplayName("Store Name")]
        public string store_name { get; set; }

        [DisplayName("Store ID ")]
        public int store_id { get; set; }
    }
}