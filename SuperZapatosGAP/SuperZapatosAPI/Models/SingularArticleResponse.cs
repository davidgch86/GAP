using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperZapatosAPI.Data;

namespace SuperZapatosAPI.Models
{
    public class SingularArticleResponse
    {
        public bool success { get; set; }

        public ArticleDTO article { get; set; }
    }
}