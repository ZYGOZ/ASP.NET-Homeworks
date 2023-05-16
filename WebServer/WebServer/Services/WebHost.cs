using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebServer.Middlewares;


//var listener = new HttpListener();

//listener.Prefixes.Add("http://localhost:5500/");

//listener.Start();


//while (true)
//{

//    var context = listener.GetContext();

//    Console.WriteLine(context.Request.RawUrl);

//    context.Response.AddHeader("Content-Type", "application/json");

//    context.Response.Close();
//}


namespace WebServer.Services
{
    public class WebHost
    {
        public WebHost(ushort port)
        {
            _port = port;
            _listener = new();
            _builder = new();
        }

        public void UseStartup<T>() where T : class
        {
            var startup = Activator.CreateInstance(typeof(T)) as IStartup;
            
            startup?.Configure(_builder);
        }
        public void Start()
        {
            _listener.Prefixes.Add($"http://localhost:{_port}/");
            _listener.Start();
            Console.WriteLine($"Server started on port: {_port}");


            while (true)
            {
                var context = _listener.GetContext();

                HandleRequest(context);
            }
        }

        public void HandleRequest(HttpListenerContext context)
        {
            var handler = _builder?.Build();
            handler?.Invoke(context);
        }

        private HttpListener _listener;
        private ushort _port;

        private MiddlewareBuilder? _builder;
    }
}
