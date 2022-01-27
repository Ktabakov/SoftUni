using MyFirstServer.Server.HTTP;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFirstServer.Server.Responses.ActionResponses
{
    public class BadRequestResponse : Response
    {
        public BadRequestResponse()
            : base(StatusCode.BadRequest)
        {
        }
    }
}
