using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperZapatosSite.Models;

namespace SuperZapatosSite.Models
{
    public class PluralArticleResponse
    {
        public bool success { get; set; }

        public List<ArticleModel> articles { get; set; }

        public int total_elements { get; set; }
    }
}