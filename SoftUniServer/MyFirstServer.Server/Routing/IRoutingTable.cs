﻿using MyFirstServer.Server.HTTP;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFirstServer.Server.Routing
{
    public interface IRoutingTable
    {
        IRoutingTable Map(string url, Method method, Response response);

        IRoutingTable MapGet(string url, Response response);

        IRoutingTable MapPost(string url, Response response);
    }
}
