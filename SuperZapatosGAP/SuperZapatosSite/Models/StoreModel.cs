using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SuperZapatosSite.Models
{
    public class StoreModel
    {
       // [DisplayName("Store ID")]
        public int id { get; set; }

       // [DisplayName("Name")]
        public string name { get; set; }

        //[DisplayName("Address")]
        public string address { get; set; }
    }
}