using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Middlewares
{
    public delegate void HttpHandler(HttpListenerContext context);
    public interface IMiddleware
    {
        public void Handle(HttpListenerContext context);

        public HttpHandler? Next { get; set; }
    }
}
