using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperZapatosSite.Models;

namespace SuperZapatosSite.Models
{
    public class SingularArticleResponse
    {
        public bool success { get; set; }

        public ArticleModel article { get; set; }
    }
}