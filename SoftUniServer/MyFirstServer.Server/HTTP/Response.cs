using System;
using System.Collections.Generic;
using System.Text;

namespace MyFirstServer.Server.HTTP
{
    public class Response
    {
        public StatusCode StatusCode { get; set; }

        public HeaderCollection Headers { get; } = new HeaderCollection();

        public CookieCollection Cookies { get; } = new CookieCollection();

        public string Body { get; set; }

        public Action<Request, Response> PreRenderAction { get; protected set; }

        public Response(StatusCode _statusCode)
        {
            StatusCode = _statusCode;

            Headers.Add(Header.Server, "My Web Server");
            Headers.Add(Header.Date, $"{DateTime.UtcNow:R}");
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"HTTP/1.1 {(int)this.StatusCode} {this.StatusCode}");

            foreach (var header in this.Headers)
            {
                result.AppendLine(header.ToString());
            }
            foreach (var cookie in this.Cookies)
            {
                result.AppendLine($"{Header.SetCookie}: {cookie}");
            }

            result.AppendLine();

            if (!string.IsNullOrEmpty(this.Body))
            {
                result.Append(this.Body);
            }

            return result.ToString();
        }
    }
}
