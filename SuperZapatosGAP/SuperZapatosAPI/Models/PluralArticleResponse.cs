using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperZapatosAPI.Data;

namespace SuperZapatosAPI.Models
{
    public class PluralArticleResponse
    {
        public bool success { get; set; }

        public List<ArticleDTO> articles { get; set; }

        public int total_elements { get; set; }
    }
}