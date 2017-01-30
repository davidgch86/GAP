using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperZapatosAPI.Data;

namespace SuperZapatosAPI.Models
{
    public class ResponseHandler
    {
        /// <summary>
        /// Return the object with the error details for code
        /// </summary>
        public static ErrorResponse Error(int code)
        {
            // {"success":false,"error_code": XXX, "error_msg":"ERROR_MESSAGE"}
            // 400 - Bad request 
            // 401 – Not authorized
            // 404 - Record not found
            // 500 - Server Error
            var failure = new ErrorResponse();
            switch (code)
            {
                case 400:
                    failure.error_msg = "Bad request";
                    break;
                case 401:
                    failure.error_msg = "Not authorized";
                    break;
                case 404:
                    failure.error_msg = "Record not found";
                    break;
                default:
                    failure.error_msg = "Server Error";
                    break;
            }
            failure.error_code = code;
            failure.success = true;
            return failure;
        }

        //TODO desing custom Exception
    }
}