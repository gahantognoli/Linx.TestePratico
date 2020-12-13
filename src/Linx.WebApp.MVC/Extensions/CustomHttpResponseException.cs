using System;
using System.Net;

namespace Linx.WebApp.MVC.Extensions
{
    public class CustomHttpResponseException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        public CustomHttpResponseException()
        {
        }

        public CustomHttpResponseException(string message, Exception innerExpection) : base(message, innerExpection)
        {

        }

        public CustomHttpResponseException(HttpStatusCode httpStatusCode)
        {
            StatusCode = httpStatusCode;
        }
    }
}
