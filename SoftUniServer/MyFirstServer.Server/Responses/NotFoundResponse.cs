using MyFirstServer.Server.HTTP;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFirstServer.Server.Responses.ActionResponses
{
    public class NotFoundResponse : Response
    {
        public NotFoundResponse()
            : base(StatusCode.NotFound)
        {
        }
    }
}
