using System.Net;


namespace WebServer.Middlewares
{
    internal class LoggerMiddleware : IMiddleware
    {
        public HttpHandler? Next { get; set; }

        public void Handle(HttpListenerContext context)
        {
            Console.WriteLine(context.Request.UserHostAddress);

            Next?.Invoke(context);
        }
    }
}
