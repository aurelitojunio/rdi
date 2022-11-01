using System.Net;

namespace CrossCutting.Extensions
{
    public class HttpException : Exception
    {
        private readonly int httpStatusCode;
        public HttpException(HttpStatusCode httpStatusCode, string message) : base(message)
        {
            this.httpStatusCode = (int)httpStatusCode;
        }

        public int StatusCode { get { return this.httpStatusCode; } }
    }
}
