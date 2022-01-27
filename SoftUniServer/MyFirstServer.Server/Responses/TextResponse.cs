using MyFirstServer.Server.HTTP;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFirstServer.Server.Responses
{
    public class TextResponse : ContentResponse
    {
        public TextResponse(string text, Action<Request, Response> preRenderAction = null)
            : base(text, ContentType.PlainText, preRenderAction)
        {
        }
    }
}
