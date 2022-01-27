using MyFirstServer.Server.HTTP;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFirstServer.Server.Responses.ActionResponses
{
    public class UnauthorizedResponse : Response
    {
        public UnauthorizedResponse()
            : base(StatusCode.Unauthorized)
        {
        }
    }
}
