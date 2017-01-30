using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperZapatosAPI.Models
{
    public class ErrorResponse
    {
        // success = "false", error_code = code, error_msg = message
        public bool success { set; get; }

        public int error_code { set; get; }

        public string error_msg { set; get; }
    }
}