using CSPlaypen.TestObjects;
using Grapevine.Interfaces.Server;
using Grapevine.Server.Attributes;
using Grapevine.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSPlaypen.GrapevineControllers
{
    [RestResource]
    class HomeController
    {
        [RestRoute(HttpMethod = HttpMethod.GET, PathInfo = "/stats")]
        public IHttpContext Stats(IHttpContext context)
        {
            var a = context.GetPropertyValueAs<A>("A");
            a.OnCall();

            string responseString = $@"
<HTML>
<BODY>
    Welcome to CSPlaypen!<hr/>
    
    Your request contained the following info:

    <table>
        <tr>
            <td>HttpMethod</td><td>{context.Request.HttpMethod}</td>
        </tr>
        <tr>
            <td>LocalEndPoint</td><td>{context.Request.LocalEndPoint}</td>
        </tr>
        <tr>
            <td>QueryString</td><td>{context.Request.QueryString}</td>
        </tr>
         <tr>
            <td>RawUrl</td><td>{context.Request.RawUrl}</td>
        </tr>
        <tr>
            <td>State of some object A</td><td>{a.State}</td>
        </tr>
    <table>
</BODY>
</HTML>";

            context.Response.SendResponse(Encoding.UTF8.GetBytes(responseString));
            return context;
        }

        [RestRoute(HttpMethod = HttpMethod.GET, PathInfo = "/")]
        public IHttpContext Get(IHttpContext context)
        {
            context.Response.SendResponse(Encoding.UTF8.GetBytes(GenericA<int>.ToStr()));
            return context;
        }
    }
}
