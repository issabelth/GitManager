using System;
using System.Net;

namespace GitAPI.Exceptions
{

    public class ResponseException : Exception
    {
        public ResponseException(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }

        public HttpStatusCode StatusCode { get; set; }
    }
}
