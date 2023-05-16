using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Middlewares
{
    public class StaticFilesMiddleware : IMiddleware
    {
        public HttpHandler? Next { get; set; }

        public void Handle(HttpListenerContext? context)
        {
            string url = context?.Request.RawUrl;
            Console.WriteLine(url);

            if (url.Substring(1) == "index.html")
            {
                var res = File.ReadAllBytes("wwwroot/index.html");
                context.Response.OutputStream.Write(res);
            }
            Next?.Invoke(context);
        }
    }
}
